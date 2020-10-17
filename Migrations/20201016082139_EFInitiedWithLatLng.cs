using Microsoft.EntityFrameworkCore.Migrations;

namespace Dess.Api.Migrations
{
    public partial class EFInitiedWithLatLng : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IpAddress",
                table: "ElectroFences");

            migrationBuilder.UpdateData(
                table: "ElectroFences",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Latitude", "Longitude", "SiteId" },
                values: new object[] { "38.0962", "46.2738", "ehp-ie-tbz" });

            migrationBuilder.UpdateData(
                table: "ElectroFences",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Latitude", "Longitude", "SiteId" },
                values: new object[] { "35.6892", "51.3890", "ehp-ie-thr" });

            migrationBuilder.UpdateData(
                table: "ElectroFences",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Latitude", "Longitude", "SiteId" },
                values: new object[] { "32.6539", "51.6660", "ehp-ie-isf" });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IpAddress",
                table: "ElectroFences",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "ElectroFences",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Latitude", "Longitude", "SiteId" },
                values: new object[] { "31.7", "13.5", "ehp-ie-tbz1" });

            migrationBuilder.UpdateData(
                table: "ElectroFences",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Latitude", "Longitude", "SiteId" },
                values: new object[] { "-3.4", "113.7", "ehp-ie-tbz2" });

            migrationBuilder.UpdateData(
                table: "ElectroFences",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Latitude", "Longitude", "SiteId" },
                values: new object[] { "11.57", "-5", "ehp-ie-tbz3" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$X7PdWv3W9yCJWZJ91kLVtOtx8st1S5qiKNNqIlBkiOk16xmzyrIbO");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$OgnMPB.S9SRY1GZ0EvD7q.saSg//v6JFE2xt7fEv52C9yZ4BetKFO");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$b3Q2xPBpHyozdlPsFfCe4.LME6fNv6BE4daoZ55wZOxLk8szWuL1O");
        }
    }
}
