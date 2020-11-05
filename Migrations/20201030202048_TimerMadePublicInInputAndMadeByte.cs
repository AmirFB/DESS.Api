using Microsoft.EntityFrameworkCore.Migrations;

namespace DESS.Migrations
{
    public partial class TimerMadePublicInInputAndMadeByte : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "Timer",
                table: "Inputs",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$/gTIntmQnwHndc5MN2tleexdSo13ylL5gszQm.LyNnjJalcXuNo2y");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$kAoAF9d9rOfSI1UapExp5eEAL36/40LShiEutCpRqJnMDJ15ODe/2");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$cdOHb4himUKHYd20W0GDj.MWGVm9t3NIl68iDDWp8TAUGbyaZBZhm");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Timer",
                table: "Inputs");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$OitpAF9ye.cjugArz2xmzeeUpHF1u.3FA8JEKKFuP4M4sNJFTFBam");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$LrDPmGYENZpX586gJovUmegS5N7iQoRk3DZzt8D8Ue5QUkrXvyxc2");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$jQjv8etk511PuqHnxGCs3OVatePRsUtpehFMkZMI4b9USfjZk0daa");
        }
    }
}
