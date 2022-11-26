using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class MenuPermissionRoleForeginKeyRemoved : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuRolePermission_AspNetRoles_RoleId",
                table: "MenuRolePermission");

            migrationBuilder.DropIndex(
                name: "IX_MenuRolePermission_RoleId",
                table: "MenuRolePermission");

            migrationBuilder.AlterColumn<string>(
                name: "RoleId",
                table: "MenuRolePermission",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "RoleId",
                table: "MenuRolePermission",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MenuRolePermission_RoleId",
                table: "MenuRolePermission",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuRolePermission_AspNetRoles_RoleId",
                table: "MenuRolePermission",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
