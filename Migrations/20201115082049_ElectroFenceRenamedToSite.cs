using System;

using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DESS.Migrations
{
    public partial class ElectroFenceRenamedToSite : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sites",
                columns : table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                        Name = table.Column<string>(nullable: false),
                        SerialNo = table.Column<string>(nullable: false),
                        PhoneNumber = table.Column<string>(nullable: true),
                        Hash = table.Column<string>(nullable: true),
                        Applied = table.Column<bool>(nullable: false),
                        UseGlobalInterval = table.Column<bool>(nullable: false),
                        Interval = table.Column<byte>(nullable: false),
                        Timeout = table.Column<byte>(nullable: false),
                        AutoLocation = table.Column<bool>(nullable: false),
                        Latitude = table.Column<string>(nullable: true),
                        Longitude = table.Column<string>(nullable: true),
                        HvEnabled = table.Column<bool>(nullable: false),
                        LvEnabled = table.Column<bool>(nullable: false),
                        TamperEnabled = table.Column<bool>(nullable: false),
                        HvPower = table.Column<byte>(nullable: false),
                        HvThreshold = table.Column<short>(nullable: false),
                        HvRepeat = table.Column<byte>(nullable: false),
                        TemperatureWarning = table.Column<bool>(nullable: false),
                        TemperatureMin = table.Column<sbyte>(nullable: false),
                        TemperatureMax = table.Column<sbyte>(nullable: false),
                        BatteryWarning = table.Column<bool>(nullable: false),
                        BatteryMin = table.Column<byte>(nullable: false)
                },
                constraints : table =>
                {
                    table.PrimaryKey("PK_Sites", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserGroups",
                columns : table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                        Title = table.Column<string>(nullable: true)
                },
                constraints : table =>
                {
                    table.PrimaryKey("PK_UserGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns : table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                        Title = table.Column<string>(nullable: true)
                },
                constraints : table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Inputs",
                columns : table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                        Name = table.Column<string>(nullable: true),
                        Type = table.Column<int>(nullable: false),
                        Enabled = table.Column<bool>(nullable: false),
                        ModuleId = table.Column<int>(nullable: false),
                        Timer = table.Column<byte>(nullable: false)
                },
                constraints : table =>
                {
                    table.PrimaryKey("PK_Inputs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inputs_Sites_ModuleId",
                        column : x => x.ModuleId,
                        principalTable: "Sites",
                        principalColumn: "Id",
                        onDelete : ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Logs",
                columns : table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                        Type = table.Column<int>(nullable: false),
                        OccuredOn = table.Column<DateTime>(nullable: false),
                        ObviatedOn = table.Column<DateTime>(nullable: false),
                        ResetedOn = table.Column<DateTime>(nullable: false),
                        ResetedBy = table.Column<int>(nullable: false),
                        SiteId = table.Column<int>(nullable: false),
                        SeenBy = table.Column<string>(nullable: true)
                },
                constraints : table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Logs_Sites_SiteId",
                        column : x => x.SiteId,
                        principalTable: "Sites",
                        principalColumn: "Id",
                        onDelete : ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Outputs",
                columns : table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                        Name = table.Column<string>(nullable: true),
                        Type = table.Column<int>(nullable: false),
                        Enabled = table.Column<bool>(nullable: false),
                        ModuleId = table.Column<int>(nullable: false),
                        ResetTime = table.Column<short>(nullable: false),
                        Triggers = table.Column<string>(nullable: true)
                },
                constraints : table =>
                {
                    table.PrimaryKey("PK_Outputs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Outputs_Sites_ModuleId",
                        column : x => x.ModuleId,
                        principalTable: "Sites",
                        principalColumn: "Id",
                        onDelete : ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns : table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                        Date = table.Column<DateTime>(nullable: false),
                        IpAddress = table.Column<string>(nullable: true),
                        SerialNo = table.Column<string>(nullable: true),
                        Hash = table.Column<string>(nullable: true),
                        HvAlarm = table.Column<bool>(nullable: false),
                        LvAlarm = table.Column<bool>(nullable: false),
                        TamperAlarm = table.Column<bool>(nullable: false),
                        MainPowerFault = table.Column<bool>(nullable: false),
                        HvPowerFault = table.Column<bool>(nullable: false),
                        HvChargeFault = table.Column<bool>(nullable: false),
                        HvDischargeFault = table.Column<bool>(nullable: false),
                        HvVoltage = table.Column<short>(nullable: false),
                        Temperature = table.Column<short>(nullable: false),
                        BatteryStatus = table.Column<int>(nullable: false),
                        BatteryLevel = table.Column<byte>(nullable: false),
                        Latitude = table.Column<string>(nullable: true),
                        Longitude = table.Column<string>(nullable: true),
                        SignalStrength = table.Column<byte>(nullable: false),
                        SiteId = table.Column<int>(nullable: false),
                        Inputs = table.Column<string>(nullable: true),
                        Outputs = table.Column<string>(nullable: true)
                },
                constraints : table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Statuses_Sites_SiteId",
                        column : x => x.SiteId,
                        principalTable: "Sites",
                        principalColumn: "Id",
                        onDelete : ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns : table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                        FirstName = table.Column<string>(nullable: false),
                        LastName = table.Column<string>(nullable: false),
                        Username = table.Column<string>(nullable: false),
                        Password = table.Column<string>(nullable: false),
                        GroupId = table.Column<int>(nullable: false)
                },
                constraints : table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_UserGroups_GroupId",
                        column : x => x.GroupId,
                        principalTable: "UserGroups",
                        principalColumn: "Id",
                        onDelete : ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserGroupPermissions",
                columns : table => new
                {
                    GroupId = table.Column<int>(nullable: false),
                        PermissionId = table.Column<int>(nullable: false)
                },
                constraints : table =>
                {
                    table.PrimaryKey("PK_UserGroupPermissions", x => new { x.GroupId, x.PermissionId });
                    table.ForeignKey(
                        name: "FK_UserGroupPermissions_UserGroups_GroupId",
                        column : x => x.GroupId,
                        principalTable: "UserGroups",
                        principalColumn: "Id",
                        onDelete : ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserGroupPermissions_Permissions_PermissionId",
                        column : x => x.PermissionId,
                        principalTable: "Permissions",
                        principalColumn: "Id",
                        onDelete : ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogs",
                columns : table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                        UserId = table.Column<int>(nullable: false),
                        LogId = table.Column<int>(nullable: false)
                },
                constraints : table =>
                {
                    table.PrimaryKey("PK_UserLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserLogs_Logs_LogId",
                        column : x => x.LogId,
                        principalTable: "Logs",
                        principalColumn: "Id",
                        onDelete : ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserLogs_Users_UserId",
                        column : x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete : ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Sites",
                columns : new [] { "Id", "Applied", "AutoLocation", "BatteryMin", "BatteryWarning", "Hash", "HvEnabled", "HvPower", "HvRepeat", "HvThreshold", "Interval", "Latitude", "Longitude", "LvEnabled", "Name", "PhoneNumber", "SerialNo", "TamperEnabled", "TemperatureMax", "TemperatureMin", "TemperatureWarning", "Timeout", "UseGlobalInterval" },
                values : new object[] { 1, false, false, (byte)0, false, null, true, (byte)70, (byte)2, (short)3000, (byte)10, "38.0962", "46.2738", true, "T5011", null, "SC20D3001N", false, (sbyte)0, (sbyte)0, false, (byte)0, false });

            migrationBuilder.InsertData(
                table: "UserGroups",
                columns : new [] { "Id", "Title" },
                values : new object[, ]
                { { 1, "Almighty" }, { 2, "Expert" }, { 3, "Admin" }, { 4, "Operator" }
                });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns : new [] { "Id", "Title" },
                values : new object[, ]
                { { 1, "IsAlmighty" }, { 2, "CanResetFaults" }, { 3, "CanEditSites" }, { 4, "CanEditUserGroups" }, { 5, "CanEditUsers" }
                });

            migrationBuilder.InsertData(
                table: "Inputs",
                columns : new [] { "Id", "Enabled", "ModuleId", "Name", "Timer", "Type" },
                values : new object[, ]
                { { 1, true, 1, null, (byte)0, 0 }, { 4, true, 1, null, (byte)0, 1 }
                });

            migrationBuilder.InsertData(
                table: "Outputs",
                columns : new [] { "Id", "Enabled", "ModuleId", "Name", "ResetTime", "Triggers", "Type" },
                values : new object[, ]
                { { 1, true, 1, null, (short)0, "0", 0 }, { 4, true, 1, null, (short)0, "0", 1 }
                });

            migrationBuilder.InsertData(
                table: "Statuses",
                columns : new [] { "Id", "BatteryLevel", "BatteryStatus", "Date", "Hash", "HvAlarm", "HvChargeFault", "HvDischargeFault", "HvPowerFault", "HvVoltage", "Inputs", "IpAddress", "Latitude", "Longitude", "LvAlarm", "MainPowerFault", "Outputs", "SerialNo", "SignalStrength", "SiteId", "TamperAlarm", "Temperature" },
                values : new object[] { 1, (byte)0, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, false, false, false, (short)0, null, null, null, null, false, false, null, null, (byte)0, 1, false, (short)0 });

            migrationBuilder.InsertData(
                table: "UserGroupPermissions",
                columns : new [] { "GroupId", "PermissionId" },
                values : new object[, ]
                { { 1, 5 }, { 2, 4 }, { 1, 4 }, { 3, 3 }, { 2, 3 }, { 1, 3 }, { 4, 2 }, { 2, 2 }, { 2, 5 }, { 1, 2 }, { 1, 1 }, { 3, 2 }, { 3, 5 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns : new [] { "Id", "FirstName", "GroupId", "LastName", "Password", "Username" },
                values : new object[, ]
                { { 3, "Amir", 3, "Fakhim-Babaei", "$2a$11$a.P3ToHmDquwTSpzNELkx.Us2vShCcEh3Uz0pGZCWs53AZwJLi55S", "operator" }, { 2, "Amir", 2, "Fakhim-Babaei", "$2a$11$oVqN7mxLE15uCbM5kBOvteGYab3/Yic6Ibrzcj28Nf6BeqHD.h1VK", "admin" }, { 1, "Amir", 1, "Fakhim-Babaei", "$2a$11$FtBN2MxIs12/MOj9fjcAm.nslgRY8fPMGe7jFD8O81.WzUSIzPWiS", "expert" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inputs_ModuleId",
                table: "Inputs",
                column: "ModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_Logs_SiteId",
                table: "Logs",
                column: "SiteId");

            migrationBuilder.CreateIndex(
                name: "IX_Outputs_ModuleId",
                table: "Outputs",
                column: "ModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_Statuses_SiteId",
                table: "Statuses",
                column: "SiteId",
                unique : true);

            migrationBuilder.CreateIndex(
                name: "IX_UserGroupPermissions_PermissionId",
                table: "UserGroupPermissions",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogs_LogId",
                table: "UserLogs",
                column: "LogId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLogs_UserId",
                table: "UserLogs",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_GroupId",
                table: "Users",
                column: "GroupId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inputs");

            migrationBuilder.DropTable(
                name: "Outputs");

            migrationBuilder.DropTable(
                name: "Statuses");

            migrationBuilder.DropTable(
                name: "UserGroupPermissions");

            migrationBuilder.DropTable(
                name: "UserLogs");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "Logs");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Sites");

            migrationBuilder.DropTable(
                name: "UserGroups");
        }
    }
}