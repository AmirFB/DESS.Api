using Microsoft.EntityFrameworkCore.Migrations;

namespace Dess.Api.Migrations
{
  public partial class UserGroupPermissionsSeedUpdated : Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropForeignKey(
          name: "FK_UserGroupPermissions_UserGroups_GroupId",
          table: "UserGroupPermissions");

      migrationBuilder.DropForeignKey(
          name: "FK_UserGroupPermissions_UserPermissions_PermissionId",
          table: "UserGroupPermissions");

      migrationBuilder.AddColumn<string>(
          name: "SerialNo",
          table: "Statuss",
          nullable: true);

      migrationBuilder.AddColumn<string>(
          name: "Name",
          table: "IOs",
          nullable: true);

      migrationBuilder.AddColumn<int>(
          name: "Interval",
          table: "ElectroFences",
          nullable: false,
          defaultValue: 0);

      migrationBuilder.AddColumn<string>(
          name: "SerialNo",
          table: "ElectroFences",
          nullable: true);

      migrationBuilder.AddColumn<string>(
          name: "SiteId",
          table: "ElectroFences",
          nullable: false);

      migrationBuilder.AddColumn<bool>(
          name: "UseGlobalIntervarl",
          table: "ElectroFences",
          nullable: false,
          defaultValue: false);

      migrationBuilder.UpdateData(
          table: "ElectroFences",
          keyColumn: "Id",
          keyValue: 1,
          columns: new[] { "Serial", "SiteId" },
          values: new object[] { "001", "ehp-ie-tbz1" });

      migrationBuilder.UpdateData(
          table: "ElectroFences",
          keyColumn: "Id",
          keyValue: 2,
          columns: new[] { "Serial", "SiteId" },
          values: new object[] { "002", "ehp-ie-tbz2" });

      migrationBuilder.UpdateData(
          table: "ElectroFences",
          keyColumn: "Id",
          keyValue: 3,
          columns: new[] { "Serial", "SiteId" },
          values: new object[] { "003", "ehp-ie-tbz3" });

      migrationBuilder.InsertData(
          table: "UserGroupPermissions",
          columns: new[] { "GroupId", "PermissionId" },
          values: new object[] { 3, 2 });

      migrationBuilder.UpdateData(
          table: "UserGroups",
          keyColumn: "Id",
          keyValue: 1,
          column: "Title",
          value: "Almighty");

      migrationBuilder.UpdateData(
          table: "UserGroups",
          keyColumn: "Id",
          keyValue: 2,
          column: "Title",
          value: "Expert");

      migrationBuilder.UpdateData(
          table: "UserGroups",
          keyColumn: "Id",
          keyValue: 3,
          column: "Title",
          value: "Admin");

      migrationBuilder.InsertData(
          table: "UserGroups",
          columns: new[] { "Id", "Title" },
          values: new object[] { 4, "Operator" });

      migrationBuilder.UpdateData(
          table: "UserPermissions",
          keyColumn: "Id",
          keyValue: 1,
          column: "Title",
          value: "IsAlmighty");

      migrationBuilder.UpdateData(
          table: "UserPermissions",
          keyColumn: "Id",
          keyValue: 2,
          column: "Title",
          value: "CanSecureSites");

      migrationBuilder.UpdateData(
          table: "UserPermissions",
          keyColumn: "Id",
          keyValue: 3,
          column: "Title",
          value: "CanEditSites");

      migrationBuilder.UpdateData(
          table: "UserPermissions",
          keyColumn: "Id",
          keyValue: 4,
          column: "Title",
          value: "CanEditUserGroups");

      migrationBuilder.InsertData(
          table: "UserPermissions",
          columns: new[] { "Id", "Title" },
          values: new object[] { 5, "CanEditUsers" });

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

      migrationBuilder.InsertData(
          table: "UserGroupPermissions",
          columns: new[] { "GroupId", "PermissionId" },
          values: new object[,]
          {
                    { 4, 3 },
                    { 1, 5 },
                    { 2, 5 },
                    { 3, 5 }
          });

      migrationBuilder.AddForeignKey(
          name: "FK_UserGroupPermissions_UserGroups_GroupId",
          table: "UserGroupPermissions",
          column: "GroupId",
          principalTable: "UserGroups",
          principalColumn: "Id",
          onDelete: ReferentialAction.Cascade);

      migrationBuilder.AddForeignKey(
          name: "FK_UserGroupPermissions_UserPermissions_PermissionId",
          table: "UserGroupPermissions",
          column: "PermissionId",
          principalTable: "UserPermissions",
          principalColumn: "Id",
          onDelete: ReferentialAction.Cascade);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropForeignKey(
          name: "FK_UserGroupPermissions_UserGroups_GroupId",
          table: "UserGroupPermissions");

      migrationBuilder.DropForeignKey(
          name: "FK_UserGroupPermissions_UserPermissions_PermissionId",
          table: "UserGroupPermissions");

      migrationBuilder.DeleteData(
          table: "UserGroupPermissions",
          keyColumns: new[] { "GroupId", "PermissionId" },
          keyValues: new object[] { 1, 5 });

      migrationBuilder.DeleteData(
          table: "UserGroupPermissions",
          keyColumns: new[] { "GroupId", "PermissionId" },
          keyValues: new object[] { 2, 5 });

      migrationBuilder.DeleteData(
          table: "UserGroupPermissions",
          keyColumns: new[] { "GroupId", "PermissionId" },
          keyValues: new object[] { 3, 2 });

      migrationBuilder.DeleteData(
          table: "UserGroupPermissions",
          keyColumns: new[] { "GroupId", "PermissionId" },
          keyValues: new object[] { 3, 5 });

      migrationBuilder.DeleteData(
          table: "UserGroupPermissions",
          keyColumns: new[] { "GroupId", "PermissionId" },
          keyValues: new object[] { 4, 3 });

      migrationBuilder.DeleteData(
          table: "UserGroups",
          keyColumn: "Id",
          keyValue: 4);

      migrationBuilder.DeleteData(
          table: "UserPermissions",
          keyColumn: "Id",
          keyValue: 5);

      migrationBuilder.DropColumn(
          name: "SerialNo",
          table: "Statuss");

      migrationBuilder.DropColumn(
          name: "Name",
          table: "IOs");

      migrationBuilder.DropColumn(
          name: "Interval",
          table: "ElectroFences");

      migrationBuilder.DropColumn(
          name: "SerialNo",
          table: "ElectroFences");

      migrationBuilder.DropColumn(
          name: "SiteId",
          table: "ElectroFences");

      migrationBuilder.DropColumn(
          name: "UseGlobalIntervarl",
          table: "ElectroFences");

      migrationBuilder.UpdateData(
          table: "ElectroFences",
          keyColumn: "Id",
          keyValue: 1,
          column: "Serial",
          value: "ehp-ie-tbz1");

      migrationBuilder.UpdateData(
          table: "ElectroFences",
          keyColumn: "Id",
          keyValue: 2,
          column: "Serial",
          value: "ehp-ie-tbz2");

      migrationBuilder.UpdateData(
          table: "ElectroFences",
          keyColumn: "Id",
          keyValue: 3,
          column: "Serial",
          value: "ehp-ie-tbz3");

      migrationBuilder.UpdateData(
          table: "UserGroups",
          keyColumn: "Id",
          keyValue: 1,
          column: "Title",
          value: "Expert");

      migrationBuilder.UpdateData(
          table: "UserGroups",
          keyColumn: "Id",
          keyValue: 2,
          column: "Title",
          value: "Admin");

      migrationBuilder.UpdateData(
          table: "UserGroups",
          keyColumn: "Id",
          keyValue: 3,
          column: "Title",
          value: "Operator");

      migrationBuilder.UpdateData(
          table: "UserPermissions",
          keyColumn: "Id",
          keyValue: 1,
          column: "Title",
          value: "CanEditUserGroups");

      migrationBuilder.UpdateData(
          table: "UserPermissions",
          keyColumn: "Id",
          keyValue: 2,
          column: "Title",
          value: "CanEditUsers");

      migrationBuilder.UpdateData(
          table: "UserPermissions",
          keyColumn: "Id",
          keyValue: 3,
          column: "Title",
          value: "CanSecureSites");

      migrationBuilder.UpdateData(
          table: "UserPermissions",
          keyColumn: "Id",
          keyValue: 4,
          column: "Title",
          value: "CanEditSites");

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

      migrationBuilder.AddForeignKey(
          name: "FK_UserGroupPermissions_UserGroups_GroupId",
          table: "UserGroupPermissions",
          column: "GroupId",
          principalTable: "UserGroups",
          principalColumn: "Id");

      migrationBuilder.AddForeignKey(
          name: "FK_UserGroupPermissions_UserPermissions_PermissionId",
          table: "UserGroupPermissions",
          column: "PermissionId",
          principalTable: "UserPermissions",
          principalColumn: "Id");
    }
  }
}
