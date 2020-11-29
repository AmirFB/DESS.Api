using Microsoft.EntityFrameworkCore.Migrations;

namespace DESS.Migrations
{
    public partial class SiteNavigationAddedToSiteFault : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SiteId1",
                table: "Logs",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$Aknm6XVVdKA3ynzzbmMAz.0cEZUADtT71OBmEF.s8MFi8awXt5r96");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$RSthzf4K4r8oiBHZ3cNd0uhpZUveAFZsYuf5dVkemQ4VFbBaArsuW");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$ZxC2cbkYWbynsscazrvuY.fA0Oq2r3K4O3DQiIZPKR.IuTHsRPO0C");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "Password",
                value: "$2a$11$BTaL3BobUL3sJbnp.7cuveMsLFAMULA/JCFzpjMVLi8Zbo4vb/5Y.");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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
