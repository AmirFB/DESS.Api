using Microsoft.EntityFrameworkCore.Migrations;

namespace Dess.Api.Migrations
{
  public partial class StatussRenamedToLogs : Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropForeignKey(
          name: "FK_Statuss_ElectroFences_ElectroFenceId",
          table: "Statuss");

      migrationBuilder.DropForeignKey(
          name: "FK_Statuss_ElectroFences_ElectroFenceId1",
          table: "Statuss");

      migrationBuilder.DropForeignKey(
          name: "FK_UserLogs_Statuss_LogId",
          table: "UserLogs");

      migrationBuilder.DropPrimaryKey(
          name: "PK_Statuss",
          table: "Statuss");

      migrationBuilder.RenameTable(
          name: "Statuss",
          newName: "Logs");

      migrationBuilder.RenameIndex(
          name: "IX_Statuss_ElectroFenceId1",
          table: "Logs",
          newName: "IX_Logs_ElectroFenceId1");

      migrationBuilder.RenameIndex(
          name: "IX_Statuss_ElectroFenceId",
          table: "Logs",
          newName: "IX_Logs_ElectroFenceId");

      migrationBuilder.AddPrimaryKey(
          name: "PK_Logs",
          table: "Logs",
          column: "Id");

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

      migrationBuilder.AddForeignKey(
          name: "FK_Logs_ElectroFences_ElectroFenceId",
          table: "Logs",
          column: "ElectroFenceId",
          principalTable: "ElectroFences",
          principalColumn: "Id",
          onDelete: ReferentialAction.Cascade);

      migrationBuilder.AddForeignKey(
          name: "FK_Logs_ElectroFences_ElectroFenceId1",
          table: "Logs",
          column: "ElectroFenceId1",
          principalTable: "ElectroFences",
          principalColumn: "Id",
          onDelete: ReferentialAction.Restrict);

      migrationBuilder.AddForeignKey(
          name: "FK_UserLogs_Logs_LogId",
          table: "UserLogs",
          column: "LogId",
          principalTable: "Logs",
          principalColumn: "Id",
          onDelete: ReferentialAction.Cascade);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropForeignKey(
          name: "FK_Logs_ElectroFences_ElectroFenceId",
          table: "Logs");

      migrationBuilder.DropForeignKey(
          name: "FK_Logs_ElectroFences_ElectroFenceId1",
          table: "Logs");

      migrationBuilder.DropForeignKey(
          name: "FK_UserLogs_Logs_LogId",
          table: "UserLogs");

      migrationBuilder.DropPrimaryKey(
          name: "PK_Logs",
          table: "Logs");

      migrationBuilder.RenameTable(
          name: "Logs",
          newName: "Statuss");

      migrationBuilder.RenameIndex(
          name: "IX_Logs_ElectroFenceId1",
          table: "Statuss",
          newName: "IX_Statuss_ElectroFenceId1");

      migrationBuilder.RenameIndex(
          name: "IX_Logs_ElectroFenceId",
          table: "Statuss",
          newName: "IX_Statuss_ElectroFenceId");

      migrationBuilder.AddPrimaryKey(
          name: "PK_Statuss",
          table: "Statuss",
          column: "Id");

      migrationBuilder.UpdateData(
          table: "Users",
          keyColumn: "Id",
          keyValue: 1,
          column: "Password",
          value: "$2a$11$T./eX6hqb4EZ0TF0wJKs1OCTqgoER80qlvXG0yQqV.O6t6qrmc3mC");

      migrationBuilder.UpdateData(
          table: "Users",
          keyColumn: "Id",
          keyValue: 2,
          column: "Password",
          value: "$2a$11$veWUjoIAMbF3cYYNjbDv/OYwUxLpJ.E9TDlDrOoYrnZEl7UVkZNrm");

      migrationBuilder.UpdateData(
          table: "Users",
          keyColumn: "Id",
          keyValue: 3,
          column: "Password",
          value: "$2a$11$sYRck6okOu6DLc2LAbfEpOuH8Jt1YXyXTt.RNhoQsAZhQH7USDWiC");

      migrationBuilder.AddForeignKey(
          name: "FK_Statuss_ElectroFences_ElectroFenceId",
          table: "Statuss",
          column: "ElectroFenceId",
          principalTable: "ElectroFences",
          principalColumn: "Id",
          onDelete: ReferentialAction.Cascade);

      migrationBuilder.AddForeignKey(
          name: "FK_Statuss_ElectroFences_ElectroFenceId1",
          table: "Statuss",
          column: "ElectroFenceId1",
          principalTable: "ElectroFences",
          principalColumn: "Id",
          onDelete: ReferentialAction.Restrict);

      migrationBuilder.AddForeignKey(
          name: "FK_UserLogs_Statuss_LogId",
          table: "UserLogs",
          column: "LogId",
          principalTable: "Statuss",
          principalColumn: "Id",
          onDelete: ReferentialAction.Cascade);
    }
  }
}
