using Microsoft.EntityFrameworkCore.Migrations;

namespace Dess.Api.Migrations
{
    public partial class EFsSeededWithInterval : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ElectroFences",
                keyColumn: "Id",
                keyValue: 1,
                column: "Interval",
                value: 10);

            migrationBuilder.UpdateData(
                table: "ElectroFences",
                keyColumn: "Id",
                keyValue: 2,
                column: "Interval",
                value: 15);

            migrationBuilder.UpdateData(
                table: "ElectroFences",
                keyColumn: "Id",
                keyValue: 3,
                column: "Interval",
                value: 20);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$Vj05SekvGCex.9lnhK73t.IXPzRK2n6zG2RiUDVHvy9UX3aVCRtTi");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$OApRnuxDa3HNelMzSfrtmub1zlzki34XG/.DHv03In5YAEYX/PC.C");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$E4w7aUdhJxb7NBUc36pIQu4dTliZaliqo6kjVD03ik0pgnNcFC1na");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "ElectroFences",
                keyColumn: "Id",
                keyValue: 1,
                column: "Interval",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ElectroFences",
                keyColumn: "Id",
                keyValue: 2,
                column: "Interval",
                value: 0);

            migrationBuilder.UpdateData(
                table: "ElectroFences",
                keyColumn: "Id",
                keyValue: 3,
                column: "Interval",
                value: 0);

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
    }
}
