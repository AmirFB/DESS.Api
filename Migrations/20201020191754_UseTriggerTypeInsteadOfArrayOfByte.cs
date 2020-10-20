using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Dess.Api.Migrations
{
    public partial class UseTriggerTypeInsteadOfArrayOfByte : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Triggers",
                table: "Outputs",
                nullable: true,
                oldClrType: typeof(byte[]),
                oldType: "longblob",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Outputs",
                keyColumn: "Id",
                keyValue: 1,
                column: "Triggers",
                value: "0");

            migrationBuilder.UpdateData(
                table: "Outputs",
                keyColumn: "Id",
                keyValue: 2,
                column: "Triggers",
                value: "1;3");

            migrationBuilder.UpdateData(
                table: "Outputs",
                keyColumn: "Id",
                keyValue: 4,
                column: "Triggers",
                value: "0");

            migrationBuilder.UpdateData(
                table: "Outputs",
                keyColumn: "Id",
                keyValue: 5,
                column: "Triggers",
                value: "1;3");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$zYJP/hCq00HwjsOJgRwm7uVXTnQfqtRzbC1AQceoxCCBmkootkhja");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$qILP/ohBmMJGHoV1X5A6AuX.eh9401Q5m.xBPbYBDPXO4PSxY/wye");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$qVqP51SyrKmUwM.cUpAfNuxvU6.5DbQLBdjVUhN9I9PpdIFAIsWI.");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "Triggers",
                table: "Outputs",
                type: "longblob",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

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
    }
}
