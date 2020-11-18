using Microsoft.EntityFrameworkCore.Migrations;

namespace DESS.Migrations
{
    public partial class UserIdAddedToRefreshToken : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RefreshToken_Users_UserId",
                table: "RefreshToken");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RefreshToken",
                table: "RefreshToken");

            migrationBuilder.RenameTable(
                name: "RefreshToken",
                newName: "RefreshToekns");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RefreshToekns",
                table: "RefreshToekns",
                column: "Id");

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

            migrationBuilder.CreateIndex(
                name: "IX_RefreshToekns_UserId",
                table: "RefreshToekns",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_RefreshToekns_Users_UserId",
                table: "RefreshToekns",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RefreshToekns_Users_UserId",
                table: "RefreshToekns");

            migrationBuilder.DropPrimaryKey(
                name: "PK_RefreshToekns",
                table: "RefreshToekns");

            migrationBuilder.DropIndex(
                name: "IX_RefreshToekns_UserId",
                table: "RefreshToekns");

            migrationBuilder.RenameTable(
                name: "RefreshToekns",
                newName: "RefreshToken");

            migrationBuilder.AddPrimaryKey(
                name: "PK_RefreshToken",
                table: "RefreshToken",
                columns: new[] { "UserId", "Id" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$A8qfoNf0fsUADFTbG3CuaucZMI/ihEUXsUP5gg2UMtf.nxsGgYtV6");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$V0/06CIYt9wuw4n/vUr57OMC2pA4qbEQIgV7mtQmfVD0fVcOljN0C");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$FyvWKeU8nJSCWvUVXvOXleBmBrDHTzepKQEAq8p6EcFRhF03UAVpi");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "Password",
                value: "$2a$11$9rqhERRpm1a7B1QRxCzvNOONp8bF4aokgtHaNYnMXtQm3BMbOVpTC");

            migrationBuilder.AddForeignKey(
                name: "FK_RefreshToken_Users_UserId",
                table: "RefreshToken",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
