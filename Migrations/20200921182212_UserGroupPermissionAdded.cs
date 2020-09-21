using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DESS.Migrations
{
    public partial class UserGroupPermissionAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ElectroFences",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Serial = table.Column<string>(nullable: false),
                    PhoneNumber = table.Column<string>(nullable: true),
                    Hash = table.Column<string>(nullable: true),
                    Applied = table.Column<bool>(nullable: false),
                    AutoLocation = table.Column<bool>(nullable: false),
                    Latitude = table.Column<string>(nullable: true),
                    Longitude = table.Column<string>(nullable: true),
                    HvEnabled = table.Column<bool>(nullable: false),
                    LvEnabled = table.Column<bool>(nullable: false),
                    HvPower = table.Column<int>(nullable: false),
                    HvThreshold = table.Column<int>(nullable: false),
                    HvRepeat = table.Column<int>(nullable: false),
                    TemperatureMin = table.Column<int>(nullable: false),
                    TemperatureMax = table.Column<int>(nullable: false),
                    BatteryMin = table.Column<double>(nullable: false),
                    BatteryMax = table.Column<double>(nullable: false)
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
                name: "IOs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<int>(nullable: false),
                    Enabled = table.Column<bool>(nullable: false),
                    ModuleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IOs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IOs_ElectroFences_ModuleId",
                        column: x => x.ModuleId,
                        principalTable: "ElectroFences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Statuss",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    Hash = table.Column<string>(nullable: true),
                    HvAlarm = table.Column<bool>(nullable: false),
                    LvAlarm = table.Column<bool>(nullable: false),
                    TamperAlarm = table.Column<bool>(nullable: false),
                    MainPowerFault = table.Column<bool>(nullable: false),
                    HvPowerFault = table.Column<bool>(nullable: false),
                    HvChargeFault = table.Column<bool>(nullable: false),
                    HvDischargeFault = table.Column<bool>(nullable: false),
                    HvVoltage = table.Column<double>(nullable: false),
                    Temperature = table.Column<double>(nullable: false),
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
                    table.PrimaryKey("PK_Statuss", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Statuss_ElectroFences_ElectroFenceId",
                        column: x => x.ElectroFenceId,
                        principalTable: "ElectroFences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Statuss_ElectroFences_ElectroFenceId1",
                        column: x => x.ElectroFenceId1,
                        principalTable: "ElectroFences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
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
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_UserGroupPermissions_UserPermissions_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "UserPermissions",
                        principalColumn: "Id");
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
                        name: "FK_UserLogs_Statuss_LogId",
                        column: x => x.LogId,
                        principalTable: "Statuss",
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
                columns: new[] { "Id", "Applied", "AutoLocation", "BatteryMax", "BatteryMin", "Hash", "HvEnabled", "HvPower", "HvRepeat", "HvThreshold", "Latitude", "Longitude", "LvEnabled", "PhoneNumber", "Serial", "TemperatureMax", "TemperatureMin" },
                values: new object[,]
                {
                    { 1, false, false, 0.0, 0.0, null, true, 70, 2, 3000, null, null, true, null, "ehp-ie-tbz1", 0, 0 },
                    { 2, false, false, 0.0, 0.0, null, true, 70, 3, 4000, null, null, false, null, "ehp-ie-tbz2", 0, 0 },
                    { 3, false, false, 0.0, 0.0, null, true, 80, 2, 5000, null, null, false, null, "ehp-ie-tbz3", 0, 0 }
                });

            migrationBuilder.InsertData(
                table: "UserGroups",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 1, "Expert" },
                    { 2, "Admin" },
                    { 3, "Operator" }
                });

            migrationBuilder.InsertData(
                table: "UserPermissions",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 1, "CanEditUserGroups" },
                    { 2, "CanEditUsers" },
                    { 3, "CanSecureSites" },
                    { 4, "CanEditSites" }
                });

            migrationBuilder.InsertData(
                table: "IOs",
                columns: new[] { "Id", "Enabled", "ModuleId", "Type" },
                values: new object[,]
                {
                    { 6, false, 3, 1 },
                    { 1, true, 1, 0 },
                    { 4, true, 1, 1 },
                    { 7, false, 1, 0 },
                    { 10, false, 1, 1 },
                    { 12, false, 3, 1 },
                    { 2, true, 2, 1 },
                    { 5, true, 2, 0 },
                    { 8, true, 2, 1 },
                    { 11, false, 2, 0 },
                    { 9, false, 3, 0 },
                    { 3, true, 3, 0 }
                });

            migrationBuilder.InsertData(
                table: "Statuss",
                columns: new[] { "Id", "BatteryLevel", "BatteryStatus", "Date", "ElectroFenceId", "ElectroFenceId1", "Hash", "HvAlarm", "HvChargeFault", "HvDischargeFault", "HvPowerFault", "HvVoltage", "Input1", "Input2", "Latitude", "Longitude", "LvAlarm", "MainPowerFault", "Output1", "Output2", "SignalStrength", "TamperAlarm", "Temperature" },
                values: new object[,]
                {
                    { 1, (byte)0, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, false, false, false, false, 0.0, false, false, null, null, false, false, false, false, (byte)0, false, 0.0 },
                    { 3, (byte)0, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, null, null, false, false, false, false, 0.0, false, false, null, null, false, false, false, false, (byte)0, false, 0.0 },
                    { 2, (byte)0, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null, null, false, false, false, false, 0.0, false, false, null, null, false, false, false, false, (byte)0, false, 0.0 }
                });

            migrationBuilder.InsertData(
                table: "UserGroupPermissions",
                columns: new[] { "GroupId", "PermissionId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 2, 2 },
                    { 1, 3 },
                    { 2, 3 },
                    { 3, 3 },
                    { 1, 4 },
                    { 2, 4 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FirstName", "GroupId", "LastName", "Password", "Username" },
                values: new object[,]
                {
                    { 1, "Amir", 1, "Fakhim-Babaei", "$2a$11$bYdNCZ47EfLQgMfqoeUduOr5NXxlXlqexmLAOrMHSd5FBsM5Tv4EK", "expert" },
                    { 2, "Amir", 2, "Fakhim-Babaei", "$2a$11$lAh2a2kYXGLw3jxInUs/AuaTJg6SgOlY7b8PFKcpnXeTkJeSfYGye", "admin" },
                    { 3, "Amir", 3, "Fakhim-Babaei", "$2a$11$jdip192QIJmLdYOCjEY/e.CpNTIV0Mao/2z61JRNbjMpj35LdVHS.", "operator" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_IOs_ModuleId",
                table: "IOs",
                column: "ModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_Statuss_ElectroFenceId",
                table: "Statuss",
                column: "ElectroFenceId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Statuss_ElectroFenceId1",
                table: "Statuss",
                column: "ElectroFenceId1");

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
                name: "IOs");

            migrationBuilder.DropTable(
                name: "UserGroupPermissions");

            migrationBuilder.DropTable(
                name: "UserLogs");

            migrationBuilder.DropTable(
                name: "UserPermissions");

            migrationBuilder.DropTable(
                name: "Statuss");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "ElectroFences");

            migrationBuilder.DropTable(
                name: "UserGroups");
        }
    }
}
