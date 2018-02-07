using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Enterprise.ConfigurationServer.Migrations
{
    public partial class IntegratedAppAddedToMenuCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "IntegratedAppID",
                schema: "Configuration",
                table: "AppMenuCategory",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_AppMenuCategory_IntegratedAppID",
                schema: "Configuration",
                table: "AppMenuCategory",
                column: "IntegratedAppID");

            migrationBuilder.AddForeignKey(
                name: "FK_AppMenuCategory_IntegratedApp_IntegratedAppID",
                schema: "Configuration",
                table: "AppMenuCategory",
                column: "IntegratedAppID",
                principalSchema: "Configuration",
                principalTable: "IntegratedApp",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppMenuCategory_IntegratedApp_IntegratedAppID",
                schema: "Configuration",
                table: "AppMenuCategory");

            migrationBuilder.DropIndex(
                name: "IX_AppMenuCategory_IntegratedAppID",
                schema: "Configuration",
                table: "AppMenuCategory");

            migrationBuilder.DropColumn(
                name: "IntegratedAppID",
                schema: "Configuration",
                table: "AppMenuCategory");
        }
    }
}
