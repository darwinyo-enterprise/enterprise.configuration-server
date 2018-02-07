using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Enterprise.ConfigurationServer.Migrations
{
    public partial class MenuOrders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MenuCategoryOrder",
                schema: "Configuration",
                table: "AppMenuCategory",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "MainMenu",
                schema: "Configuration",
                table: "AppMenu",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "MenuOrder",
                schema: "Configuration",
                table: "AppMenu",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MenuCategoryOrder",
                schema: "Configuration",
                table: "AppMenuCategory");

            migrationBuilder.DropColumn(
                name: "MainMenu",
                schema: "Configuration",
                table: "AppMenu");

            migrationBuilder.DropColumn(
                name: "MenuOrder",
                schema: "Configuration",
                table: "AppMenu");
        }
    }
}
