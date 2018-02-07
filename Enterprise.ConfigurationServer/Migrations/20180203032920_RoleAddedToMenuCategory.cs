using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Enterprise.ConfigurationServer.Migrations
{
    public partial class RoleAddedToMenuCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuPermittedRole_AppMenu_AppMenuID",
                schema: "Configuration",
                table: "MenuPermittedRole");

            migrationBuilder.AlterColumn<Guid>(
                name: "AppMenuID",
                schema: "Configuration",
                table: "MenuPermittedRole",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddColumn<Guid>(
                name: "AppMenuCategoryID",
                schema: "Configuration",
                table: "MenuPermittedRole",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MenuPermittedRole_AppMenuCategoryID",
                schema: "Configuration",
                table: "MenuPermittedRole",
                column: "AppMenuCategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuPermittedRole_AppMenuCategory_AppMenuCategoryID",
                schema: "Configuration",
                table: "MenuPermittedRole",
                column: "AppMenuCategoryID",
                principalSchema: "Configuration",
                principalTable: "AppMenuCategory",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MenuPermittedRole_AppMenu_AppMenuID",
                schema: "Configuration",
                table: "MenuPermittedRole",
                column: "AppMenuID",
                principalSchema: "Configuration",
                principalTable: "AppMenu",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuPermittedRole_AppMenuCategory_AppMenuCategoryID",
                schema: "Configuration",
                table: "MenuPermittedRole");

            migrationBuilder.DropForeignKey(
                name: "FK_MenuPermittedRole_AppMenu_AppMenuID",
                schema: "Configuration",
                table: "MenuPermittedRole");

            migrationBuilder.DropIndex(
                name: "IX_MenuPermittedRole_AppMenuCategoryID",
                schema: "Configuration",
                table: "MenuPermittedRole");

            migrationBuilder.DropColumn(
                name: "AppMenuCategoryID",
                schema: "Configuration",
                table: "MenuPermittedRole");

            migrationBuilder.AlterColumn<Guid>(
                name: "AppMenuID",
                schema: "Configuration",
                table: "MenuPermittedRole",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MenuPermittedRole_AppMenu_AppMenuID",
                schema: "Configuration",
                table: "MenuPermittedRole",
                column: "AppMenuID",
                principalSchema: "Configuration",
                principalTable: "AppMenu",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
