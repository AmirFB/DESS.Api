using Microsoft.EntityFrameworkCore.Migrations;

namespace Dess.Api.Migrations
{
  public partial class IOsNotRequiredAnymore : Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.UpdateData(
          table: "Users",
          keyColumn: "Id",
          keyValue: 1,
          column: "Password",
          value: "$2a$11$RVKn6Mb5t/6hVwftv8h6BOunfd99z/NidcKivjNXegHUgLvjtCfBW");

      migrationBuilder.UpdateData(
          table: "Users",
          keyColumn: "Id",
          keyValue: 2,
          column: "Password",
          value: "$2a$11$/D/Q9Igl0YoKDkB1Sh3p/OfszBNe7tAt27y/LwViz56AjdrijVK6C");

      migrationBuilder.UpdateData(
          table: "Users",
          keyColumn: "Id",
          keyValue: 3,
          column: "Password",
          value: "$2a$11$6Txv4oQGTQNC8VP2iZOgcelrmco19JFxHW5lERz/jzYXGo82vO8R2");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.UpdateData(
          table: "Users",
          keyColumn: "Id",
          keyValue: 1,
          column: "Password",
          value: "$2a$11$UrN2ydims7VY35ryIYUR7.m3d1bEJjGY5lzdz3JrTqOIQvFQyhP4q");

      migrationBuilder.UpdateData(
          table: "Users",
          keyColumn: "Id",
          keyValue: 2,
          column: "Password",
          value: "$2a$11$hpYQz8oI/7XY7Uuc8/mgJ.Grnt4H.YoV9iBLOWQIGXE7jLs7eVGwS");

      migrationBuilder.UpdateData(
          table: "Users",
          keyColumn: "Id",
          keyValue: 3,
          column: "Password",
          value: "$2a$11$7FuHvomlXggFz7hFzxKnDeC9KrNTsLOj0lBFyd/M6jTv3dBDLBR1O");
    }
  }
}
