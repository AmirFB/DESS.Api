using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dess.Api.Migrations
{
    public partial class OutputsSeededWithTriggers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Outputs",
                keyColumn: "Id",
                keyValue: 1,
                column: "Triggers",
                value: new byte[] { 0 });

            migrationBuilder.UpdateData(
                table: "Outputs",
                keyColumn: "Id",
                keyValue: 2,
                column: "Triggers",
                value: new byte[] { 0, 3 });

            migrationBuilder.UpdateData(
                table: "Outputs",
                keyColumn: "Id",
                keyValue: 4,
                column: "Triggers",
                value: new byte[] { 0 });

            migrationBuilder.UpdateData(
                table: "Outputs",
                keyColumn: "Id",
                keyValue: 5,
                column: "Triggers",
                value: new byte[] { 0, 3 });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$.IeGNWxxdQ/KEqBVclEpc.9fPaijAevQg/5OaSS9HFHoF5p5gRLte");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$.8Pf10866.Itz4dgtMZRhumL7xuyxKQItUPAx8.VzeTf25JPf/sAK");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$.EBtR1hD3kvDJGZCf43z/et93K9JJpD6/Ezmf/KJSoymD74mN6PMm");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Outputs",
                keyColumn: "Id",
                keyValue: 1,
                column: "Triggers",
                value: null);

            migrationBuilder.UpdateData(
                table: "Outputs",
                keyColumn: "Id",
                keyValue: 2,
                column: "Triggers",
                value: null);

            migrationBuilder.UpdateData(
                table: "Outputs",
                keyColumn: "Id",
                keyValue: 4,
                column: "Triggers",
                value: null);

            migrationBuilder.UpdateData(
                table: "Outputs",
                keyColumn: "Id",
                keyValue: 5,
                column: "Triggers",
                value: null);

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
        }
    }
}
