using Microsoft.EntityFrameworkCore.Migrations;

namespace DESS.Migrations
{
    public partial class TimeoutIncludedInEF : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte>(
                name: "Timeout",
                table: "ElectroFences",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$hjfCL1aayxBcXqWcI7ZM5.5Rs.HbXOs55E4LwPzaZ8YIuyMdPgDKO");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$pr7NPoY4c0eHSo1/yY07gudB3MoruGgyBLLempVj7d0owKDIdA.I2");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$/TpTm1qbI44fV/s5Py5VjOKv4fP8/GrC2mat2Ansd5yRkE6Vgdc.K");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Timeout",
                table: "ElectroFences");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$ewvxCMBDG3EF55C./g9ar.z7n83gzDY0871u00FmKg/QoJNI/leni");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$dVViunrxFIL/S9jmvUfm2OUleFUvMXqYE1VgBP7j7K9XPb5lZJrnS");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$.V6tyHah4oQzAygGOmqXDuKHddfguSPp8zwkB2UysAZXEd2/Qqq9m");
        }
    }
}
