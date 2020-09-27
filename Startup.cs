using System;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Dess.DbContexts;
using Dess.Entities;
using Dess.Helpers;
using Dess.Hubs;
using Dess.Models.User;
using Dess.Repositories;
using Dess.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;

namespace DESS
{
  public class Startup
  {
    private IConfiguration _configuration;

    public Startup(IConfiguration configuration) =>
      _configuration = configuration;

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
      // services.AddControllersWithViews();
      services.AddControllersWithViews(o => o.Filters.Add(new AuthorizeFilter()));
      services.AddCors();
      services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
      services.AddHttpClient();
      services.AddSignalR();

      services.AddScoped<IElectroFenceRepository, ElectroFenceRepository>();
      services.AddScoped<ILogRepository, LogRepository>();
      services.AddScoped<IUserRepository, UserRepository>();
      services.AddScoped<IUserLogRepository, UserLogRepository>();
      services.AddScoped<IPermissionRepository, PermissionRepository>();

      services.AddScoped<IUserService, UserService>();

      var connectionString = _configuration.GetSection("ConnectionStrings")["DessConnectionString"];
      services.AddDbContext<DessDbContext>(o => o.UseMySql(connectionString));

      // configure strongly typed settings objects
      var appSettingsSection = _configuration.GetSection("AppSettings");
      services.Configure<AppSettings>(appSettingsSection);

      // configure jwt authentication
      var appSettings = appSettingsSection.Get<AppSettings>();
      var key = Encoding.ASCII.GetBytes(appSettings.Secret);

      services.AddAuthentication(options =>
      {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
      })
        .AddJwtBearer(action =>
        {
          action.Events = new JwtBearerEvents
          {
            OnTokenValidated = context =>
            {
              var userRepository = context.HttpContext.RequestServices.GetRequiredService<IUserRepository>();
              var username = context.Principal.Identity.Name;
              var user = userRepository.GetAsync(username).Result;

              if (user == null)
                context.Fail("Unauthorized");

              return Task.CompletedTask;
            }
          };

          action.RequireHttpsMetadata = false;
          action.SaveToken = true;
          action.TokenValidationParameters = new TokenValidationParameters
          {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(key),
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = true
          };
        });

      // var serviceProvider = services.BuildServiceProvider();
      // var permissionRepository = (IPermissionRepository)serviceProvider.GetService<IPermissionRepository>();
      // var permissions = permissionRepository.GetAllAsync().Result;

      // services.AddAuthorizationCore(options =>
      // {
      //   foreach (var permission in permissions)
      //   {
      //     options.AddPolicy(permission.Title, builder =>
      //     {
      //       builder.RequireAuthenticatedUser();
      //       builder.RequireClaim("Permission", permission.Title);
      //     });
      //   }
      // });

      // In production, the React files will be served from this directory
      services.AddSpaStaticFiles(configuration =>
      {
        configuration.RootPath = "ClientApp/build";
      });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
        app.UseDeveloperExceptionPage();

      else
      {
        app.UseExceptionHandler("/Error");
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
      }

      app.UseHttpsRedirection();
      app.UseStaticFiles();
      app.UseSpaStaticFiles();

      app.UseRouting();

      app.UseCors(x => x
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());

      app.UseAuthentication();
      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllerRoute(
                  name: "default",
                  pattern: "{controller}/{action=Index}/{id?}");
        endpoints.MapHub<ElectroFenceHub>("/api/irancell/web/efhub");
      });

      app.UseSpa(spa =>
      {
        spa.Options.SourcePath = "ClientApp";

        if (env.IsDevelopment())
        {
          spa.UseReactDevelopmentServer(npmScript: "start");
        }
      });

      using (var serviceScope = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
      {
        var context = serviceScope.ServiceProvider.GetService<DessDbContext>();

        context.Database.EnsureDeleted();
        context.Database.Migrate();
        context.Database.EnsureCreated();
      }
    }
  }
}