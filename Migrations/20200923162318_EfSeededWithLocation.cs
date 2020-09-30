using Microsoft.EntityFrameworkCore.Migrations;

namespace Dess.Api.Migrations
{
  public partial class EfSeededWithLocation : Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.UpdateData(
          table: "ElectroFences",
          keyColumn: "Id",
          keyValue: 1,
          columns: new[] { "Latitude", "Longitude" },
          values: new object[] { "31.7", "13.5" });

      migrationBuilder.UpdateData(
          table: "ElectroFences",
          keyColumn: "Id",
          keyValue: 2,
          columns: new[] { "Latitude", "Longitude" },
          values: new object[] { "-3.4", "113.7" });

      migrationBuilder.UpdateData(
          table: "ElectroFences",
          keyColumn: "Id",
          keyValue: 3,
          columns: new[] { "Latitude", "Longitude" },
          values: new object[] { "11.57", "-5" });

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

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.UpdateData(
          table: "ElectroFences",
          keyColumn: "Id",
          keyValue: 1,
          columns: new[] { "Latitude", "Longitude" },
          values: new object[] { null, null });

      migrationBuilder.UpdateData(
          table: "ElectroFences",
          keyColumn: "Id",
          keyValue: 2,
          columns: new[] { "Latitude", "Longitude" },
          values: new object[] { null, null });

      migrationBuilder.UpdateData(
          table: "ElectroFences",
          keyColumn: "Id",
          keyValue: 3,
          columns: new[] { "Latitude", "Longitude" },
          values: new object[] { null, null });

      migrationBuilder.UpdateData(
          table: "Users",
          keyColumn: "Id",
          keyValue: 1,
          column: "Password",
          value: "$2a$11$fAx1HD.CLiZR9axW4pJZqeIR0LwW944h5wfN9yv1nByWG7v5CVUD2");

      migrationBuilder.UpdateData(
          table: "Users",
          keyColumn: "Id",
          keyValue: 2,
          column: "Password",
          value: "$2a$11$rTuiMBDl2b56kYzzIhWAC.LihdTIUkR5c40y.foQKHaSpTSezTC3i");

      migrationBuilder.UpdateData(
          table: "Users",
          keyColumn: "Id",
          keyValue: 3,
          column: "Password",
          value: "$2a$11$ZlikfJQZmACKq3Ld9vdpAOZfa2zfXBAEcXLxlhGzYbqabncE9Qmny");
    }
  }
}
