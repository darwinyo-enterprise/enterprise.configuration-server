using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Enterprise.ConfigurationServer.Migrations
{
    public partial class FixDependenciesWithAuthScheme : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MenuPermittedRole_ApplicationRoles_ApplicationRolesID",
                schema: "Configuration",
                table: "MenuPermittedRole");

            migrationBuilder.DropTable(
                name: "ApplicationRoles");

            migrationBuilder.DropIndex(
                name: "IX_MenuPermittedRole_ApplicationRolesID",
                schema: "Configuration",
                table: "MenuPermittedRole");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateIndex(
                name: "IX_MenuPermittedRole_ApplicationRolesID",
                schema: "Configuration",
                table: "MenuPermittedRole",
                column: "ApplicationRolesID");

            migrationBuilder.AddForeignKey(
                name: "FK_MenuPermittedRole_ApplicationRoles_ApplicationRolesID",
                schema: "Configuration",
                table: "MenuPermittedRole",
                column: "ApplicationRolesID",
                principalTable: "ApplicationRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
