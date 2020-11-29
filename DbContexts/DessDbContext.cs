using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

using AutoMapper;

using Dess.Api.Entities;
using Dess.Api.Helpers;
using Dess.Api.Types;

namespace Dess.Api.DbContexts
{
  public class DessDbContext : DbContext
  {
    private IMapper _mapper;

    public DessDbContext(DbContextOptions<DessDbContext> options, IMapper mapper) : base(options) =>
      _mapper = mapper;

    public DbSet<SiteGroup> SiteGroups { get; set; }
    public DbSet<Site> Sites { get; set; }
    public DbSet<SiteStatus> Statuses { get; set; }
    public DbSet<SiteFault> Logs { get; set; }
    public DbSet<Input> Inputs { get; set; }
    public DbSet<Output> Outputs { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserLog> UserLogs { get; set; }
    public DbSet<UserGroup> UserGroups { get; set; }
    public DbSet<Permission> Permissions { get; set; }
    public DbSet<RefreshToken> RefreshToekns { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      modelBuilder.Entity<Site>()
        .HasMany(e => e.Log)
        .WithOne(l => l.Site)
        .HasForeignKey(l => l.SiteId);

      modelBuilder.Entity<Site>()
        .HasMany(e => e.Inputs)
        .WithOne(i => i.Module)
        .HasForeignKey(i => i.ModuleId);

      modelBuilder.Entity<Site>()
        .HasMany(e => e.Outputs)
        .WithOne(o => o.Module)
        .HasForeignKey(o => o.ModuleId);

      modelBuilder.Entity<SiteGroupUser>()
        .HasKey(sgu => new { sgu.GroupId, sgu.UserId });

      modelBuilder.Entity<SiteGroupUser>()
        .HasOne(sgu => sgu.Group)
        .WithMany(g => g.Users)
        .HasForeignKey(sgu => sgu.GroupId);

      modelBuilder.Entity<SiteGroupUser>()
        .HasOne(sgu => sgu.User)
        .WithMany(u => u.SiteGroups)
        .HasForeignKey(sgu => sgu.UserId);

      var converterTrigger = new ValueConverter<ICollection<TriggerType>, string>(
          t => string.Join(";", t.ToList().ConvertAll(t => (int)t)),
          t => t.Split(";", StringSplitOptions.RemoveEmptyEntries).Select(val => (TriggerType)int.Parse(val)).ToList());

      modelBuilder.Entity<Output>()
        .Property(e => e.Triggers)
        .HasConversion(converterTrigger);

      var converterIntCollection = new ValueConverter<ICollection<int>, string>(
          u => string.Join(";", u.ToList().ConvertAll(u => u)),
          u => u.Split(";", StringSplitOptions.RemoveEmptyEntries).Select(val => int.Parse(val)).ToList());

      modelBuilder.Entity<SiteFault>()
        .Property(e => e.SeenBy)
        .HasConversion(converterIntCollection);

      modelBuilder.Entity<UserGroup>()
        .Property(ug => ug.PermissionIds)
        .HasConversion(converterIntCollection);

      var converterIo = new ValueConverter<IList<bool>, string>(
          u => string.Join(";", u.ToList().ConvertAll(u => u)),
          u => u.Split(";", StringSplitOptions.RemoveEmptyEntries).Select(val => bool.Parse(val)).ToList());

      modelBuilder.Entity<SiteStatus>()
        .Property(e => e.Inputs)
        .HasConversion(converterIo);

      modelBuilder.Entity<SiteStatus>()
        .Property(e => e.Outputs)
        .HasConversion(converterIo);

      modelBuilder.Entity<UserLog>()
        .HasOne(u => u.User)
        .WithMany(u => u.UserLogs)
        .HasForeignKey(u => u.UserId);

      modelBuilder.Entity<User>()
        .HasOne(u => u.Group)
        .WithMany(g => g.Users)
        .HasForeignKey(u => u.GroupId);

      var isAlmighty = new Permission { Id = 1, Title = "IsAlmighty" };
      var canSecure = new Permission { Id = 2, Title = "CanSecure" };
      var canEditSites = new Permission { Id = 3, Title = "CanEditSites" };
      var canAddRemoveSites = new Permission { Id = 4, Title = "CanAddRemoveSites" };
      var canHandleSiteGroups = new Permission { Id = 5, Title = "CanHandleSiteGroups" };
      var canHandleUsers = new Permission { Id = 6, Title = "CanEditUsers" };
      var canHandleUserGroup = new Permission { Id = 7, Title = "CanHandleUserGroup" };
      var canAssignAdmin = new Permission { Id = 8, Title = "CanAssignAdmin" };

      var permissions = new Permission[] { isAlmighty, canSecure, canEditSites, canAddRemoveSites, canHandleSiteGroups, canHandleUsers, canHandleUserGroup, canAssignAdmin };
      modelBuilder.Entity<Permission>().HasData(permissions);

      var almighty = new UserGroup { Id = 1, Title = "Almighty", PermissionIds = new List<int>(permissions.Select(p => p.Id)) };
      var manager = new UserGroup { Id = 2, Title = "Manager", PermissionIds = new List<int>(permissions.Where(p => p.Id != isAlmighty.Id).Select(p => p.Id)) };
      var admin = new UserGroup { Id = 3, Title = "Admin", PermissionIds = new List<int> { canSecure.Id, canEditSites.Id, canHandleUsers.Id } };
      var operate = new UserGroup { Id = 4, Title = "Operator" };

      var groups = new UserGroup[] { almighty, manager, admin, operate };
      modelBuilder.Entity<UserGroup>().HasData(groups);

      var users = new User[]
      {
        new User { Id = 1, Username = "almighty", Password = Cryptography.GeneratePasswordHash(Cryptography.GenerateHashSHA256String("almighty")), FirstName = "Amir", LastName = "Fakhim-Babaei", GroupId = almighty.Id },
        new User { Id = 2, Username = "manager", Password = Cryptography.GeneratePasswordHash(Cryptography.GenerateHashSHA256String("manager")), FirstName = "Amir", LastName = "Chegini", GroupId = manager.Id },
        new User { Id = 3, Username = "admin", Password = Cryptography.GeneratePasswordHash(Cryptography.GenerateHashSHA256String("admin")), FirstName = "No", LastName = "One", GroupId = admin.Id },
        new User { Id = 4, Username = "operator", Password = Cryptography.GeneratePasswordHash(Cryptography.GenerateHashSHA256String("operator")), FirstName = "Not", LastName = "Yet", GroupId = operate.Id }
      };
      modelBuilder.Entity<User>().HasData(users);

      var siteGroup = new SiteGroup { Id = 1, Name = "R8" };
      var site1 = new Site { Id = 1, GroupId = 1, Name = "T5011", SerialNo = "SC20D3001N", Interval = 10, HvEnabled = true, LvEnabled = true, HvPower = 70, HvRepeat = 2, HvThreshold = 3000, Latitude = "38.0962", Longitude = "46.2738" };
      var status1 = new SiteStatus { Id = 1, SiteId = 1 };

      modelBuilder.Entity<SiteGroup>().HasData(siteGroup);
      modelBuilder.Entity<Site>().HasData(site1);
      modelBuilder.Entity<SiteStatus>().HasData(status1);

      for (int i = 0; i < 2; i++)
      {
        var i1 = new Input { Id = i * 3 + 1, Enabled = i < 2, Type = i % 2 == 0 ? IOType.NO : IOType.NC, ModuleId = site1.Id };
        // var i2 = new Input { Id = i * 3 + 2, Enabled = i < 3, Type = i % 2 == 1 ? IOType.NO : IOType.NC, ModuleId =site2.Id };
        // var i3 = new Input { Id = i * 3 + 3, Enabled = i < 1, Type = i % 2 == 0 ? IOType.NO : IOType.NC, ModuleId =site3.Id };
        var o1 = new Output { Id = i * 3 + 1, Enabled = i < 2, Type = i % 2 == 0 ? IOType.NO : IOType.NC, Triggers = new List<TriggerType> { TriggerType.Faults }, ModuleId = site1.Id };
        // var o2 = new Output { Id = i * 3 + 2, Enabled = i < 3, Type = i % 2 == 1 ? IOType.NO : IOType.NC, Triggers = new List<TriggerType> { TriggerType.Input1, TriggerType.Power }, ModuleId =site2.Id };
        // var o3 = new Output { Id = i * 3 + 3, Enabled = i < 1, Type = i % 2 == 0 ? IOType.NO : IOType.NC, Triggers = new List<TriggerType> { TriggerType.Input2, TriggerType.Power }, ModuleId =site3.Id };

        modelBuilder.Entity<Input>().HasData(i1); //, i2, i3);
        modelBuilder.Entity<Output>().HasData(o1); //, o2, o3);
      }
    }
  }
}