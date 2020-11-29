using Microsoft.EntityFrameworkCore.Migrations;

namespace DESS.Migrations
{
    public partial class SiteNavigationInSiteFaultAddedWithFluentApi : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Logs_Sites_SiteId1",
                table: "Logs");

            migrationBuilder.DropIndex(
                name: "IX_Logs_SiteId1",
                table: "Logs");

            migrationBuilder.DropColumn(
                name: "SiteId1",
                table: "Logs");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$3SD1ASw5uWqlIHmqbHhAyOYCvFskJvFEPzcl8Ft5.PsKlDgenmPZm");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$wE1bGZRWyBt6lr.SMIWeweZ6AhPTvAGRdl4kYFZdabEguKt2r6q4.");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$48aJEhT9gEpt3eV8TnmAyOKiAGflH4mSZAuH0MRa5q9lWUKKfQ/1C");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "Password",
                value: "$2a$11$Mgze.LiwtE/rMz4kHepJ8e8GRsHc.iolbZs369Ml9qt.PKw4BrBkm");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SiteId1",
                table: "Logs",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$CsMAsVttDeTUcj5GyvPLB.vL/rL48GiELNqdnlG0ueU1Kf6FPciIK");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$jwTI5.3xOONRBiwQovNJKez0zx9ivZIif4oMsSL0PzcrsccB.iomm");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$Q4ewTfigLqIzNGdl5GgFvuPZ9LAiN22c/JEs7hImv4SKw5iAXhYA2");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "Password",
                value: "$2a$11$6ik4kv8HP5DETIWap2HE0OtSg8byW38IkyIjF8gVXArGcqtmVEfEa");

            migrationBuilder.CreateIndex(
                name: "IX_Logs_SiteId1",
                table: "Logs",
                column: "SiteId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Logs_Sites_SiteId1",
                table: "Logs",
                column: "SiteId1",
                principalTable: "Sites",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
