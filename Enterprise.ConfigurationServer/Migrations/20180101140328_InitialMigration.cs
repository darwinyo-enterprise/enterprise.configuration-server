using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Enterprise.ConfigurationServer.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Configuration");

            migrationBuilder.CreateTable(
                name: "IntegratedApp",
                schema: "Configuration",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    ApplicationName = table.Column<string>(maxLength: 200, nullable: false),
                    ApplicationURL = table.Column<string>(maxLength: 200, nullable: false),
                    CoreFeature = table.Column<bool>(nullable: false),
                    Integrated = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IntegratedApp", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationConfiguration",
                schema: "Configuration",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    AppID = table.Column<Guid>(nullable: false),
                    Key = table.Column<string>(nullable: false),
                    Values = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationConfiguration", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ApplicationConfiguration_IntegratedApp_AppID",
                        column: x => x.AppID,
                        principalSchema: "Configuration",
                        principalTable: "IntegratedApp",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationConfiguration_AppID",
                schema: "Configuration",
                table: "ApplicationConfiguration",
                column: "AppID");

            migrationBuilder.CreateIndex(
                name: "IX_IntegratedApp_ApplicationName",
                schema: "Configuration",
                table: "IntegratedApp",
                column: "ApplicationName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_IntegratedApp_ApplicationURL",
                schema: "Configuration",
                table: "IntegratedApp",
                column: "ApplicationURL",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationConfiguration",
                schema: "Configuration");

            migrationBuilder.DropTable(
                name: "IntegratedApp",
                schema: "Configuration");
        }
    }
}
