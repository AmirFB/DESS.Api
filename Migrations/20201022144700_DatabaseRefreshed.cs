using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DESS.Migrations
{
    public partial class DatabaseRefreshed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ElectroFences",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    SiteId = table.Column<string>(nullable: false),
                    SerialNo = table.Column<string>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Hash = table.Column<string>(nullable: true),
                    Applied = table.Column<bool>(nullable: false),
                    UseGlobalInterval = table.Column<bool>(nullable: false),
                    Interval = table.Column<byte>(nullable: false),
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
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElectroFences", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserGroups",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserPermissions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPermissions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Inputs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false),
                    Enabled = table.Column<bool>(nullable: false),
                    ModuleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inputs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Inputs_ElectroFences_ModuleId",
                        column: x => x.ModuleId,
                        principalTable: "ElectroFences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    Hash = table.Column<string>(nullable: true),
                    IpAddress = table.Column<string>(nullable: true),
                    SerialNo = table.Column<string>(nullable: true),
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
                    Input1 = table.Column<bool>(nullable: false),
                    Input2 = table.Column<bool>(nullable: false),
                    Output1 = table.Column<bool>(nullable: false),
                    Output2 = table.Column<bool>(nullable: false),
                    Latitude = table.Column<string>(nullable: true),
                    Longitude = table.Column<string>(nullable: true),
                    SignalStrength = table.Column<byte>(nullable: false),
                    ElectroFenceId = table.Column<int>(nullable: false),
                    ElectroFenceId1 = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Logs_ElectroFences_ElectroFenceId",
                        column: x => x.ElectroFenceId,
                        principalTable: "ElectroFences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Logs_ElectroFences_ElectroFenceId1",
                        column: x => x.ElectroFenceId1,
                        principalTable: "ElectroFences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Outputs",
                columns: table => new
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
                constraints: table =>
                {
                    table.PrimaryKey("PK_Outputs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Outputs_ElectroFences_ModuleId",
                        column: x => x.ModuleId,
                        principalTable: "ElectroFences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    Username = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    GroupId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_UserGroups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "UserGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserGroupPermissions",
                columns: table => new
                {
                    GroupId = table.Column<int>(nullable: false),
                    PermissionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserGroupPermissions", x => new { x.GroupId, x.PermissionId });
                    table.ForeignKey(
                        name: "FK_UserGroupPermissions_UserGroups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "UserGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserGroupPermissions_UserPermissions_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "UserPermissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserLogs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(nullable: false),
                    LogId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserLogs_Logs_LogId",
                        column: x => x.LogId,
                        principalTable: "Logs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserLogs_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ElectroFences",
                columns: new[] { "Id", "Applied", "AutoLocation", "BatteryMin", "BatteryWarning", "Hash", "HvEnabled", "HvPower", "HvRepeat", "HvThreshold", "Interval", "Latitude", "Longitude", "LvEnabled", "Name", "PhoneNumber", "SerialNo", "SiteId", "TamperEnabled", "TemperatureMax", "TemperatureMin", "TemperatureWarning", "UseGlobalInterval" },
                values: new object[,]
                {
                    { 1, false, false, (byte)0, false, null, true, (byte)70, (byte)2, (short)3000, (byte)10, "38.0962", "46.2738", true, "Ef1", null, "001", "ehp-ie-tbz", false, (sbyte)0, (sbyte)0, false, false },
                    { 2, false, false, (byte)0, false, null, true, (byte)70, (byte)3, (short)4000, (byte)15, "35.6892", "51.3890", false, "Ef2", null, "002", "ehp-ie-thr", false, (sbyte)0, (sbyte)0, false, false },
                    { 3, false, false, (byte)0, false, null, true, (byte)80, (byte)2, (short)5000, (byte)20, "32.6539", "51.6660", false, "Ef3", null, "003", "ehp-ie-isf", false, (sbyte)0, (sbyte)0, false, false }
                });

            migrationBuilder.InsertData(
                table: "UserGroups",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 1, "Almighty" },
                    { 2, "Expert" },
                    { 3, "Admin" },
                    { 4, "Operator" }
                });

            migrationBuilder.InsertData(
                table: "UserPermissions",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 1, "IsAlmighty" },
                    { 2, "CanSecureSites" },
                    { 3, "CanEditSites" },
                    { 4, "CanEditUserGroups" },
                    { 5, "CanEditUsers" }
                });

            migrationBuilder.InsertData(
                table: "Inputs",
                columns: new[] { "Id", "Enabled", "ModuleId", "Name", "Type" },
                values: new object[,]
                {
                    { 1, true, 1, null, 0 },
                    { 4, true, 1, null, 1 },
                    { 6, false, 3, null, 1 },
                    { 3, true, 3, null, 0 },
                    { 5, true, 2, null, 0 },
                    { 2, true, 2, null, 1 }
                });

            migrationBuilder.InsertData(
                table: "Logs",
                columns: new[] { "Id", "BatteryLevel", "BatteryStatus", "Date", "ElectroFenceId", "ElectroFenceId1", "Hash", "HvAlarm", "HvChargeFault", "HvDischargeFault", "HvPowerFault", "HvVoltage", "Input1", "Input2", "IpAddress", "Latitude", "Longitude", "LvAlarm", "MainPowerFault", "Output1", "Output2", "SerialNo", "SignalStrength", "TamperAlarm", "Temperature" },
                values: new object[,]
                {
                    { 1, (byte)0, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, false, false, false, false, (short)0, false, false, null, null, null, false, false, false, false, null, (byte)0, false, (short)0 },
                    { 3, (byte)0, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, null, null, false, false, false, false, (short)0, false, false, null, null, null, false, false, false, false, null, (byte)0, false, (short)0 },
                    { 2, (byte)0, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null, null, false, false, false, false, (short)0, false, false, null, null, null, false, false, false, false, null, (byte)0, false, (short)0 }
                });

            migrationBuilder.InsertData(
                table: "Outputs",
                columns: new[] { "Id", "Enabled", "ModuleId", "Name", "ResetTime", "Triggers", "Type" },
                values: new object[,]
                {
                    { 2, true, 2, null, (short)0, "1;3", 1 },
                    { 5, true, 2, null, (short)0, "1;3", 0 },
                    { 4, true, 1, null, (short)0, "0", 1 },
                    { 1, true, 1, null, (short)0, "0", 0 },
                    { 3, true, 3, null, (short)0, "2;3", 0 },
                    { 6, false, 3, null, (short)0, "2;3", 1 }
                });

            migrationBuilder.InsertData(
                table: "UserGroupPermissions",
                columns: new[] { "GroupId", "PermissionId" },
                values: new object[,]
                {
                    { 2, 3 },
                    { 1, 5 },
                    { 2, 4 },
                    { 1, 4 },
                    { 4, 3 },
                    { 3, 3 },
                    { 1, 3 },
                    { 3, 5 },
                    { 2, 2 },
                    { 1, 2 },
                    { 1, 1 },
                    { 2, 5 },
                    { 3, 2 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FirstName", "GroupId", "LastName", "Password", "Username" },
                values: new object[,]
                {
                    { 3, "Amir", 3, "Fakhim-Babaei", "$2a$11$dBNDCQYKmRO6VifdjSaLXuRSPu4O0mMNT8RIGfvgwlg8mGtjNgEse", "operator" },
                    { 2, "Amir", 2, "Fakhim-Babaei", "$2a$11$SKPH5iEiESXbIKGq19Vtie23aCjBMP2ztF5iFYicU00NC11kL.OUi", "admin" },
                    { 1, "Amir", 1, "Fakhim-Babaei", "$2a$11$syodHRO7/bsFxdWreT0Vg.xBbbbcN7E2qQLMl/I4XlLbGApSH2gby", "expert" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Inputs_ModuleId",
                table: "Inputs",
                column: "ModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_Logs_ElectroFenceId",
                table: "Logs",
                column: "ElectroFenceId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Logs_ElectroFenceId1",
                table: "Logs",
                column: "ElectroFenceId1");

            migrationBuilder.CreateIndex(
                name: "IX_Outputs_ModuleId",
                table: "Outputs",
                column: "ModuleId");

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
                name: "UserGroupPermissions");

            migrationBuilder.DropTable(
                name: "UserLogs");

            migrationBuilder.DropTable(
                name: "UserPermissions");

            migrationBuilder.DropTable(
                name: "Logs");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "ElectroFences");

            migrationBuilder.DropTable(
                name: "UserGroups");
        }
    }
}
