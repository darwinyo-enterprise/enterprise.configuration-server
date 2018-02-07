using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Enterprise.ConfigurationServer.Migrations
{
    public partial class AppMenuProjectAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "AppMenuLayoutID",
                schema: "Configuration",
                table: "AppMenuCategory",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "AppMenuLayoutID",
                schema: "Configuration",
                table: "AppMenu",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AppMenuLayout",
                schema: "Configuration",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    LayoutName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppMenuLayout", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AppMenuCategory_AppMenuLayoutID",
                schema: "Configuration",
                table: "AppMenuCategory",
                column: "AppMenuLayoutID");

            migrationBuilder.CreateIndex(
                name: "IX_AppMenu_AppMenuLayoutID",
                schema: "Configuration",
                table: "AppMenu",
                column: "AppMenuLayoutID");

            migrationBuilder.AddForeignKey(
                name: "FK_AppMenu_AppMenuLayout_AppMenuLayoutID",
                schema: "Configuration",
                table: "AppMenu",
                column: "AppMenuLayoutID",
                principalSchema: "Configuration",
                principalTable: "AppMenuLayout",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_AppMenuCategory_AppMenuLayout_AppMenuLayoutID",
                schema: "Configuration",
                table: "AppMenuCategory",
                column: "AppMenuLayoutID",
                principalSchema: "Configuration",
                principalTable: "AppMenuLayout",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppMenu_AppMenuLayout_AppMenuLayoutID",
                schema: "Configuration",
                table: "AppMenu");

            migrationBuilder.DropForeignKey(
                name: "FK_AppMenuCategory_AppMenuLayout_AppMenuLayoutID",
                schema: "Configuration",
                table: "AppMenuCategory");

            migrationBuilder.DropTable(
                name: "AppMenuLayout",
                schema: "Configuration");

            migrationBuilder.DropIndex(
                name: "IX_AppMenuCategory_AppMenuLayoutID",
                schema: "Configuration",
                table: "AppMenuCategory");

            migrationBuilder.DropIndex(
                name: "IX_AppMenu_AppMenuLayoutID",
                schema: "Configuration",
                table: "AppMenu");

            migrationBuilder.DropColumn(
                name: "AppMenuLayoutID",
                schema: "Configuration",
                table: "AppMenuCategory");

            migrationBuilder.DropColumn(
                name: "AppMenuLayoutID",
                schema: "Configuration",
                table: "AppMenu");
        }
    }
}
