using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Enterprise.ConfigurationServer.Migrations
{
    public partial class MenuAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationConfiguration_IntegratedApp_AppID",
                schema: "Configuration",
                table: "ApplicationConfiguration");

            migrationBuilder.RenameColumn(
                name: "AppID",
                schema: "Configuration",
                table: "ApplicationConfiguration",
                newName: "IntegratedAppID");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicationConfiguration_AppID",
                schema: "Configuration",
                table: "ApplicationConfiguration",
                newName: "IX_ApplicationConfiguration_IntegratedAppID");

            migrationBuilder.CreateTable(
                name: "ApplicationRoles",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AppID = table.Column<Guid>(nullable: false),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    NormalizedName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AppMenuCategory",
                schema: "Configuration",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    MenuCategory = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppMenuCategory", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "AppMenu",
                schema: "Configuration",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    AppMenuCategoryID = table.Column<Guid>(nullable: true),
                    IntegratedAppID = table.Column<Guid>(nullable: false),
                    MenuHref = table.Column<string>(maxLength: 100, nullable: false),
                    MenuIcon = table.Column<string>(maxLength: 100, nullable: true),
                    MenuNotification = table.Column<int>(nullable: false),
                    MenuTitle = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppMenu", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AppMenu_AppMenuCategory_AppMenuCategoryID",
                        column: x => x.AppMenuCategoryID,
                        principalSchema: "Configuration",
                        principalTable: "AppMenuCategory",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AppMenu_IntegratedApp_IntegratedAppID",
                        column: x => x.IntegratedAppID,
                        principalSchema: "Configuration",
                        principalTable: "IntegratedApp",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MenuPermittedRole",
                schema: "Configuration",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    AppMenuID = table.Column<Guid>(nullable: false),
                    ApplicationRolesID = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuPermittedRole", x => x.ID);
                    table.ForeignKey(
                        name: "FK_MenuPermittedRole_AppMenu_AppMenuID",
                        column: x => x.AppMenuID,
                        principalSchema: "Configuration",
                        principalTable: "AppMenu",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MenuPermittedRole_ApplicationRoles_ApplicationRolesID",
                        column: x => x.ApplicationRolesID,
                        principalTable: "ApplicationRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppMenu_AppMenuCategoryID",
                schema: "Configuration",
                table: "AppMenu",
                column: "AppMenuCategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_AppMenu_IntegratedAppID",
                schema: "Configuration",
                table: "AppMenu",
                column: "IntegratedAppID");

            migrationBuilder.CreateIndex(
                name: "IX_MenuPermittedRole_AppMenuID",
                schema: "Configuration",
                table: "MenuPermittedRole",
                column: "AppMenuID");

            migrationBuilder.CreateIndex(
                name: "IX_MenuPermittedRole_ApplicationRolesID",
                schema: "Configuration",
                table: "MenuPermittedRole",
                column: "ApplicationRolesID");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationConfiguration_IntegratedApp_IntegratedAppID",
                schema: "Configuration",
                table: "ApplicationConfiguration",
                column: "IntegratedAppID",
                principalSchema: "Configuration",
                principalTable: "IntegratedApp",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationConfiguration_IntegratedApp_IntegratedAppID",
                schema: "Configuration",
                table: "ApplicationConfiguration");

            migrationBuilder.DropTable(
                name: "MenuPermittedRole",
                schema: "Configuration");

            migrationBuilder.DropTable(
                name: "AppMenu",
                schema: "Configuration");

            migrationBuilder.DropTable(
                name: "ApplicationRoles");

            migrationBuilder.DropTable(
                name: "AppMenuCategory",
                schema: "Configuration");

            migrationBuilder.RenameColumn(
                name: "IntegratedAppID",
                schema: "Configuration",
                table: "ApplicationConfiguration",
                newName: "AppID");

            migrationBuilder.RenameIndex(
                name: "IX_ApplicationConfiguration_IntegratedAppID",
                schema: "Configuration",
                table: "ApplicationConfiguration",
                newName: "IX_ApplicationConfiguration_AppID");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationConfiguration_IntegratedApp_AppID",
                schema: "Configuration",
                table: "ApplicationConfiguration",
                column: "AppID",
                principalSchema: "Configuration",
                principalTable: "IntegratedApp",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
