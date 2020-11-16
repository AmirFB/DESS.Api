using Microsoft.EntityFrameworkCore.Migrations;

namespace DESS.Migrations
{
    public partial class SiteGroupUserManyToManyRelationEstablished : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Users",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "SiteGroupUser",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    GroupId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiteGroupUser", x => new { x.GroupId, x.UserId });
                    table.ForeignKey(
                        name: "FK_SiteGroupUser_SiteGroups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "SiteGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SiteGroupUser_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$M/rBwToYhm88/nMcm3o4r.3oKCtHsVW6abUWHaBpjrRynzN059STm");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Password", "Username" },
                values: new object[] { "$2a$11$Hizqi/R7FqWHxBeDfyqJ5uU.Vfdaa8GjLtG6r2nHhXDelnNntG5h6", "manager" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$ZhxOYQetIE8kJHsohAKCZu94s5Hdzdgb2dBdVrFA.eG4yMYvKHkSu");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "Password",
                value: "$2a$11$gMU.mOP2U0IG3OwvFYuRauV3QCuQc07ChA2/Bigalmc9nuZGUsuf2");

            migrationBuilder.CreateIndex(
                name: "IX_SiteGroupUser_UserId",
                table: "SiteGroupUser",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SiteGroupUser");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Users");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$w1ULiXZfdKSCSSfb8sKF9ujJ3PKbu6HvgpsuAL6MoDupR1mM9dYuq");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Password", "Username" },
                values: new object[] { "$2a$11$SyWMQBQ9t4yBf/R0NFx2TeIeoY.JPxuHq1vd4PLr0ruTdOs.qP2wi", "admin" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$lk8KfSJMtXapEHucO2P0ROn7oQPDpT16oaSWGzFKLftMmutykvK7a");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "Password",
                value: "$2a$11$5zGq766m.dTfv55EVVgCEuEffSFJI.epiP1Prka22dV4CUs1Hi1Qi");
        }
    }
}
