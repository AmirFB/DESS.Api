﻿using System;
using Dess.Api.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DESS.Migrations
{
    [DbContext(typeof(DessDbContext))]
    partial class DessDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

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

                    b.Property<byte>("Timer")
                        .HasColumnType("tinyint unsigned");

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
                            Timer = (byte)0,
                            Type = 0
                        },
                        new
                        {
                            Id = 4,
                            Enabled = true,
                            ModuleId = 1,
                            Timer = (byte)0,
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
                            Id = 4,
                            Enabled = true,
                            ModuleId = 1,
                            ResetTime = (short)0,
                            Triggers = "0",
                            Type = 1
                        });
                });

            modelBuilder.Entity("Dess.Api.Entities.Permission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("Permissions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Title = "IsAlmighty"
                        },
                        new
                        {
                            Id = 2,
                            Title = "CanSecure"
                        },
                        new
                        {
                            Id = 3,
                            Title = "CanEditSites"
                        },
                        new
                        {
                            Id = 4,
                            Title = "CanAddRemoveSites"
                        },
                        new
                        {
                            Id = 5,
                            Title = "CanHandleSiteGroups"
                        },
                        new
                        {
                            Id = 6,
                            Title = "CanEditUsers"
                        },
                        new
                        {
                            Id = 7,
                            Title = "CanHandleUserGroup"
                        },
                        new
                        {
                            Id = 8,
                            Title = "CanAssignAdmin"
                        });
                });

            modelBuilder.Entity("Dess.Api.Entities.RefreshToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<DateTime>("Expires")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Token")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("RefreshToekns");
                });

            modelBuilder.Entity("Dess.Api.Entities.Site", b =>
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

                    b.Property<int>("GroupId")
                        .HasColumnType("int");

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

                    b.Property<bool>("TamperEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<sbyte>("TemperatureMax")
                        .HasColumnType("tinyint");

                    b.Property<sbyte>("TemperatureMin")
                        .HasColumnType("tinyint");

                    b.Property<bool>("TemperatureWarning")
                        .HasColumnType("tinyint(1)");

                    b.Property<byte>("Timeout")
                        .HasColumnType("tinyint unsigned");

                    b.Property<bool>("UseGlobalInterval")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.ToTable("Sites");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Applied = false,
                            AutoLocation = false,
                            BatteryMin = (byte)0,
                            BatteryWarning = false,
                            GroupId = 1,
                            HvEnabled = true,
                            HvPower = (byte)70,
                            HvRepeat = (byte)2,
                            HvThreshold = (short)3000,
                            Interval = (byte)10,
                            Latitude = "38.0962",
                            Longitude = "46.2738",
                            LvEnabled = true,
                            Name = "T5011",
                            SerialNo = "SC20D3001N",
                            TamperEnabled = false,
                            TemperatureMax = (sbyte)0,
                            TemperatureMin = (sbyte)0,
                            TemperatureWarning = false,
                            Timeout = (byte)0,
                            UseGlobalInterval = false
                        });
                });

            modelBuilder.Entity("Dess.Api.Entities.SiteFault", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("ObviatedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime>("OccuredOn")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("ResetedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("ResetedOn")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("SeenBy")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("SiteId")
                        .HasColumnType("int");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SiteId");

                    b.ToTable("Logs");
                });

            modelBuilder.Entity("Dess.Api.Entities.SiteGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Province")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("SiteGroups");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "R8"
                        });
                });

            modelBuilder.Entity("Dess.Api.Entities.SiteGroupUser", b =>
                {
                    b.Property<int>("GroupId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("GroupId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("SiteGroupUser");
                });

            modelBuilder.Entity("Dess.Api.Entities.SiteStatus", b =>
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

                    b.Property<string>("Inputs")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

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

                    b.Property<string>("Outputs")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("SerialNo")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<byte>("SignalStrength")
                        .HasColumnType("tinyint unsigned");

                    b.Property<int>("SiteId")
                        .HasColumnType("int");

                    b.Property<bool>("TamperAlarm")
                        .HasColumnType("tinyint(1)");

                    b.Property<short>("Temperature")
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    b.HasIndex("SiteId")
                        .IsUnique();

                    b.ToTable("Statuses");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BatteryLevel = (byte)0,
                            BatteryStatus = 0,
                            Date = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            HvAlarm = false,
                            HvChargeFault = false,
                            HvDischargeFault = false,
                            HvPowerFault = false,
                            HvVoltage = (short)0,
                            LvAlarm = false,
                            MainPowerFault = false,
                            SignalStrength = (byte)0,
                            SiteId = 1,
                            TamperAlarm = false,
                            Temperature = (short)0
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

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int?>("SiteGroupId")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.HasIndex("SiteGroupId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            FirstName = "Amir",
                            GroupId = 1,
                            LastName = "Fakhim-Babaei",
                            Password = "$2a$11$3SD1ASw5uWqlIHmqbHhAyOYCvFskJvFEPzcl8Ft5.PsKlDgenmPZm",
                            Username = "almighty"
                        },
                        new
                        {
                            Id = 2,
                            FirstName = "Amir",
                            GroupId = 2,
                            LastName = "Chegini",
                            Password = "$2a$11$wE1bGZRWyBt6lr.SMIWeweZ6AhPTvAGRdl4kYFZdabEguKt2r6q4.",
                            Username = "manager"
                        },
                        new
                        {
                            Id = 3,
                            FirstName = "No",
                            GroupId = 3,
                            LastName = "One",
                            Password = "$2a$11$48aJEhT9gEpt3eV8TnmAyOKiAGflH4mSZAuH0MRa5q9lWUKKfQ/1C",
                            Username = "admin"
                        },
                        new
                        {
                            Id = 4,
                            FirstName = "Not",
                            GroupId = 4,
                            LastName = "Yet",
                            Password = "$2a$11$Mgze.LiwtE/rMz4kHepJ8e8GRsHc.iolbZs369Ml9qt.PKw4BrBkm",
                            Username = "operator"
                        });
                });

            modelBuilder.Entity("Dess.Api.Entities.UserGroup", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("PermissionIds")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Title")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("UserGroups");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            PermissionIds = "1;2;3;4;5;6;7;8",
                            Title = "Almighty"
                        },
                        new
                        {
                            Id = 2,
                            PermissionIds = "2;3;4;5;6;7;8",
                            Title = "Manager"
                        },
                        new
                        {
                            Id = 3,
                            PermissionIds = "2;3;6",
                            Title = "Admin"
                        },
                        new
                        {
                            Id = 4,
                            PermissionIds = "",
                            Title = "Operator"
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

            modelBuilder.Entity("Dess.Api.Entities.Input", b =>
                {
                    b.HasOne("Dess.Api.Entities.Site", "Module")
                        .WithMany("Inputs")
                        .HasForeignKey("ModuleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Dess.Api.Entities.Output", b =>
                {
                    b.HasOne("Dess.Api.Entities.Site", "Module")
                        .WithMany("Outputs")
                        .HasForeignKey("ModuleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Dess.Api.Entities.RefreshToken", b =>
                {
                    b.HasOne("Dess.Api.Entities.User", null)
                        .WithMany("RefreshTokens")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Dess.Api.Entities.Site", b =>
                {
                    b.HasOne("Dess.Api.Entities.SiteGroup", "Group")
                        .WithMany("Sites")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Dess.Api.Entities.SiteFault", b =>
                {
                    b.HasOne("Dess.Api.Entities.Site", "Site")
                        .WithMany("Log")
                        .HasForeignKey("SiteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Dess.Api.Entities.SiteGroupUser", b =>
                {
                    b.HasOne("Dess.Api.Entities.SiteGroup", "Group")
                        .WithMany("Users")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Dess.Api.Entities.User", "User")
                        .WithMany("SiteGroups")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Dess.Api.Entities.SiteStatus", b =>
                {
                    b.HasOne("Dess.Api.Entities.Site", null)
                        .WithOne("Status")
                        .HasForeignKey("Dess.Api.Entities.SiteStatus", "SiteId")
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

                    b.HasOne("Dess.Api.Entities.SiteGroup", null)
                        .WithMany("ReportTo")
                        .HasForeignKey("SiteGroupId");
                });

            modelBuilder.Entity("Dess.Api.Entities.UserLog", b =>
                {
                    b.HasOne("Dess.Api.Entities.SiteFault", "Log")
                        .WithMany()
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
