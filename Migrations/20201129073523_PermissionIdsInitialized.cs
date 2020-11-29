using Microsoft.EntityFrameworkCore.Migrations;

namespace DESS.Migrations
{
    public partial class PermissionIdsInitialized : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "UserGroups",
                keyColumn: "Id",
                keyValue: 4,
                column: "PermissionIds",
                value: "");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$7WT//PjiWpao2htQ2W05/.YGbiDnLYzCaJIpmCYzvJvjFCxU2h9Ya");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$lHj4EPTHaGDCg8IgDAvIz.UsiGoH3LPprIYJfnieJHzde38IEJdSW");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$5FD1NVXCy3rbuE/0XOE9IOOinNOxS3psg8Qe9Gw0TyLZsFysau9PS");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "Password",
                value: "$2a$11$Pi28qFvYO7Uhzoh/RANqI.E4DcSw.mJoUxZKC1hQRm.DjRDPqbdHu");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "UserGroups",
                keyColumn: "Id",
                keyValue: 4,
                column: "PermissionIds",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$PfeTrVEwLdQQT6mT82U6/u/sYJ5RFNtfLIiO1tmPsp5aReFbaK/CS");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$kmA.1XtHlnTwJhU2WdqnE.JECEP8AQuW99EOdFuETUp06kFNZUDy6");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$SN835eE19lT1gWU5tu.03eZalkUs/SndaYKDDSJw5.05PGswnZlZW");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "Password",
                value: "$2a$11$x4ykiuWlKAqZIILo0/RF..CYM/q.v3LOtiCAt.Uh83CZdUI9xqFFC");
        }
    }
}
