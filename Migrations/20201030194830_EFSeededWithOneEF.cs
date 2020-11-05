using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DESS.Migrations
{
    public partial class EFSeededWithOneEF : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ElectroFences",
                columns: new[] { "Id", "Applied", "AutoLocation", "BatteryMin", "BatteryWarning", "Hash", "HvEnabled", "HvPower", "HvRepeat", "HvThreshold", "Interval", "Latitude", "Longitude", "LvEnabled", "Name", "PhoneNumber", "SerialNo", "SiteId", "TamperEnabled", "TemperatureMax", "TemperatureMin", "TemperatureWarning", "Timeout", "UseGlobalInterval" },
                values: new object[] { 1, false, false, (byte)0, false, null, true, (byte)70, (byte)2, (short)3000, (byte)10, "38.0962", "46.2738", true, "Ef1", null, "SC20N3001N", "T5011", false, (sbyte)0, (sbyte)0, false, (byte)0, false });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$iHVg8qy14YaapcnN6x7lqOrTAKZlUjXPej/M.ShC552fgZrbqxf7u");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$Ld7nPaZjs1zxRQbjtSHs/erIWM.2lhwrkVL2705d9/WUMqsOMke7C");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$IHeKT5fcskg69X19UmL6qe45xTGz95xU.TkXwbZukIbUJXS4PSvyG");

            migrationBuilder.InsertData(
                table: "Inputs",
                columns: new[] { "Id", "Enabled", "ModuleId", "Name", "Type" },
                values: new object[,]
                {
                    { 1, true, 1, null, 0 },
                    { 4, true, 1, null, 1 }
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
                columns: new[] { "Id", "BatteryLevel", "BatteryStatus", "Date", "ElectroFenceId", "Hash", "HvAlarm", "HvChargeFault", "HvDischargeFault", "HvPowerFault", "HvVoltage", "Inputs", "IpAddress", "Latitude", "Longitude", "LvAlarm", "MainPowerFault", "Outputs", "SerialNo", "SignalStrength", "TamperAlarm", "Temperature" },
                values: new object[] { 1, (byte)0, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, false, false, false, false, (short)0, null, null, null, null, false, false, null, null, (byte)0, false, (short)0 });
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
                table: "ElectroFences",
                keyColumn: "Id",
                keyValue: 1);

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
    }
}
