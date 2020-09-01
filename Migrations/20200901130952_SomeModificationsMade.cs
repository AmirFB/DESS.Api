using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DESS.Migrations
{
    public partial class SomeModificationsMade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "BatteryMax",
                table: "ElectroFences",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "BatteryMin",
                table: "ElectroFences",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Latitude",
                table: "ElectroFences",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Longitude",
                table: "ElectroFences",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TemperatureMax",
                table: "ElectroFences",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TemperatureMin",
                table: "ElectroFences",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropColumn(
                name: "BatteryMax",
                table: "ElectroFences");

            migrationBuilder.DropColumn(
                name: "BatteryMin",
                table: "ElectroFences");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "ElectroFences");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "ElectroFences");

            migrationBuilder.DropColumn(
                name: "TemperatureMax",
                table: "ElectroFences");

            migrationBuilder.DropColumn(
                name: "TemperatureMin",
                table: "ElectroFences");
        }
    }
}
