using Microsoft.EntityFrameworkCore.Migrations;

namespace Dess.Api.Migrations
{
    public partial class IOSeedCorrected : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Inputs",
                columns: new[] { "Id", "Enabled", "ModuleId", "Name", "Type" },
                values: new object[,]
                {
                    { 3, true, 3, null, 0 },
                    { 6, false, 3, null, 1 }
                });

            migrationBuilder.InsertData(
                table: "Outputs",
                columns: new[] { "Id", "Enabled", "ModuleId", "Name", "ResetTime", "Triggers", "Type" },
                values: new object[,]
                {
                    { 3, true, 3, null, (short)0, "2;3", 0 },
                    { 6, false, 3, null, (short)0, "2;3", 1 }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$CQA7BDyYDY3fZHxbO66IXut0FVkMvczTLZM/jZRcq1AOm.1Whqhq.");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$hCrBZKM1hvc3SfWIEU.ixedwb0/ecHZuhXM8qGZc5VHDWRCvXRDXG");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$8uajTKdHHcQQmO5QO.O73uPm43uS3eT2BEMoYQiCOQPRmpUu5pWIy");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Inputs",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Inputs",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Outputs",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Outputs",
                keyColumn: "Id",
                keyValue: 6);

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
    }
}
