using Microsoft.EntityFrameworkCore.Migrations;

namespace DESS.Migrations
{
    public partial class SomeStatusParamettersAddedToFault : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "BatteryLevel",
                table: "Logs",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<int>(
                name: "BatteryStatus",
                table: "Logs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<short>(
                name: "HvVoltage",
                table: "Logs",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddColumn<byte>(
                name: "SignalStrength",
                table: "Logs",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<short>(
                name: "Temperature",
                table: "Logs",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$6SD8.WaWCxnpyINmHt07WuggUEdspEBspoHFDJ.8oibdCsIYWddw6");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$VmAyctxJztgdDUutZTp63ugE3B1svJogIbLoVx1Bc0qjNoWw47F/e");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$ZY/00bTbXlfvLjuZeYdP/.sV86kBhgoi.N8H56w/wQWFqI3RFZvtK");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "Password",
                value: "$2a$11$W0wXRS0yZH0lHFff0Xepg.xiZU27VBvQ20Mqcjs8RQvK.zK.nPMFa");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BatteryLevel",
                table: "Logs");

            migrationBuilder.DropColumn(
                name: "BatteryStatus",
                table: "Logs");

            migrationBuilder.DropColumn(
                name: "HvVoltage",
                table: "Logs");

            migrationBuilder.DropColumn(
                name: "SignalStrength",
                table: "Logs");

            migrationBuilder.DropColumn(
                name: "Temperature",
                table: "Logs");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$3SD1ASw5uWqlIHmqbHhAyOYCvFskJvFEPzcl8Ft5.PsKlDgenmPZm");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$wE1bGZRWyBt6lr.SMIWeweZ6AhPTvAGRdl4kYFZdabEguKt2r6q4.");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$48aJEhT9gEpt3eV8TnmAyOKiAGflH4mSZAuH0MRa5q9lWUKKfQ/1C");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "Password",
                value: "$2a$11$Mgze.LiwtE/rMz4kHepJ8e8GRsHc.iolbZs369Ml9qt.PKw4BrBkm");
        }
    }
}
