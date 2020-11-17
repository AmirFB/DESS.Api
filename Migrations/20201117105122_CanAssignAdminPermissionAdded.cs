using Microsoft.EntityFrameworkCore.Migrations;

namespace DESS.Migrations
{
    public partial class CanAssignAdminPermissionAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "Title" },
                values: new object[] { 8, "CanAssignAdmin" });

            migrationBuilder.UpdateData(
                table: "UserGroups",
                keyColumn: "Id",
                keyValue: 1,
                column: "PermissionIds",
                value: "1;2;3;4;5;6;7;8");

            migrationBuilder.UpdateData(
                table: "UserGroups",
                keyColumn: "Id",
                keyValue: 2,
                column: "PermissionIds",
                value: "2;3;4;5;6;7;8");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Permissions",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.UpdateData(
                table: "UserGroups",
                keyColumn: "Id",
                keyValue: 1,
                column: "PermissionIds",
                value: "1;2;3;4;5;6;7");

            migrationBuilder.UpdateData(
                table: "UserGroups",
                keyColumn: "Id",
                keyValue: 2,
                column: "PermissionIds",
                value: "2;3;4;5;6;7");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$M/rBwToYhm88/nMcm3o4r.3oKCtHsVW6abUWHaBpjrRynzN059STm");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$Hizqi/R7FqWHxBeDfyqJ5uU.Vfdaa8GjLtG6r2nHhXDelnNntG5h6");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$ZhxOYQetIE8kJHsohAKCZu94s5Hdzdgb2dBdVrFA.eG4yMYvKHkSu");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "Password",
                value: "$2a$11$gMU.mOP2U0IG3OwvFYuRauV3QCuQc07ChA2/Bigalmc9nuZGUsuf2");
        }
    }
}
