using AutoMapper;
using Dess.Entities;
using Dess.Helpers;
using Dess.Types;
using Microsoft.EntityFrameworkCore;

namespace Dess.DbContexts
{
  public class DessDbContext : DbContext
  {
    private IMapper _mapper;

    public DessDbContext(DbContextOptions<DessDbContext> options, IMapper mapper) : base(options) =>
      _mapper = mapper;

    public DbSet<ElectroFence> ElectroFences { get; set; }
    public DbSet<ElectroFenceStatus> Logs { get; set; }
    public DbSet<IO> IOs { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserLog> UserLogs { get; set; }
    public DbSet<UserGroup> UserGroups { get; set; }
    public DbSet<UserPermission> UserPermissions { get; set; }
    public DbSet<UserGroupPermission> UserGroupPermissions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      modelBuilder.Entity<ElectroFence>()
        .HasOne(e => e.Status)
        .WithOne(s => s.ElectroFence)
        .HasForeignKey<ElectroFenceStatus>(s => s.ElectroFenceId);

      modelBuilder.Entity<ElectroFence>()
        .HasMany(e => e.IOs)
        .WithOne(i => i.Module)
        .HasForeignKey(i => i.ModuleId);

      modelBuilder.Entity<UserLog>()
        .HasOne(u => u.User)
        .WithMany(u => u.UserLogs)
        .HasForeignKey(u => u.UserId);

      modelBuilder.Entity<UserLog>()
        .HasOne(u => u.Log)
        .WithMany(l => l.UserLogs)
        .HasForeignKey(u => u.LogId);

      modelBuilder.Entity<User>()
        .HasOne(u => u.Group)
        .WithMany(g => g.Users)
        .HasForeignKey(u => u.GroupId);

      modelBuilder.Entity<UserGroupPermission>()
        .HasKey(gp => new { gp.GroupId, gp.PermissionId });

      modelBuilder.Entity<UserGroupPermission>()
        .HasOne(gp => gp.Group)
        .WithMany(g => g.UserGroupPermissions)
        .HasForeignKey(gp => gp.GroupId);

      modelBuilder.Entity<UserGroupPermission>()
        .HasOne(gp => gp.Permission)
        .WithMany(p => p.UserGroupPermissions)
        .HasForeignKey(gp => gp.PermissionId);

      var allMighty = new UserGroup
      { Id = 1, Title = "Almighty" };
      var expert = new UserGroup
      { Id = 2, Title = "Expert" };
      var admin = new UserGroup
      { Id = 3, Title = "Admin" };
      var operate = new UserGroup
      { Id = 4, Title = "Operator" };

      var groups = new UserGroup[] { allMighty, expert, admin, operate };
      modelBuilder.Entity<UserGroup>().HasData(groups);

      var isAlmighty = new UserPermission
      { Id = 1, Title = "IsAlmighty" };
      var canSecureSites = new UserPermission
      { Id = 2, Title = "CanSecureSites" };
      var canEditSites = new UserPermission
      { Id = 3, Title = "CanEditSites" };
      var canEditUserGroup = new UserPermission
      { Id = 4, Title = "CanEditUserGroups" };
      var canEditUsers = new UserPermission
      { Id = 5, Title = "CanEditUsers" };

      var permissions = new UserPermission[] { isAlmighty, canSecureSites, canEditSites, canEditUserGroup, canEditUsers };
      modelBuilder.Entity<UserPermission>().HasData(permissions);

      var groupPermissions = new UserGroupPermission[] {
        new UserGroupPermission { GroupId = allMighty.Id, PermissionId = isAlmighty.Id },
        new UserGroupPermission { GroupId = allMighty.Id, PermissionId = canSecureSites.Id },
        new UserGroupPermission { GroupId = allMighty.Id, PermissionId = canEditSites.Id },
        new UserGroupPermission { GroupId = allMighty.Id, PermissionId = canEditUserGroup.Id },
        new UserGroupPermission { GroupId = allMighty.Id, PermissionId = canEditUsers.Id },

        new UserGroupPermission { GroupId = expert.Id, PermissionId = canSecureSites.Id },
        new UserGroupPermission { GroupId = expert.Id, PermissionId = canEditSites.Id },
        new UserGroupPermission { GroupId = expert.Id, PermissionId = canEditUserGroup.Id },
        new UserGroupPermission { GroupId = expert.Id, PermissionId = canEditUsers.Id },

        new UserGroupPermission { GroupId = admin.Id, PermissionId = canSecureSites.Id },
        new UserGroupPermission { GroupId = admin.Id, PermissionId = canEditSites.Id },
        new UserGroupPermission { GroupId = admin.Id, PermissionId = canEditUsers.Id },


        new UserGroupPermission { GroupId = operate.Id, PermissionId = canEditSites.Id }
      };
      modelBuilder.Entity<UserGroupPermission>().HasData(groupPermissions);

      var users = new User[] {
        new User { Id = 1, Username = "expert", Password = Cryptography.GeneratePasswordHash("expert"), FirstName = "Amir", LastName = "Fakhim-Babaei",GroupId = 1 },
        new User { Id = 2, Username = "admin", Password = Cryptography.GeneratePasswordHash("admin"), FirstName = "Amir", LastName = "Fakhim-Babaei",GroupId = 2 },
        new User { Id = 3, Username = "operator", Password = Cryptography.GeneratePasswordHash("operator"), FirstName = "Amir", LastName = "Fakhim-Babaei",GroupId = 3 }
        };
      modelBuilder.Entity<User>().HasData(users);

      var ef1 = new ElectroFence { Id = 1, Name = "Ef1", SiteId = "ehp-ie-tbz1", Serial = "001", HvEnabled = true, LvEnabled = true, HvPower = 70, HvRepeat = 2, HvThreshold = 3000, Latitude = "31.7", Longitude = "13.5" };
      var ef2 = new ElectroFence { Id = 2, Name = "Ef2", SiteId = "ehp-ie-tbz2", Serial = "002", HvEnabled = true, LvEnabled = false, HvPower = 70, HvRepeat = 3, HvThreshold = 4000, Latitude = "-3.4", Longitude = "113.7" };
      var ef3 = new ElectroFence { Id = 3, Name = "Ef3", SiteId = "ehp-ie-tbz3", Serial = "003", HvEnabled = true, LvEnabled = false, HvPower = 80, HvRepeat = 2, HvThreshold = 5000, Latitude = "11.57", Longitude = "-5" };

      var status1 = new ElectroFenceStatus { Id = 1, ElectroFenceId = 1 };
      var status2 = new ElectroFenceStatus { Id = 2, ElectroFenceId = 2 };
      var status3 = new ElectroFenceStatus { Id = 3, ElectroFenceId = 3 };

      modelBuilder.Entity<ElectroFence>().HasData(ef1, ef2, ef3);
      modelBuilder.Entity<ElectroFenceStatus>().HasData(status1, status2, status3);

      for (int i = 0; i < 4; i++)
      {
        var io1 = new IO { Id = i * 3 + 1, Enabled = i < 2, Type = i % 2 == 0 ? IOType.NO : IOType.NC, ModuleId = ef1.Id };
        var io2 = new IO { Id = i * 3 + 2, Enabled = i < 3, Type = i % 2 == 1 ? IOType.NO : IOType.NC, ModuleId = ef2.Id };
        var io3 = new IO { Id = i * 3 + 3, Enabled = i < 1, Type = i % 2 == 0 ? IOType.NO : IOType.NC, ModuleId = ef3.Id };

        modelBuilder.Entity<IO>().HasData(io1, io2, io3);
      }
    }
  }
}