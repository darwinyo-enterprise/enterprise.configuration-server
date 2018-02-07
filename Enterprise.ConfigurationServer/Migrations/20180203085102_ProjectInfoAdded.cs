using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Enterprise.ConfigurationServer.Migrations
{
    public partial class ProjectInfoAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ProjectID",
                schema: "Configuration",
                table: "IntegratedApp",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Project",
                schema: "Configuration",
                columns: table => new
                {
                    ID = table.Column<Guid>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    ProjectName = table.Column<string>(maxLength: 200, nullable: false),
                    ProjectVersion = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_IntegratedApp_ProjectID",
                schema: "Configuration",
                table: "IntegratedApp",
                column: "ProjectID");

            migrationBuilder.AddForeignKey(
                name: "FK_IntegratedApp_Project_ProjectID",
                schema: "Configuration",
                table: "IntegratedApp",
                column: "ProjectID",
                principalSchema: "Configuration",
                principalTable: "Project",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_IntegratedApp_Project_ProjectID",
                schema: "Configuration",
                table: "IntegratedApp");

            migrationBuilder.DropTable(
                name: "Project",
                schema: "Configuration");

            migrationBuilder.DropIndex(
                name: "IX_IntegratedApp_ProjectID",
                schema: "Configuration",
                table: "IntegratedApp");

            migrationBuilder.DropColumn(
                name: "ProjectID",
                schema: "Configuration",
                table: "IntegratedApp");
        }
    }
}
