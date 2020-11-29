using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DESS.Migrations
{
    public partial class SiteAndSiteGroupSeeded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "SiteGroups",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Name", "Province" },
                values: new object[] { "R8", null });

            migrationBuilder.InsertData(
                table: "Sites",
                columns: new[] { "Id", "Applied", "AutoLocation", "BatteryMin", "BatteryWarning", "GroupId", "Hash", "HvEnabled", "HvPower", "HvRepeat", "HvThreshold", "Interval", "Latitude", "Longitude", "LvEnabled", "Name", "PhoneNumber", "SerialNo", "TamperEnabled", "TemperatureMax", "TemperatureMin", "TemperatureWarning", "Timeout", "UseGlobalInterval" },
                values: new object[] { 1, false, false, (byte)0, false, 1, null, true, (byte)70, (byte)2, (short)3000, (byte)10, "38.0962", "46.2738", true, "T5011", null, "SC20D3001N", false, (sbyte)0, (sbyte)0, false, (byte)0, false });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$CsMAsVttDeTUcj5GyvPLB.vL/rL48GiELNqdnlG0ueU1Kf6FPciIK");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$jwTI5.3xOONRBiwQovNJKez0zx9ivZIif4oMsSL0PzcrsccB.iomm");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$Q4ewTfigLqIzNGdl5GgFvuPZ9LAiN22c/JEs7hImv4SKw5iAXhYA2");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "Password",
                value: "$2a$11$6ik4kv8HP5DETIWap2HE0OtSg8byW38IkyIjF8gVXArGcqtmVEfEa");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.UpdateData(
                table: "SiteGroups",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Name", "Province" },
                values: new object[] { "Azerbayjan", "Ardabil, EA, WA, Zanjan" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$Aknm6XVVdKA3ynzzbmMAz.0cEZUADtT71OBmEF.s8MFi8awXt5r96");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$RSthzf4K4r8oiBHZ3cNd0uhpZUveAFZsYuf5dVkemQ4VFbBaArsuW");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$ZxC2cbkYWbynsscazrvuY.fA0Oq2r3K4O3DQiIZPKR.IuTHsRPO0C");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "Password",
                value: "$2a$11$BTaL3BobUL3sJbnp.7cuveMsLFAMULA/JCFzpjMVLi8Zbo4vb/5Y.");
        }
    }
}
