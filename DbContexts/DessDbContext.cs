using System;
using System.Collections.Generic;
using System.Linq;

using AutoMapper;

using Dess.Api.Entities;
using Dess.Api.Helpers;
using Dess.Api.Types;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Dess.Api.DbContexts
{
  public class DessDbContext : DbContext
  {
    private IMapper _mapper;

    public DessDbContext(DbContextOptions<DessDbContext> options, IMapper mapper) : base(options) =>
      _mapper = mapper;

    public DbSet<ElectroFence> ElectroFences { get; set; }
    public DbSet<ElectroFenceStatus> Statuses { get; set; }
    public DbSet<ElectroFenceFault> Logs { get; set; }
    public DbSet<Input> Inputs { get; set; }
    public DbSet<Output> Outputs { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserLog> UserLogs { get; set; }
    public DbSet<UserGroup> UserGroups { get; set; }
    public DbSet<UserPermission> UserPermissions { get; set; }
    public DbSet<UserGroupPermission> UserGroupPermissions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      base.OnModelCreating(modelBuilder);

      modelBuilder.Entity<ElectroFence>()
        .HasMany(e => e.Log)
        .WithOne()
        .HasForeignKey(l => l.ElectroFenceId);

      modelBuilder.Entity<ElectroFence>()
        .HasMany(e => e.Inputs)
        .WithOne(i => i.Module)
        .HasForeignKey(i => i.ModuleId);

      modelBuilder.Entity<ElectroFence>()
        .HasMany(e => e.Outputs)
        .WithOne(o => o.Module)
        .HasForeignKey(o => o.ModuleId);

      var converterTrigger = new ValueConverter<ICollection<TriggerType>, string>(
          t => string.Join(";", t.ToList().ConvertAll(t => (int) t)),
          t => t.Split(";", StringSplitOptions.RemoveEmptyEntries).Select(val => (TriggerType) int.Parse(val)).ToList());

      modelBuilder.Entity<Output>()
        .Property(e => e.Triggers)
        .HasConversion(converterTrigger);

      var converterFault = new ValueConverter<ICollection<int>, string>(
          u => string.Join(";", u.ToList().ConvertAll(u => u)),
          u => u.Split(";", StringSplitOptions.RemoveEmptyEntries).Select(val => int.Parse(val)).ToList());

      modelBuilder.Entity<ElectroFenceFault>()
        .Property(e => e.SeenBy)
        .HasConversion(converterFault);

      var converterIo = new ValueConverter<IList<bool>, string>(
          u => string.Join(";", u.ToList().ConvertAll(u => u)),
          u => u.Split(";", StringSplitOptions.RemoveEmptyEntries).Select(val => bool.Parse(val)).ToList());

      modelBuilder.Entity<ElectroFenceStatus>()
        .Property(e => e.Inputs)
        .HasConversion(converterIo);

      modelBuilder.Entity<ElectroFenceStatus>()
        .Property(e => e.Outputs)
        .HasConversion(converterIo);

      modelBuilder.Entity<UserLog>()
        .HasOne(u => u.User)
        .WithMany(u => u.UserLogs)
        .HasForeignKey(u => u.UserId);

      // modelBuilder.Entity<UserLog>()
      //   .HasOne(u => u.Log)
      //   .WithMany(l => l.UserLogs)
      //   .HasForeignKey(u => u.LogId);

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

      var allMighty = new UserGroup { Id = 1, Title = "Almighty" };
      var expert = new UserGroup { Id = 2, Title = "Expert" };
      var admin = new UserGroup { Id = 3, Title = "Admin" };
      var operate = new UserGroup { Id = 4, Title = "Operator" };

      var groups = new UserGroup[] { allMighty, expert, admin, operate };
      modelBuilder.Entity<UserGroup>().HasData(groups);

      var isAlmighty = new UserPermission { Id = 1, Title = "IsAlmighty" };
      var canSecureSites = new UserPermission { Id = 2, Title = "CanResetFaults" };
      var canEditSites = new UserPermission { Id = 3, Title = "CanEditSites" };
      var canEditUserGroup = new UserPermission { Id = 4, Title = "CanEditUserGroups" };
      var canEditUsers = new UserPermission { Id = 5, Title = "CanEditUsers" };

      var permissions = new UserPermission[] { isAlmighty, canSecureSites, canEditSites, canEditUserGroup, canEditUsers };
      modelBuilder.Entity<UserPermission>().HasData(permissions);

      var groupPermissions = new UserGroupPermission[]
      {
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

        new UserGroupPermission { GroupId = operate.Id, PermissionId = canSecureSites.Id }
      };
      modelBuilder.Entity<UserGroupPermission>().HasData(groupPermissions);

      var users = new User[]
      {
        new User { Id = 1, Username = "expert", Password = Cryptography.GeneratePasswordHash(Cryptography.GenerateHashSHA256String("expert")), FirstName = "Amir", LastName = "Fakhim-Babaei", GroupId = 1 },
        new User { Id = 2, Username = "admin", Password = Cryptography.GeneratePasswordHash(Cryptography.GenerateHashSHA256String("admin")), FirstName = "Amir", LastName = "Fakhim-Babaei", GroupId = 2 },
        new User { Id = 3, Username = "operator", Password = Cryptography.GeneratePasswordHash(Cryptography.GenerateHashSHA256String("operator")), FirstName = "Amir", LastName = "Fakhim-Babaei", GroupId = 3 }
      };
      modelBuilder.Entity<User>().HasData(users);

      var ef1 = new ElectroFence { Id = 1, Name = "Ef1", SiteId = "T5011", SerialNo = "SC20N3001N", Interval = 10, HvEnabled = true, LvEnabled = true, HvPower = 70, HvRepeat = 2, HvThreshold = 3000, Latitude = "38.0962", Longitude = "46.2738" };
      // var ef2 = new ElectroFence { Id = 2, Name = "Ef2", SiteId = "ehp-ie-thr", SerialNo = "002", Interval = 15, HvEnabled = true, LvEnabled = false, HvPower = 70, HvRepeat = 3, HvThreshold = 4000, Latitude = "35.6892", Longitude = "51.3890" };
      // var ef3 = new ElectroFence { Id = 3, Name = "Ef3", SiteId = "ehp-ie-isf", SerialNo = "003", Interval = 20, HvEnabled = true, LvEnabled = false, HvPower = 80, HvRepeat = 2, HvThreshold = 5000, Latitude = "32.6539", Longitude = "51.6660" };

      var status1 = new ElectroFenceStatus { Id = 1, ElectroFenceId = 1 };
      // var status2 = new ElectroFenceStatus { Id = 2, ElectroFenceId = 2 };
      // var status3 = new ElectroFenceStatus { Id = 3, ElectroFenceId = 3 };

      modelBuilder.Entity<ElectroFence>().HasData(ef1); //, ef2, ef3);
      modelBuilder.Entity<ElectroFenceStatus>().HasData(status1); //, status2, status3);

      for (int i = 0; i < 2; i++)
      {
        var i1 = new Input { Id = i * 3 + 1, Enabled = i < 2, Type = i % 2 == 0 ? IOType.NO : IOType.NC, ModuleId = ef1.Id };
        // var i2 = new Input { Id = i * 3 + 2, Enabled = i < 3, Type = i % 2 == 1 ? IOType.NO : IOType.NC, ModuleId = ef2.Id };
        // var i3 = new Input { Id = i * 3 + 3, Enabled = i < 1, Type = i % 2 == 0 ? IOType.NO : IOType.NC, ModuleId = ef3.Id };
        var o1 = new Output { Id = i * 3 + 1, Enabled = i < 2, Type = i % 2 == 0 ? IOType.NO : IOType.NC, Triggers = new List<TriggerType> { TriggerType.Faults }, ModuleId = ef1.Id };
        // var o2 = new Output { Id = i * 3 + 2, Enabled = i < 3, Type = i % 2 == 1 ? IOType.NO : IOType.NC, Triggers = new List<TriggerType> { TriggerType.Input1, TriggerType.Power }, ModuleId = ef2.Id };
        // var o3 = new Output { Id = i * 3 + 3, Enabled = i < 1, Type = i % 2 == 0 ? IOType.NO : IOType.NC, Triggers = new List<TriggerType> { TriggerType.Input2, TriggerType.Power }, ModuleId = ef3.Id };

        modelBuilder.Entity<Input>().HasData(i1); //, i2, i3);
        modelBuilder.Entity<Output>().HasData(o1); //, o2, o3);
      }
    }
  }
}