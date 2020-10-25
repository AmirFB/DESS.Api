using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DESS.Migrations
{
    public partial class LogRefactored : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Logs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Logs",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Logs",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "BatteryLevel",
                table: "Logs");

            migrationBuilder.DropColumn(
                name: "BatteryStatus",
                table: "Logs");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Logs");

            migrationBuilder.DropColumn(
                name: "Hash",
                table: "Logs");

            migrationBuilder.DropColumn(
                name: "HvAlarm",
                table: "Logs");

            migrationBuilder.DropColumn(
                name: "HvChargeFault",
                table: "Logs");

            migrationBuilder.DropColumn(
                name: "HvDischargeFault",
                table: "Logs");

            migrationBuilder.DropColumn(
                name: "HvPowerFault",
                table: "Logs");

            migrationBuilder.DropColumn(
                name: "HvVoltage",
                table: "Logs");

            migrationBuilder.DropColumn(
                name: "Input1",
                table: "Logs");

            migrationBuilder.DropColumn(
                name: "Input2",
                table: "Logs");

            migrationBuilder.DropColumn(
                name: "IpAddress",
                table: "Logs");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Logs");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Logs");

            migrationBuilder.DropColumn(
                name: "LvAlarm",
                table: "Logs");

            migrationBuilder.DropColumn(
                name: "MainPowerFault",
                table: "Logs");

            migrationBuilder.DropColumn(
                name: "Output1",
                table: "Logs");

            migrationBuilder.DropColumn(
                name: "Output2",
                table: "Logs");

            migrationBuilder.DropColumn(
                name: "SerialNo",
                table: "Logs");

            migrationBuilder.DropColumn(
                name: "SignalStrength",
                table: "Logs");

            migrationBuilder.DropColumn(
                name: "TamperAlarm",
                table: "Logs");

            migrationBuilder.DropColumn(
                name: "Temperature",
                table: "Logs");

            migrationBuilder.AddColumn<DateTime>(
                name: "ObviatedOn",
                table: "Logs",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "OccuredOn",
                table: "Logs",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "ResetedBy",
                table: "Logs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "ResetedOn",
                table: "Logs",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "SeenBy",
                table: "Logs",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Logs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
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
                    ElectroFenceId = table.Column<int>(nullable: false),
                    Inputs = table.Column<string>(nullable: true),
                    Outputs = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Statuses_ElectroFences_ElectroFenceId",
                        column: x => x.ElectroFenceId,
                        principalTable: "ElectroFences",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$f4Ohw7ILtBP4iaAWKhhnCOv.bX9iLfFIaacbx/4QEM0.SRYMQGyTy");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$PqnLX3yA34sN.r.pl8jUDuqSDGGhkLOM4NhnXUIda1knqVAaJNzxe");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$uGDSrTwEysZcE.fI4yZ.IOYGWiWZusW7FHFogmEUwdEjJD/TKcX.a");

            migrationBuilder.CreateIndex(
                name: "IX_Statuses_ElectroFenceId",
                table: "Statuses",
                column: "ElectroFenceId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Statuses");

            migrationBuilder.DropColumn(
                name: "ObviatedOn",
                table: "Logs");

            migrationBuilder.DropColumn(
                name: "OccuredOn",
                table: "Logs");

            migrationBuilder.DropColumn(
                name: "ResetedBy",
                table: "Logs");

            migrationBuilder.DropColumn(
                name: "ResetedOn",
                table: "Logs");

            migrationBuilder.DropColumn(
                name: "SeenBy",
                table: "Logs");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Logs");

            migrationBuilder.AddColumn<byte>(
                name: "BatteryLevel",
                table: "Logs",
                type: "tinyint unsigned",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<int>(
                name: "BatteryStatus",
                table: "Logs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Logs",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Hash",
                table: "Logs",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HvAlarm",
                table: "Logs",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HvChargeFault",
                table: "Logs",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HvDischargeFault",
                table: "Logs",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "HvPowerFault",
                table: "Logs",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<short>(
                name: "HvVoltage",
                table: "Logs",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<bool>(
                name: "Input1",
                table: "Logs",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Input2",
                table: "Logs",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "IpAddress",
                table: "Logs",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Latitude",
                table: "Logs",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Longitude",
                table: "Logs",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "LvAlarm",
                table: "Logs",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "MainPowerFault",
                table: "Logs",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Output1",
                table: "Logs",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Output2",
                table: "Logs",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "SerialNo",
                table: "Logs",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "SignalStrength",
                table: "Logs",
                type: "tinyint unsigned",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<bool>(
                name: "TamperAlarm",
                table: "Logs",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<short>(
                name: "Temperature",
                table: "Logs",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.InsertData(
                table: "Logs",
                columns: new[] { "Id", "BatteryLevel", "BatteryStatus", "Date", "ElectroFenceId", "Hash", "HvAlarm", "HvChargeFault", "HvDischargeFault", "HvPowerFault", "HvVoltage", "Input1", "Input2", "IpAddress", "Latitude", "Longitude", "LvAlarm", "MainPowerFault", "Output1", "Output2", "SerialNo", "SignalStrength", "TamperAlarm", "Temperature" },
                values: new object[,]
                {
                    { 1, (byte)0, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, false, false, false, false, (short)0, false, false, null, null, null, false, false, false, false, null, (byte)0, false, (short)0 },
                    { 2, (byte)0, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null, false, false, false, false, (short)0, false, false, null, null, null, false, false, false, false, null, (byte)0, false, (short)0 },
                    { 3, (byte)0, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, null, false, false, false, false, (short)0, false, false, null, null, null, false, false, false, false, null, (byte)0, false, (short)0 }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$oqiP/XA3NCo5.pcOes9CRehzHB0ffjCgOSsitxdUZxQPRikLClTHW");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$0yUOIvyraoC/YaFk4ip0z.zTolIaddmW4iXS8xdp4/lOZxGNNIssa");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$8deZ26oYOfYxkyse6SXgV.ZMpYrSzC6Tp38zxz7YCSaaDWn6C2LRS");
        }
    }
}
