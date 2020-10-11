using Microsoft.EntityFrameworkCore.Migrations;

namespace Dess.Api.Migrations
{
    public partial class UserSeededWithSHA256Password : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$D6upsHn.YOa5uFqiOgNR/.kcmrpIfQoch4Tj0GU50Zoc9nyWZV5zS");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$WdqYN9RgY734539U36UbIuWpP8uQ2eongyeCfrUGsMyszje2Kmj7S");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$bJKljaUpYIhLu4jygdYp5eTP9GMmcOk8jWZycFD5G00V0Oka6wK7e");
        }
    }
}
