using Microsoft.EntityFrameworkCore.Migrations;

namespace DESS.Migrations
{
    public partial class TimerCapitalizedInInputDto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
