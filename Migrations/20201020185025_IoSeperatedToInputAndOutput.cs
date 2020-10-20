using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dess.Api.Migrations
{
    public partial class IoSeperatedToInputAndOutput : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IOs");

            migrationBuilder.DropColumn(
                name: "BatteryMax",
                table: "ElectroFences");

            migrationBuilder.AlterColumn<short>(
                name: "Temperature",
                table: "Logs",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double");

            migrationBuilder.AlterColumn<short>(
                name: "HvVoltage",
                table: "Logs",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double");

            migrationBuilder.AlterColumn<sbyte>(
                name: "TemperatureMin",
                table: "ElectroFences",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<sbyte>(
                name: "TemperatureMax",
                table: "ElectroFences",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<byte>(
                name: "Interval",
                table: "ElectroFences",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<short>(
                name: "HvThreshold",
                table: "ElectroFences",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<byte>(
                name: "HvRepeat",
                table: "ElectroFences",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<byte>(
                name: "HvPower",
                table: "ElectroFences",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<byte>(
                name: "BatteryMin",
                table: "ElectroFences",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "double");

            migrationBuilder.AddColumn<bool>(
                name: "TamperEnabled",
                table: "ElectroFences",
                nullable: false,
                defaultValue: false);

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
                    Triggers = table.Column<byte[]>(nullable: true)
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

            migrationBuilder.UpdateData(
                table: "ElectroFences",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BatteryMin", "HvPower", "HvRepeat", "HvThreshold", "Interval", "TemperatureMax", "TemperatureMin" },
                values: new object[] { (byte)0, (byte)70, (byte)2, (short)3000, (byte)10, (sbyte)0, (sbyte)0 });

            migrationBuilder.UpdateData(
                table: "ElectroFences",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BatteryMin", "HvPower", "HvRepeat", "HvThreshold", "Interval", "TemperatureMax", "TemperatureMin" },
                values: new object[] { (byte)0, (byte)70, (byte)3, (short)4000, (byte)15, (sbyte)0, (sbyte)0 });

            migrationBuilder.UpdateData(
                table: "ElectroFences",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "BatteryMin", "HvPower", "HvRepeat", "HvThreshold", "Interval", "TemperatureMax", "TemperatureMin" },
                values: new object[] { (byte)0, (byte)80, (byte)2, (short)5000, (byte)20, (sbyte)0, (sbyte)0 });

            migrationBuilder.InsertData(
                table: "Inputs",
                columns: new[] { "Id", "Enabled", "ModuleId", "Name", "Type" },
                values: new object[,]
                {
                    { 1, true, 1, null, 0 },
                    { 4, true, 1, null, 1 },
                    { 2, true, 2, null, 1 },
                    { 5, true, 2, null, 0 }
                });

            migrationBuilder.UpdateData(
                table: "Logs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "HvVoltage", "Temperature" },
                values: new object[] { (short)0, (short)0 });

            migrationBuilder.UpdateData(
                table: "Logs",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "HvVoltage", "Temperature" },
                values: new object[] { (short)0, (short)0 });

            migrationBuilder.UpdateData(
                table: "Logs",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "HvVoltage", "Temperature" },
                values: new object[] { (short)0, (short)0 });

            migrationBuilder.InsertData(
                table: "Outputs",
                columns: new[] { "Id", "Enabled", "ModuleId", "Name", "ResetTime", "Triggers", "Type" },
                values: new object[,]
                {
                    { 1, true, 1, null, (short)0, null, 0 },
                    { 2, true, 2, null, (short)0, null, 1 },
                    { 4, true, 1, null, (short)0, null, 1 },
                    { 5, true, 2, null, (short)0, null, 0 }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$Tgti5/npbIRpAPMxNQ06P.1jiQDho5w5wvyNeWu4IcBiAwj07Gta6");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$GGQc5HzTKxwcLXmzsYLLouAZOV26n4aMvJEkB5lvCEXG31tHxLT32");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$OK7yXaO9UHsXJVirJQtsxONq4cvhBN3V0zzAcTCqD/LOsl75taWp.");

            migrationBuilder.CreateIndex(
                name: "IX_Inputs_ModuleId",
                table: "Inputs",
                column: "ModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_Outputs_ModuleId",
                table: "Outputs",
                column: "ModuleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inputs");

            migrationBuilder.DropTable(
                name: "Outputs");

            migrationBuilder.DropColumn(
                name: "TamperEnabled",
                table: "ElectroFences");

            migrationBuilder.AlterColumn<double>(
                name: "Temperature",
                table: "Logs",
                type: "double",
                nullable: false,
                oldClrType: typeof(short));

            migrationBuilder.AlterColumn<double>(
                name: "HvVoltage",
                table: "Logs",
                type: "double",
                nullable: false,
                oldClrType: typeof(short));

            migrationBuilder.AlterColumn<int>(
                name: "TemperatureMin",
                table: "ElectroFences",
                type: "int",
                nullable: false,
                oldClrType: typeof(sbyte));

            migrationBuilder.AlterColumn<int>(
                name: "TemperatureMax",
                table: "ElectroFences",
                type: "int",
                nullable: false,
                oldClrType: typeof(sbyte));

            migrationBuilder.AlterColumn<int>(
                name: "Interval",
                table: "ElectroFences",
                type: "int",
                nullable: false,
                oldClrType: typeof(byte));

            migrationBuilder.AlterColumn<int>(
                name: "HvThreshold",
                table: "ElectroFences",
                type: "int",
                nullable: false,
                oldClrType: typeof(short));

            migrationBuilder.AlterColumn<int>(
                name: "HvRepeat",
                table: "ElectroFences",
                type: "int",
                nullable: false,
                oldClrType: typeof(byte));

            migrationBuilder.AlterColumn<int>(
                name: "HvPower",
                table: "ElectroFences",
                type: "int",
                nullable: false,
                oldClrType: typeof(byte));

            migrationBuilder.AlterColumn<double>(
                name: "BatteryMin",
                table: "ElectroFences",
                type: "double",
                nullable: false,
                oldClrType: typeof(byte));

            migrationBuilder.AddColumn<double>(
                name: "BatteryMax",
                table: "ElectroFences",
                type: "double",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateTable(
                name: "IOs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Enabled = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ModuleId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Type = table.Column<int>(type: "int", nullable: false)
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

            migrationBuilder.UpdateData(
                table: "ElectroFences",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "BatteryMin", "HvPower", "HvRepeat", "HvThreshold", "Interval", "TemperatureMax", "TemperatureMin" },
                values: new object[] { 0.0, 70, 2, 3000, 10, 0, 0 });

            migrationBuilder.UpdateData(
                table: "ElectroFences",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "BatteryMin", "HvPower", "HvRepeat", "HvThreshold", "Interval", "TemperatureMax", "TemperatureMin" },
                values: new object[] { 0.0, 70, 3, 4000, 15, 0, 0 });

            migrationBuilder.UpdateData(
                table: "ElectroFences",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "BatteryMin", "HvPower", "HvRepeat", "HvThreshold", "Interval", "TemperatureMax", "TemperatureMin" },
                values: new object[] { 0.0, 80, 2, 5000, 20, 0, 0 });

            migrationBuilder.InsertData(
                table: "IOs",
                columns: new[] { "Id", "Enabled", "ModuleId", "Name", "Type" },
                values: new object[,]
                {
                    { 12, false, 3, null, 1 },
                    { 10, false, 1, null, 1 },
                    { 9, false, 3, null, 0 },
                    { 8, true, 2, null, 1 },
                    { 11, false, 2, null, 0 },
                    { 6, false, 3, null, 1 },
                    { 5, true, 2, null, 0 },
                    { 4, true, 1, null, 1 },
                    { 3, true, 3, null, 0 },
                    { 2, true, 2, null, 1 },
                    { 7, false, 1, null, 0 },
                    { 1, true, 1, null, 0 }
                });

            migrationBuilder.UpdateData(
                table: "Logs",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "HvVoltage", "Temperature" },
                values: new object[] { 0.0, 0.0 });

            migrationBuilder.UpdateData(
                table: "Logs",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "HvVoltage", "Temperature" },
                values: new object[] { 0.0, 0.0 });

            migrationBuilder.UpdateData(
                table: "Logs",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "HvVoltage", "Temperature" },
                values: new object[] { 0.0, 0.0 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$Vj05SekvGCex.9lnhK73t.IXPzRK2n6zG2RiUDVHvy9UX3aVCRtTi");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$OApRnuxDa3HNelMzSfrtmub1zlzki34XG/.DHv03In5YAEYX/PC.C");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$E4w7aUdhJxb7NBUc36pIQu4dTliZaliqo6kjVD03ik0pgnNcFC1na");

            migrationBuilder.CreateIndex(
                name: "IX_IOs_ModuleId",
                table: "IOs",
                column: "ModuleId");
        }
    }
}
