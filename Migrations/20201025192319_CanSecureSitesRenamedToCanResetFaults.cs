using Microsoft.EntityFrameworkCore.Migrations;

namespace DESS.Migrations
{
    public partial class CanSecureSitesRenamedToCanResetFaults : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$f4Ohw7ILtBP4iaAWKhhnCOv.bX9iLfFIaacbx/4QEM0.SRYMQGyTy");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$PqnLX3yA34sN.r.pl8jUDuqSDGGhkLOM4NhnXUIda1knqVAaJNzxe");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$uGDSrTwEysZcE.fI4yZ.IOYGWiWZusW7FHFogmEUwdEjJD/TKcX.a");
        }
    }
}
