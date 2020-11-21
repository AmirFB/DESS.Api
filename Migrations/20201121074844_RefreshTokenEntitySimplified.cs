using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DESS.Migrations
{
    public partial class RefreshTokenEntitySimplified : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReplacedByToken",
                table: "RefreshToekns");

            migrationBuilder.DropColumn(
                name: "Revoked",
                table: "RefreshToekns");

            migrationBuilder.DropColumn(
                name: "RevokedBy",
                table: "RefreshToekns");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ReplacedByToken",
                table: "RefreshToekns",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Revoked",
                table: "RefreshToekns",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RevokedBy",
                table: "RefreshToekns",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$NRY7o7mNEMfmn3553aoe8uPDOm15kiDpLHp9PdvE.S49W1e802nqu");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$92BSHS8Jvzkqm8uVDs/Ev.azpcHQodJZfz3dnzR91aohIoosLrQBC");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$jixghe27fNyDA8SecDuOGOo/wji1l6P45lXB51ZL6f/xRq9otV5a2");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "Password",
                value: "$2a$11$aBem3m4GYHi4uS4Glcg3sev48xWZ.APoT.blthPydUdHTCaKJMGM6");
        }
    }
}
