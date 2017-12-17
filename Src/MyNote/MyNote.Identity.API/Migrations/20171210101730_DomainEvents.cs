using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MyNote.Identity.API.Migrations
{
    public partial class DomainEvents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DomainEvent",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CompanyId = table.Column<Guid>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    Create = table.Column<DateTime>(nullable: false),
                    EntityName = table.Column<string>(nullable: true),
                    OrganizationId = table.Column<Guid>(nullable: true),
                    ProjectId = table.Column<Guid>(nullable: true),
                    ResourceId = table.Column<Guid>(nullable: true),
                    TeamId = table.Column<Guid>(nullable: true),
                    UserId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DomainEvent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DomainEvent_Companies_CompanyId",
                        column: x => x.CompanyId,
                        principalTable: "Companies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DomainEvent_Organizations_OrganizationId",
                        column: x => x.OrganizationId,
                        principalTable: "Organizations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DomainEvent_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DomainEvent_Resources_ResourceId",
                        column: x => x.ResourceId,
                        principalTable: "Resources",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DomainEvent_Teams_TeamId",
                        column: x => x.TeamId,
                        principalTable: "Teams",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_DomainEvent_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DomainEvent_CompanyId",
                table: "DomainEvent",
                column: "CompanyId");

            migrationBuilder.CreateIndex(
                name: "IX_DomainEvent_OrganizationId",
                table: "DomainEvent",
                column: "OrganizationId");

            migrationBuilder.CreateIndex(
                name: "IX_DomainEvent_ProjectId",
                table: "DomainEvent",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_DomainEvent_ResourceId",
                table: "DomainEvent",
                column: "ResourceId");

            migrationBuilder.CreateIndex(
                name: "IX_DomainEvent_TeamId",
                table: "DomainEvent",
                column: "TeamId");

            migrationBuilder.CreateIndex(
                name: "IX_DomainEvent_UserId",
                table: "DomainEvent",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DomainEvent");
        }
    }
}
