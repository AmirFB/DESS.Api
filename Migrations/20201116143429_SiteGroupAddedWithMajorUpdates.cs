using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DESS.Migrations
{
    public partial class SiteGroupAddedWithMajorUpdates : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserGroupPermissions");

            migrationBuilder.DeleteData(
                table: "Inputs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Inputs",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Outputs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Outputs",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Sites",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "SiteGroupId",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PermissionIds",
                table: "UserGroups",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GroupId",
                table: "Sites",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "SiteGroups",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    Province = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiteGroups", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Title",
                value: "CanSecure");

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                column: "Title",
                value: "CanAddRemoveSites");

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                column: "Title",
                value: "CanHandleSiteGroups");

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 6, "CanEditUsers" },
                    { 7, "CanHandleUserGroup" }
                });

            migrationBuilder.UpdateData(
                table: "UserGroups",
                keyColumn: "Id",
                keyValue: 1,
                column: "PermissionIds",
                value: "1;2;3;4;5;6;7");

            migrationBuilder.UpdateData(
                table: "UserGroups",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "PermissionIds", "Title" },
                values: new object[] { "2;3;4;5;6;7", "Manager" });

            migrationBuilder.UpdateData(
                table: "UserGroups",
                keyColumn: "Id",
                keyValue: 3,
                column: "PermissionIds",
                value: "2;3;6");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Password", "Username" },
                values: new object[] { "$2a$11$w1ULiXZfdKSCSSfb8sKF9ujJ3PKbu6HvgpsuAL6MoDupR1mM9dYuq", "almighty" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "LastName", "Password" },
                values: new object[] { "Chegini", "$2a$11$SyWMQBQ9t4yBf/R0NFx2TeIeoY.JPxuHq1vd4PLr0ruTdOs.qP2wi" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "FirstName", "LastName", "Password", "Username" },
                values: new object[] { "No", "One", "$2a$11$lk8KfSJMtXapEHucO2P0ROn7oQPDpT16oaSWGzFKLftMmutykvK7a", "admin" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "FirstName", "GroupId", "LastName", "Password", "SiteGroupId", "Username" },
                values: new object[] { 4, "Not", 4, "Yet", "$2a$11$5zGq766m.dTfv55EVVgCEuEffSFJI.epiP1Prka22dV4CUs1Hi1Qi", null, "operator" });

            migrationBuilder.CreateIndex(
                name: "IX_Users_SiteGroupId",
                table: "Users",
                column: "SiteGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_Sites_GroupId",
                table: "Sites",
                column: "GroupId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sites_SiteGroups_GroupId",
                table: "Sites",
                column: "GroupId",
                principalTable: "SiteGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_SiteGroups_SiteGroupId",
                table: "Users",
                column: "SiteGroupId",
                principalTable: "SiteGroups",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sites_SiteGroups_GroupId",
                table: "Sites");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_SiteGroups_SiteGroupId",
                table: "Users");

            migrationBuilder.DropTable(
                name: "SiteGroups");

            migrationBuilder.DropIndex(
                name: "IX_Users_SiteGroupId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Sites_GroupId",
                table: "Sites");

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DropColumn(
                name: "SiteGroupId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PermissionIds",
                table: "UserGroups");

            migrationBuilder.DropColumn(
                name: "GroupId",
                table: "Sites");

            migrationBuilder.CreateTable(
                name: "UserGroupPermissions",
                columns: table => new
                {
                    GroupId = table.Column<int>(type: "int", nullable: false),
                    PermissionId = table.Column<int>(type: "int", nullable: false)
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
                        name: "FK_UserGroupPermissions_Permissions_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "Permissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 2,
                column: "Title",
                value: "CanResetFaults");

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 4,
                column: "Title",
                value: "CanEditUserGroups");

            migrationBuilder.UpdateData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 5,
                column: "Title",
                value: "CanEditUsers");

            migrationBuilder.InsertData(
                table: "Sites",
                columns: new[] { "Id", "Applied", "AutoLocation", "BatteryMin", "BatteryWarning", "Hash", "HvEnabled", "HvPower", "HvRepeat", "HvThreshold", "Interval", "Latitude", "Longitude", "LvEnabled", "Name", "PhoneNumber", "SerialNo", "TamperEnabled", "TemperatureMax", "TemperatureMin", "TemperatureWarning", "Timeout", "UseGlobalInterval" },
                values: new object[] { 1, false, false, (byte)0, false, null, true, (byte)70, (byte)2, (short)3000, (byte)10, "38.0962", "46.2738", true, "T5011", null, "SC20D3001N", false, (sbyte)0, (sbyte)0, false, (byte)0, false });

            migrationBuilder.InsertData(
                table: "UserGroupPermissions",
                columns: new[] { "GroupId", "PermissionId" },
                values: new object[,]
                {
                    { 1, 4 },
                    { 1, 1 },
                    { 4, 2 },
                    { 1, 3 },
                    { 3, 3 },
                    { 1, 2 },
                    { 3, 5 },
                    { 2, 4 },
                    { 2, 3 },
                    { 2, 2 },
                    { 1, 5 },
                    { 2, 5 },
                    { 3, 2 }
                });

            migrationBuilder.UpdateData(
                table: "UserGroups",
                keyColumn: "Id",
                keyValue: 2,
                column: "Title",
                value: "Expert");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Password", "Username" },
                values: new object[] { "$2a$11$FtBN2MxIs12/MOj9fjcAm.nslgRY8fPMGe7jFD8O81.WzUSIzPWiS", "expert" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "LastName", "Password" },
                values: new object[] { "Fakhim-Babaei", "$2a$11$oVqN7mxLE15uCbM5kBOvteGYab3/Yic6Ibrzcj28Nf6BeqHD.h1VK" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "FirstName", "LastName", "Password", "Username" },
                values: new object[] { "Amir", "Fakhim-Babaei", "$2a$11$a.P3ToHmDquwTSpzNELkx.Us2vShCcEh3Uz0pGZCWs53AZwJLi55S", "operator" });

            migrationBuilder.InsertData(
                table: "Inputs",
                columns: new[] { "Id", "Enabled", "ModuleId", "Name", "Timer", "Type" },
                values: new object[,]
                {
                    { 1, true, 1, null, (byte)0, 0 },
                    { 4, true, 1, null, (byte)0, 1 }
                });

            migrationBuilder.InsertData(
                table: "Outputs",
                columns: new[] { "Id", "Enabled", "ModuleId", "Name", "ResetTime", "Triggers", "Type" },
                values: new object[,]
                {
                    { 1, true, 1, null, (short)0, "0", 0 },
                    { 4, true, 1, null, (short)0, "0", 1 }
                });

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "Id", "BatteryLevel", "BatteryStatus", "Date", "Hash", "HvAlarm", "HvChargeFault", "HvDischargeFault", "HvPowerFault", "HvVoltage", "Inputs", "IpAddress", "Latitude", "Longitude", "LvAlarm", "MainPowerFault", "Outputs", "SerialNo", "SignalStrength", "SiteId", "TamperAlarm", "Temperature" },
                values: new object[] { 1, (byte)0, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, false, false, false, false, (short)0, null, null, null, null, false, false, null, null, (byte)0, 1, false, (short)0 });

            migrationBuilder.CreateIndex(
                name: "IX_UserGroupPermissions_PermissionId",
                table: "UserGroupPermissions",
                column: "PermissionId");
        }
    }
}
