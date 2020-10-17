﻿// <auto-generated />
using System;
using Dess.Api.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Dess.Api.Migrations
{
    [DbContext(typeof(DessDbContext))]
    [Migration("20201016082139_EFInitiedWithLatLng")]
    partial class EFInitiedWithLatLng
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Dess.Api.Entities.ElectroFence", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("Applied")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("AutoLocation")
                        .HasColumnType("tinyint(1)");

                    b.Property<double>("BatteryMax")
                        .HasColumnType("double");

                    b.Property<double>("BatteryMin")
                        .HasColumnType("double");

                    b.Property<string>("Hash")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("HvEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("HvPower")
                        .HasColumnType("int");

                    b.Property<int>("HvRepeat")
                        .HasColumnType("int");

                    b.Property<int>("HvThreshold")
                        .HasColumnType("int");

                    b.Property<int>("Interval")
                        .HasColumnType("int");

                    b.Property<string>("Latitude")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Longitude")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("LvEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Serial")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("SerialNo")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("SiteId")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("TemperatureMax")
                        .HasColumnType("int");

                    b.Property<int>("TemperatureMin")
                        .HasColumnType("int");

                    b.Property<bool>("UseGlobalIntervarl")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.ToTable("ElectroFences");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Applied = false,
                            AutoLocation = false,
                            BatteryMax = 0.0,
                            BatteryMin = 0.0,
                            HvEnabled = true,
                            HvPower = 70,
                            HvRepeat = 2,
                            HvThreshold = 3000,
                            Interval = 0,
                            Latitude = "38.0962",
                            Longitude = "46.2738",
                            LvEnabled = true,
                            Name = "Ef1",
                            Serial = "001",
                            SiteId = "ehp-ie-tbz",
                            TemperatureMax = 0,
                            TemperatureMin = 0,
                            UseGlobalIntervarl = false
                        },
                        new
                        {
                            Id = 2,
                            Applied = false,
                            AutoLocation = false,
                            BatteryMax = 0.0,
                            BatteryMin = 0.0,
                            HvEnabled = true,
                            HvPower = 70,
                            HvRepeat = 3,
                            HvThreshold = 4000,
                            Interval = 0,
                            Latitude = "35.6892",
                            Longitude = "51.3890",
                            LvEnabled = false,
                            Name = "Ef2",
                            Serial = "002",
                            SiteId = "ehp-ie-thr",
                            TemperatureMax = 0,
                            TemperatureMin = 0,
                            UseGlobalIntervarl = false
                        },
                        new
                        {
                            Id = 3,
                            Applied = false,
                            AutoLocation = false,
                            BatteryMax = 0.0,
                            BatteryMin = 0.0,
                            HvEnabled = true,
                            HvPower = 80,
                            HvRepeat = 2,
                            HvThreshold = 5000,
                            Interval = 0,
                            Latitude = "32.6539",
                            Longitude = "51.6660",
                            LvEnabled = false,
                            Name = "Ef3",
                            Serial = "003",
                            SiteId = "ehp-ie-isf",
                            TemperatureMax = 0,
                            TemperatureMin = 0,
                            UseGlobalIntervarl = false
                        });
                });

            modelBuilder.Entity("Dess.Api.Entities.ElectroFenceStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<byte>("BatteryLevel")
                        .HasColumnType("tinyint unsigned");

                    b.Property<int>("BatteryStatus")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("ElectroFenceId")
                        .HasColumnType("int");

                    b.Property<int?>("ElectroFenceId1")
                        .HasColumnType("int");

                    b.Property<string>("Hash")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("HvAlarm")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("HvChargeFault")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("HvDischargeFault")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("HvPowerFault")
                        .HasColumnType("tinyint(1)");

                    b.Property<double>("HvVoltage")
                        .HasColumnType("double");

                    b.Property<bool>("Input1")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("Input2")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("IpAddress")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Latitude")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Longitude")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<bool>("LvAlarm")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("MainPowerFault")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("Output1")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("Output2")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("SerialNo")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<byte>("SignalStrength")
                        .HasColumnType("tinyint unsigned");

                    b.Property<bool>("TamperAlarm")
                        .HasColumnType("tinyint(1)");

                    b.Property<double>("Temperature")
                        .HasColumnType("double");

                    b.HasKey("Id");

                    b.HasIndex("ElectroFenceId")
                        .IsUnique();

                    b.HasIndex("ElectroFenceId1");

                    b.ToTable("Logs");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BatteryLevel = (byte)0,
                            BatteryStatus = 0,
                            Date = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ElectroFenceId = 1,
                            HvAlarm = false,
                            HvChargeFault = false,
                            HvDischargeFault = false,
                            HvPowerFault = false,
                            HvVoltage = 0.0,
                            Input1 = false,
                            Input2 = false,
                            LvAlarm = false,
                            MainPowerFault = false,
                            Output1 = false,
                            Output2 = false,
                            SignalStrength = (byte)0,
                            TamperAlarm = false,
                            Temperature = 0.0
                        },
                        new
                        {
                            Id = 2,
                            BatteryLevel = (byte)0,
                            BatteryStatus = 0,
                            Date = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ElectroFenceId = 2,
                            HvAlarm = false,
                            HvChargeFault = false,
                            HvDischargeFault = false,
                            HvPowerFault = false,
                            HvVoltage = 0.0,
                            Input1 = false,
                            Input2 = false,
                            LvAlarm = false,
                            MainPowerFault = false,
                            Output1 = false,
                            Output2 = false,
                            SignalStrength = (byte)0,
                            TamperAlarm = false,
                            Temperature = 0.0
                        },
                        new
                        {
                            Id = 3,
                            BatteryLevel = (byte)0,
                            BatteryStatus = 0,
                            Date = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            ElectroFenceId = 3,
                            HvAlarm = false,
                            HvChargeFault = false,
                            HvDischargeFault = false,
                            HvPowerFault = false,
                            HvVoltage = 0.0,
                            Input1 = false,
                            Input2 = false,
                            LvAlarm = false,
                            MainPowerFault = false,
                            Output1 = false,
                            Output2 = false,
                            SignalStrength = (byte)0,
                            TamperAlarm = false,
                            Temperature = 0.0
                        });
                });

            modelBuilder.Entity("Dess.Api.Entities.IO", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("Enabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("ModuleId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ModuleId");

                    b.ToTable("IOs");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Enabled = true,
                            ModuleId = 1,
                            Type = 0
                        },
                        new
                        {
                            Id = 2,
                            Enabled = true,
                            ModuleId = 2,
                            Type = 1
                        },
                        new
                        {
                            Id = 3,
                            Enabled = true,
                            ModuleId = 3,
                            Type = 0
                        },
                        new
                        {
                            Id = 4,
                            Enabled = true,
                            ModuleId = 1,
                            Type = 1
                        },
                        new
                        {
                            Id = 5,
                            Enabled = true,
                            ModuleId = 2,
                            Type = 0
                        },
                        new
                        {
                            Id = 6,
                            Enabled = false,
                            ModuleId = 3,
                            Type = 1
                        },
                        new
                        {
                            Id = 7,
                            Enabled = false,
                            ModuleId = 1,
                            Type = 0
                        },
                        new
                        {
                            Id = 8,
                            Enabled = true,
                            ModuleId = 2,
                            Type = 1
                        },
                        new
                        {
                            Id = 9,
                            Enabled = false,
                            ModuleId = 3,
                            Type = 0
                        },
                        new
                        {
                            Id = 10,
                            Enabled = false,
                            ModuleId = 1,
                            Type = 1
                        },
                        new
                        {
                            Id = 11,
                            Enabled = false,
                            ModuleId = 2,
                            Type = 0
                        },
                        new
                        {
                            Id = 12,
                            Enabled = false,
                            ModuleId = 3,
                            Type = 1
                        });
                });

            modelBuilder.Entity("Dess.Api.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("GroupId")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FirstName = "Amir",
                            GroupId = 1,
                            LastName = "Fakhim-Babaei",
                            Password = "$2a$11$S6kzQsOmgHqEsY4Rog56Q.k/Jn/buKEkXDzl0iRZyg1KQSdwo7KOC",
                            Username = "expert"
                        },
                        new
                        {
                            Id = 2,
                            FirstName = "Amir",
                            GroupId = 2,
                            LastName = "Fakhim-Babaei",
                            Password = "$2a$11$kZeUu31bgfApeTfisyjjkuSkiK.lLvDlB/KprFY4cqKDoPQkGJHTG",
                            Username = "admin"
                        },
                        new
                        {
                            Id = 3,
                            FirstName = "Amir",
                            GroupId = 3,
                            LastName = "Fakhim-Babaei",
                            Password = "$2a$11$NMMnwzqu46rUc./bJVnJ2eKcNtItT.vYDhBMoqBEre.nfC7evlNza",
                            Username = "operator"
                        });
                });

            modelBuilder.Entity("Dess.Api.Entities.UserGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("UserGroups");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Title = "Almighty"
                        },
                        new
                        {
                            Id = 2,
                            Title = "Expert"
                        },
                        new
                        {
                            Id = 3,
                            Title = "Admin"
                        },
                        new
                        {
                            Id = 4,
                            Title = "Operator"
                        });
                });

            modelBuilder.Entity("Dess.Api.Entities.UserGroupPermission", b =>
                {
                    b.Property<int>("GroupId")
                        .HasColumnType("int");

                    b.Property<int>("PermissionId")
                        .HasColumnType("int");

                    b.HasKey("GroupId", "PermissionId");

                    b.HasIndex("PermissionId");

                    b.ToTable("UserGroupPermissions");

                    b.HasData(
                        new
                        {
                            GroupId = 1,
                            PermissionId = 1
                        },
                        new
                        {
                            GroupId = 1,
                            PermissionId = 2
                        },
                        new
                        {
                            GroupId = 1,
                            PermissionId = 3
                        },
                        new
                        {
                            GroupId = 1,
                            PermissionId = 4
                        },
                        new
                        {
                            GroupId = 1,
                            PermissionId = 5
                        },
                        new
                        {
                            GroupId = 2,
                            PermissionId = 2
                        },
                        new
                        {
                            GroupId = 2,
                            PermissionId = 3
                        },
                        new
                        {
                            GroupId = 2,
                            PermissionId = 4
                        },
                        new
                        {
                            GroupId = 2,
                            PermissionId = 5
                        },
                        new
                        {
                            GroupId = 3,
                            PermissionId = 2
                        },
                        new
                        {
                            GroupId = 3,
                            PermissionId = 3
                        },
                        new
                        {
                            GroupId = 3,
                            PermissionId = 5
                        },
                        new
                        {
                            GroupId = 4,
                            PermissionId = 3
                        });
                });

            modelBuilder.Entity("Dess.Api.Entities.UserLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("LogId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("LogId");

                    b.HasIndex("UserId");

                    b.ToTable("UserLogs");
                });

            modelBuilder.Entity("Dess.Api.Entities.UserPermission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("UserPermissions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Title = "IsAlmighty"
                        },
                        new
                        {
                            Id = 2,
                            Title = "CanSecureSites"
                        },
                        new
                        {
                            Id = 3,
                            Title = "CanEditSites"
                        },
                        new
                        {
                            Id = 4,
                            Title = "CanEditUserGroups"
                        },
                        new
                        {
                            Id = 5,
                            Title = "CanEditUsers"
                        });
                });

            modelBuilder.Entity("Dess.Api.Entities.ElectroFenceStatus", b =>
                {
                    b.HasOne("Dess.Api.Entities.ElectroFence", "ElectroFence")
                        .WithOne("Status")
                        .HasForeignKey("Dess.Api.Entities.ElectroFenceStatus", "ElectroFenceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dess.Api.Entities.ElectroFence", null)
                        .WithMany("Log")
                        .HasForeignKey("ElectroFenceId1");
                });

            modelBuilder.Entity("Dess.Api.Entities.IO", b =>
                {
                    b.HasOne("Dess.Api.Entities.ElectroFence", "Module")
                        .WithMany("IOs")
                        .HasForeignKey("ModuleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Dess.Api.Entities.User", b =>
                {
                    b.HasOne("Dess.Api.Entities.UserGroup", "Group")
                        .WithMany("Users")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Dess.Api.Entities.UserGroupPermission", b =>
                {
                    b.HasOne("Dess.Api.Entities.UserGroup", "Group")
                        .WithMany("UserGroupPermissions")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dess.Api.Entities.UserPermission", "Permission")
                        .WithMany("UserGroupPermissions")
                        .HasForeignKey("PermissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Dess.Api.Entities.UserLog", b =>
                {
                    b.HasOne("Dess.Api.Entities.ElectroFenceStatus", "Log")
                        .WithMany("UserLogs")
                        .HasForeignKey("LogId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dess.Api.Entities.User", "User")
                        .WithMany("UserLogs")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
