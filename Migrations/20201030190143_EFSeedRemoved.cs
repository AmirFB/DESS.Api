using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DESS.Migrations
{
    public partial class EFSeedRemoved : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Inputs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Inputs",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Inputs",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Inputs",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Inputs",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Inputs",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Outputs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Outputs",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Outputs",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Outputs",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Outputs",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Outputs",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ElectroFences",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ElectroFences",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ElectroFences",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$fKr4KtIDhveFds3RihECle2AL.6QBm7Al.c/ypSVEo7O/.9ZX3kF6");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$QMAs9G2EJwKA/Ylk5YOJr.yHObR0CyB.ewyZzkaP4JVnqE/rMTsXS");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$yAta3IAPZJV5ncbCrrUTp.IbPg4ZJ3nbbAiNtHIFd3sxQJW0ohLC6");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ElectroFences",
                columns: new[] { "Id", "Applied", "AutoLocation", "BatteryMin", "BatteryWarning", "Hash", "HvEnabled", "HvPower", "HvRepeat", "HvThreshold", "Interval", "Latitude", "Longitude", "LvEnabled", "Name", "PhoneNumber", "SerialNo", "SiteId", "TamperEnabled", "TemperatureMax", "TemperatureMin", "TemperatureWarning", "Timeout", "UseGlobalInterval" },
                values: new object[,]
                {
                    { 1, false, false, (byte)0, false, null, true, (byte)70, (byte)2, (short)3000, (byte)10, "38.0962", "46.2738", true, "Ef1", null, "001", "ehp-ie-tbz", false, (sbyte)0, (sbyte)0, false, (byte)0, false },
                    { 2, false, false, (byte)0, false, null, true, (byte)70, (byte)3, (short)4000, (byte)15, "35.6892", "51.3890", false, "Ef2", null, "002", "ehp-ie-thr", false, (sbyte)0, (sbyte)0, false, (byte)0, false },
                    { 3, false, false, (byte)0, false, null, true, (byte)80, (byte)2, (short)5000, (byte)20, "32.6539", "51.6660", false, "Ef3", null, "003", "ehp-ie-isf", false, (sbyte)0, (sbyte)0, false, (byte)0, false }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$hjfCL1aayxBcXqWcI7ZM5.5Rs.HbXOs55E4LwPzaZ8YIuyMdPgDKO");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$pr7NPoY4c0eHSo1/yY07gudB3MoruGgyBLLempVj7d0owKDIdA.I2");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$/TpTm1qbI44fV/s5Py5VjOKv4fP8/GrC2mat2Ansd5yRkE6Vgdc.K");

            migrationBuilder.InsertData(
                table: "Inputs",
                columns: new[] { "Id", "Enabled", "ModuleId", "Name", "Type" },
                values: new object[,]
                {
                    { 1, true, 1, null, 0 },
                    { 4, true, 1, null, 1 },
                    { 2, true, 2, null, 1 },
                    { 5, true, 2, null, 0 },
                    { 3, true, 3, null, 0 },
                    { 6, false, 3, null, 1 }
                });

            migrationBuilder.InsertData(
                table: "Outputs",
                columns: new[] { "Id", "Enabled", "ModuleId", "Name", "ResetTime", "Triggers", "Type" },
                values: new object[,]
                {
                    { 1, true, 1, null, (short)0, "0", 0 },
                    { 4, true, 1, null, (short)0, "0", 1 },
                    { 2, true, 2, null, (short)0, "1;3", 1 },
                    { 5, true, 2, null, (short)0, "1;3", 0 },
                    { 3, true, 3, null, (short)0, "2;3", 0 },
                    { 6, false, 3, null, (short)0, "2;3", 1 }
                });

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "Id", "BatteryLevel", "BatteryStatus", "Date", "ElectroFenceId", "Hash", "HvAlarm", "HvChargeFault", "HvDischargeFault", "HvPowerFault", "HvVoltage", "Inputs", "IpAddress", "Latitude", "Longitude", "LvAlarm", "MainPowerFault", "Outputs", "SerialNo", "SignalStrength", "TamperAlarm", "Temperature" },
                values: new object[,]
                {
                    { 1, (byte)0, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, false, false, false, false, (short)0, null, null, null, null, false, false, null, null, (byte)0, false, (short)0 },
                    { 2, (byte)0, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null, false, false, false, false, (short)0, null, null, null, null, false, false, null, null, (byte)0, false, (short)0 },
                    { 3, (byte)0, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, null, false, false, false, false, (short)0, null, null, null, null, false, false, null, null, (byte)0, false, (short)0 }
                });
        }
    }
}
