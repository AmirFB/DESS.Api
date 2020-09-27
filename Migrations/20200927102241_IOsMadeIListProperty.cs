using Microsoft.EntityFrameworkCore.Migrations;

namespace DESS.Migrations
{
    public partial class IOsMadeIListProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$SpueU3OEzBSvONvNvn0dZeZvTDFcytH.HTq2emPfvt1mWNPcIWwo2");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$ru5bQNzuKWIKRxQNwID.Xe2GTybmR4.tcnPm3EWOIHJcVkeR44mrO");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$fSpn1dS0o55KfU881mrvhex8p.TLdfOnM4ZnXEAkdccEo8loPAzaS");
        }
    }
}
