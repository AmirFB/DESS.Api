using Microsoft.EntityFrameworkCore.Migrations;

namespace Dess.Api.Migrations
{
    public partial class IosRenamedAndChangedToCollections : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$ON7g/vFmmcKdLerEAHm7cOOP6xUmFTVmP2lglG/gBedfJuxWHofI2");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$W/EXZ1yixWJ5N.FNgggOteklbwSiOjnTWQCwQFvKa8sVd3b.dkvPC");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$olPJ6XFwCh9tnV29trJ/X.hvvDU7tcB3LEv9q8rf.vFv51YSTuvKS");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$S6kzQsOmgHqEsY4Rog56Q.k/Jn/buKEkXDzl0iRZyg1KQSdwo7KOC");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$kZeUu31bgfApeTfisyjjkuSkiK.lLvDlB/KprFY4cqKDoPQkGJHTG");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$NMMnwzqu46rUc./bJVnJ2eKcNtItT.vYDhBMoqBEre.nfC7evlNza");
        }
    }
}
