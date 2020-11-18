using Microsoft.EntityFrameworkCore.Migrations;

namespace DESS.Migrations
{
    public partial class SiteGroupsSeeded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "SiteGroups",
                columns: new[] { "Id", "Name", "Province" },
                values: new object[] { 1, "Azerbayjan", "Ardabil, EA, WA, Zanjan" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$pgIrEYQUnjslESWjKC8x..YIKXS3eypHM9oDoffm5BqrcaoDp/dhS");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$6/lAX1/Xi52vkzksOZn5be1wUoMdod4H1Mo9sW39vEFTJHs5v9vma");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$ebr6ws.hzadU5BIJbUWdAuPfeJb31.MDo77G6kDw3wSU6UQqPWXGu");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "Password",
                value: "$2a$11$W9qCPuRMgkncfxfhRC3QjOCXsE.sYUId/iFPGEzvholyhS.YQL9AW");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SiteGroups",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$2obdFxBsSGNfNMEW/9SVu.46aVAnPV5oC6M0r5nbiFF1qmziZo8Fy");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$m/9tr13l04ZzpH6M5MXzp.d/sFQ2Cttth/IuyFC8E..Rm/PNX.kRG");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$ozYit8Q65sXSZYyIeGx6P.Cq6WsRPjf.sUt6VYAmUPQRXovnK1ode");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "Password",
                value: "$2a$11$8amUsgpU1o5n.GXffKkhlOzw4ieEmPIoSHtMt5sA9C/kOgxRIb7xq");
        }
    }
}
