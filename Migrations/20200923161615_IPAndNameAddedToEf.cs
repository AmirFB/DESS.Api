using Microsoft.EntityFrameworkCore.Migrations;

namespace DESS.Migrations
{
    public partial class IPAndNameAddedToEf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IpAddress",
                table: "Statuss",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IpAddress",
                table: "ElectroFences",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "ElectroFences",
                nullable: false);

            migrationBuilder.UpdateData(
                table: "ElectroFences",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Ef1");

            migrationBuilder.UpdateData(
                table: "ElectroFences",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Ef2");

            migrationBuilder.UpdateData(
                table: "ElectroFences",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Ef3");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$fAx1HD.CLiZR9axW4pJZqeIR0LwW944h5wfN9yv1nByWG7v5CVUD2");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$rTuiMBDl2b56kYzzIhWAC.LihdTIUkR5c40y.foQKHaSpTSezTC3i");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$ZlikfJQZmACKq3Ld9vdpAOZfa2zfXBAEcXLxlhGzYbqabncE9Qmny");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IpAddress",
                table: "Statuss");

            migrationBuilder.DropColumn(
                name: "IpAddress",
                table: "ElectroFences");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "ElectroFences");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$bYdNCZ47EfLQgMfqoeUduOr5NXxlXlqexmLAOrMHSd5FBsM5Tv4EK");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$lAh2a2kYXGLw3jxInUs/AuaTJg6SgOlY7b8PFKcpnXeTkJeSfYGye");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$jdip192QIJmLdYOCjEY/e.CpNTIV0Mao/2z61JRNbjMpj35LdVHS.");
        }
    }
}
