﻿// <auto-generated />
using System;
using Dess.Api.DbContexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DESS.Migrations
{
    [DbContext(typeof(DessDbContext))]
    [Migration("20200818125538_InitialDatabase")]
    partial class InitialDatabase
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7")
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

                    b.Property<bool>("LvEnabled")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Serial")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("ElectroFences");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Applied = false,
                            AutoLocation = false,
                            HvEnabled = true,
                            HvPower = 70,
                            HvRepeat = 2,
                            HvThreshold = 3000,
                            LvEnabled = true,
                            Serial = "ehp-ie-tbz1"
                        },
                        new
                        {
                            Id = 2,
                            Applied = false,
                            AutoLocation = false,
                            HvEnabled = true,
                            HvPower = 70,
                            HvRepeat = 3,
                            HvThreshold = 4000,
                            LvEnabled = false,
                            Serial = "ehp-ie-tbz2"
                        },
                        new
                        {
                            Id = 3,
                            Applied = false,
                            AutoLocation = false,
                            HvEnabled = true,
                            HvPower = 80,
                            HvRepeat = 2,
                            HvThreshold = 5000,
                            LvEnabled = false,
                            Serial = "ehp-ie-tbz3"
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

                    b.ToTable("Statuss");

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
                        .WithMany()
                        .HasForeignKey("ModuleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
