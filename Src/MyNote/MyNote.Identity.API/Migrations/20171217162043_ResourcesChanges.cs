using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MyNote.Identity.API.Migrations
{
    public partial class ResourcesChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Resources_Users_Id",
                table: "Resources");

            migrationBuilder.DropForeignKey(
                name: "FK_Resources_Projects_ProjectId",
                table: "Resources");

            migrationBuilder.DropForeignKey(
                name: "FK_Resources_Teams_TeamId",
                table: "Resources");

            migrationBuilder.DropIndex(
                name: "IX_Resources_ProjectId",
                table: "Resources");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "Resources");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Resources",
                newName: "OwnerId");

            migrationBuilder.RenameColumn(
                name: "TeamId",
                table: "Resources",
                newName: "OwnerId1");

            migrationBuilder.RenameIndex(
                name: "IX_Resources_TeamId",
                table: "Resources",
                newName: "IX_Resources_OwnerId1");

            migrationBuilder.CreateTable(
                name: "ResourceProjects",
                columns: table => new
                {
                    ProjectId = table.Column<Guid>(nullable: false),
                    ResourceId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourceProjects", x => new { x.ProjectId, x.ResourceId });
                    table.ForeignKey(
                        name: "FK_ResourceProjects_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResourceProjects_Resources_ResourceId",
                        column: x => x.ResourceId,
                        principalTable: "Resources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResourceTeams",
                columns: table => new
                {
                    ResourceId = table.Column<Guid>(nullable: false),
                    TeamId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourceTeams", x => new { x.ResourceId, x.TeamId });
                    table.ForeignKey(
                        name: "FK_ResourceTeams_Resources_ResourceId",
                        column: x => x.ResourceId,
                        principalTable: "Resources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResourceTeams_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ResourceUsers",
                columns: table => new
                {
                    ResourceId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResourceUsers", x => new { x.ResourceId, x.UserId });
                    table.ForeignKey(
                        name: "FK_ResourceUsers_Resources_ResourceId",
                        column: x => x.ResourceId,
                        principalTable: "Resources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ResourceUsers_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ResourceProjects_ResourceId",
                table: "ResourceProjects",
                column: "ResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_ResourceTeams_TeamId",
                table: "ResourceTeams",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_ResourceUsers_UserId",
                table: "ResourceUsers",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Resources_Users_OwnerId1",
                table: "Resources",
                column: "OwnerId1",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Resources_Users_OwnerId1",
                table: "Resources");

            migrationBuilder.DropTable(
                name: "ResourceProjects");

            migrationBuilder.DropTable(
                name: "ResourceTeams");

            migrationBuilder.DropTable(
                name: "ResourceUsers");

            migrationBuilder.RenameColumn(
                name: "OwnerId1",
                table: "Resources",
                newName: "TeamId");

            migrationBuilder.RenameColumn(
                name: "OwnerId",
                table: "Resources",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Resources_OwnerId1",
                table: "Resources",
                newName: "IX_Resources_TeamId");

            migrationBuilder.AddColumn<Guid>(
                name: "ProjectId",
                table: "Resources",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Resources_ProjectId",
                table: "Resources",
                column: "ProjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Resources_Users_Id",
                table: "Resources",
                column: "Id",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Resources_Projects_ProjectId",
                table: "Resources",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Resources_Teams_TeamId",
                table: "Resources",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
