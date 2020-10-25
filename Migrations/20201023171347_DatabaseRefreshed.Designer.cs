﻿// <auto-generated />
using System;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

using Dess.Api.DbContexts;

namespace DESS.Migrations
{
    [DbContext(typeof(DessDbContext))]
    [Migration("20201023171347_DatabaseRefreshed")]
    partial class DatabaseRefreshed
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

                b.Property<byte>("BatteryMin")
                    .HasColumnType("tinyint unsigned");

                b.Property<bool>("BatteryWarning")
                    .HasColumnType("tinyint(1)");

                b.Property<string>("Hash")
                    .HasColumnType("longtext CHARACTER SET utf8mb4");

                b.Property<bool>("HvEnabled")
                    .HasColumnType("tinyint(1)");

                b.Property<byte>("HvPower")
                    .HasColumnType("tinyint unsigned");

                b.Property<byte>("HvRepeat")
                    .HasColumnType("tinyint unsigned");

                b.Property<short>("HvThreshold")
                    .HasColumnType("smallint");

                b.Property<byte>("Interval")
                    .HasColumnType("tinyint unsigned");

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

                b.Property<string>("SerialNo")
                    .IsRequired()
                    .HasColumnType("longtext CHARACTER SET utf8mb4");

                b.Property<string>("SiteId")
                    .IsRequired()
                    .HasColumnType("longtext CHARACTER SET utf8mb4");

                b.Property<bool>("TamperEnabled")
                    .HasColumnType("tinyint(1)");

                b.Property<sbyte>("TemperatureMax")
                    .HasColumnType("tinyint");

                b.Property<sbyte>("TemperatureMin")
                    .HasColumnType("tinyint");

                b.Property<bool>("TemperatureWarning")
                    .HasColumnType("tinyint(1)");

                b.Property<bool>("UseGlobalInterval")
                    .HasColumnType("tinyint(1)");

                b.HasKey("Id");

                b.ToTable("ElectroFences");

                b.HasData(
                    new
                    {
                        Id = 1,
                            Applied = false,
                            AutoLocation = false,
                            BatteryMin = (byte)0,
                            BatteryWarning = false,
                            HvEnabled = true,
                            HvPower = (byte)70,
                            HvRepeat = (byte)2,
                            HvThreshold = (short)3000,
                            Interval = (byte)10,
                            Latitude = "38.0962",
                            Longitude = "46.2738",
                            LvEnabled = true,
                            Name = "Ef1",
                            SerialNo = "001",
                            SiteId = "ehp-ie-tbz",
                            TamperEnabled = false,
                            TemperatureMax = (sbyte)0,
                            TemperatureMin = (sbyte)0,
                            TemperatureWarning = false,
                            UseGlobalInterval = false
                    },
                    new
                    {
                        Id = 2,
                            Applied = false,
                            AutoLocation = false,
                            BatteryMin = (byte)0,
                            BatteryWarning = false,
                            HvEnabled = true,
                            HvPower = (byte)70,
                            HvRepeat = (byte)3,
                            HvThreshold = (short)4000,
                            Interval = (byte)15,
                            Latitude = "35.6892",
                            Longitude = "51.3890",
                            LvEnabled = false,
                            Name = "Ef2",
                            SerialNo = "002",
                            SiteId = "ehp-ie-thr",
                            TamperEnabled = false,
                            TemperatureMax = (sbyte)0,
                            TemperatureMin = (sbyte)0,
                            TemperatureWarning = false,
                            UseGlobalInterval = false
                    },
                    new
                    {
                        Id = 3,
                            Applied = false,
                            AutoLocation = false,
                            BatteryMin = (byte)0,
                            BatteryWarning = false,
                            HvEnabled = true,
                            HvPower = (byte)80,
                            HvRepeat = (byte)2,
                            HvThreshold = (short)5000,
                            Interval = (byte)20,
                            Latitude = "32.6539",
                            Longitude = "51.6660",
                            LvEnabled = false,
                            Name = "Ef3",
                            SerialNo = "003",
                            SiteId = "ehp-ie-isf",
                            TamperEnabled = false,
                            TemperatureMax = (sbyte)0,
                            TemperatureMin = (sbyte)0,
                            TemperatureWarning = false,
                            UseGlobalInterval = false
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

                b.Property<short>("HvVoltage")
                    .HasColumnType("smallint");

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

                b.Property<short>("Temperature")
                    .HasColumnType("smallint");

                b.HasKey("Id");

                b.HasIndex("ElectroFenceId");

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
                            HvVoltage = (short)0,
                            Input1 = false,
                            Input2 = false,
                            LvAlarm = false,
                            MainPowerFault = false,
                            Output1 = false,
                            Output2 = false,
                            SignalStrength = (byte)0,
                            TamperAlarm = false,
                            Temperature = (short)0
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
                            HvVoltage = (short)0,
                            Input1 = false,
                            Input2 = false,
                            LvAlarm = false,
                            MainPowerFault = false,
                            Output1 = false,
                            Output2 = false,
                            SignalStrength = (byte)0,
                            TamperAlarm = false,
                            Temperature = (short)0
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
                            HvVoltage = (short)0,
                            Input1 = false,
                            Input2 = false,
                            LvAlarm = false,
                            MainPowerFault = false,
                            Output1 = false,
                            Output2 = false,
                            SignalStrength = (byte)0,
                            TamperAlarm = false,
                            Temperature = (short)0
                    });
            });

            modelBuilder.Entity("Dess.Api.Entities.Input", b =>
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

                b.ToTable("Inputs");

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
                    });
            });

            modelBuilder.Entity("Dess.Api.Entities.Output", b =>
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

                b.Property<short>("ResetTime")
                    .HasColumnType("smallint");

                b.Property<string>("Triggers")
                    .HasColumnType("longtext CHARACTER SET utf8mb4");

                b.Property<int>("Type")
                    .HasColumnType("int");

                b.HasKey("Id");

                b.HasIndex("ModuleId");

                b.ToTable("Outputs");

                b.HasData(
                    new
                    {
                        Id = 1,
                            Enabled = true,
                            ModuleId = 1,
                            ResetTime = (short)0,
                            Triggers = "0",
                            Type = 0
                    },
                    new
                    {
                        Id = 2,
                            Enabled = true,
                            ModuleId = 2,
                            ResetTime = (short)0,
                            Triggers = "1;3",
                            Type = 1
                    },
                    new
                    {
                        Id = 3,
                            Enabled = true,
                            ModuleId = 3,
                            ResetTime = (short)0,
                            Triggers = "2;3",
                            Type = 0
                    },
                    new
                    {
                        Id = 4,
                            Enabled = true,
                            ModuleId = 1,
                            ResetTime = (short)0,
                            Triggers = "0",
                            Type = 1
                    },
                    new
                    {
                        Id = 5,
                            Enabled = true,
                            ModuleId = 2,
                            ResetTime = (short)0,
                            Triggers = "1;3",
                            Type = 0
                    },
                    new
                    {
                        Id = 6,
                            Enabled = false,
                            ModuleId = 3,
                            ResetTime = (short)0,
                            Triggers = "2;3",
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
                            Password = "$2a$11$oqiP/XA3NCo5.pcOes9CRehzHB0ffjCgOSsitxdUZxQPRikLClTHW",
                            Username = "expert"
                    },
                    new
                    {
                        Id = 2,
                            FirstName = "Amir",
                            GroupId = 2,
                            LastName = "Fakhim-Babaei",
                            Password = "$2a$11$0yUOIvyraoC/YaFk4ip0z.zTolIaddmW4iXS8xdp4/lOZxGNNIssa",
                            Username = "admin"
                    },
                    new
                    {
                        Id = 3,
                            FirstName = "Amir",
                            GroupId = 3,
                            LastName = "Fakhim-Babaei",
                            Password = "$2a$11$8deZ26oYOfYxkyse6SXgV.ZMpYrSzC6Tp38zxz7YCSaaDWn6C2LRS",
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
                            PermissionId = 2
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
                            Title = "CanResetFaults"
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
                    .WithMany("Log")
                    .HasForeignKey("ElectroFenceId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });

            modelBuilder.Entity("Dess.Api.Entities.Input", b =>
            {
                b.HasOne("Dess.Api.Entities.ElectroFence", "Module")
                    .WithMany("Inputs")
                    .HasForeignKey("ModuleId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });

            modelBuilder.Entity("Dess.Api.Entities.Output", b =>
            {
                b.HasOne("Dess.Api.Entities.ElectroFence", "Module")
                    .WithMany("Outputs")
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