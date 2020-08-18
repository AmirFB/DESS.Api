using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DESS.Migrations
{
    public partial class InitialDatabase : Migration
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
                    HvEnabled = table.Column<bool>(nullable: false),
                    LvEnabled = table.Column<bool>(nullable: false),
                    HvPower = table.Column<int>(nullable: false),
                    HvThreshold = table.Column<int>(nullable: false),
                    HvRepeat = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElectroFences", x => x.Id);
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
                    HvVoltage = table.Column<double>(nullable: false),
                    Temperature = table.Column<double>(nullable: false),
                    BatteryStatus = table.Column<int>(nullable: false),
                    BatteryLevel = table.Column<byte>(nullable: false),
                    MainPowerFault = table.Column<bool>(nullable: false),
                    HvPowerFault = table.Column<bool>(nullable: false),
                    HvChargeFault = table.Column<bool>(nullable: false),
                    HvDischargeFault = table.Column<bool>(nullable: false),
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

            migrationBuilder.InsertData(
                table: "ElectroFences",
                columns: new[] { "Id", "Applied", "AutoLocation", "Hash", "HvEnabled", "HvPower", "HvRepeat", "HvThreshold", "LvEnabled", "PhoneNumber", "Serial" },
                values: new object[] { 1, false, false, null, true, 70, 2, 3000, true, null, "ehp-ie-tbz1" });

            migrationBuilder.InsertData(
                table: "ElectroFences",
                columns: new[] { "Id", "Applied", "AutoLocation", "Hash", "HvEnabled", "HvPower", "HvRepeat", "HvThreshold", "LvEnabled", "PhoneNumber", "Serial" },
                values: new object[] { 2, false, false, null, true, 70, 3, 4000, false, null, "ehp-ie-tbz2" });

            migrationBuilder.InsertData(
                table: "ElectroFences",
                columns: new[] { "Id", "Applied", "AutoLocation", "Hash", "HvEnabled", "HvPower", "HvRepeat", "HvThreshold", "LvEnabled", "PhoneNumber", "Serial" },
                values: new object[] { 3, false, false, null, true, 80, 2, 5000, false, null, "ehp-ie-tbz3" });

            migrationBuilder.InsertData(
                table: "IOs",
                columns: new[] { "Id", "Enabled", "ModuleId", "Type" },
                values: new object[,]
                {
                    { 1, true, 1, 0 },
                    { 4, true, 1, 1 },
                    { 7, false, 1, 0 },
                    { 10, false, 1, 1 },
                    { 2, true, 2, 1 },
                    { 5, true, 2, 0 },
                    { 8, true, 2, 1 },
                    { 11, false, 2, 0 },
                    { 3, true, 3, 0 },
                    { 6, false, 3, 1 },
                    { 9, false, 3, 0 },
                    { 12, false, 3, 1 }
                });

            migrationBuilder.InsertData(
                table: "Statuss",
                columns: new[] { "Id", "BatteryLevel", "BatteryStatus", "Date", "ElectroFenceId", "ElectroFenceId1", "Hash", "HvAlarm", "HvChargeFault", "HvDischargeFault", "HvPowerFault", "HvVoltage", "Input1", "Input2", "Latitude", "Longitude", "LvAlarm", "MainPowerFault", "Output1", "Output2", "SignalStrength", "TamperAlarm", "Temperature" },
                values: new object[,]
                {
                    { 1, (byte)0, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, null, null, false, false, false, false, 0.0, false, false, null, null, false, false, false, false, (byte)0, false, 0.0 },
                    { 2, (byte)0, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, null, null, false, false, false, false, 0.0, false, false, null, null, false, false, false, false, (byte)0, false, 0.0 },
                    { 3, (byte)0, 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, null, null, false, false, false, false, 0.0, false, false, null, null, false, false, false, false, (byte)0, false, 0.0 }
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IOs");

            migrationBuilder.DropTable(
                name: "Statuss");

            migrationBuilder.DropTable(
                name: "ElectroFences");
        }
    }
}
