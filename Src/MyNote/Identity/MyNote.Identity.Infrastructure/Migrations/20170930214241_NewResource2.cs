using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyNote.Identity.Infrastructure.Migrations.ApplicationDb
{
    public partial class NewResource2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Resource_Organizations_OrganizationId",
                table: "Resource");

            migrationBuilder.DropForeignKey(
                name: "FK_Resource_Projects_ProjectId",
                table: "Resource");

            migrationBuilder.DropForeignKey(
                name: "FK_Resource_Teams_TeamId",
                table: "Resource");

            migrationBuilder.DropForeignKey(
                name: "FK_Resource_AspNetUsers_UserId",
                table: "Resource");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Resource",
                table: "Resource");

            migrationBuilder.RenameTable(
                name: "Resource",
                newName: "Resources");

            migrationBuilder.RenameIndex(
                name: "IX_Resource_UserId",
                table: "Resources",
                newName: "IX_Resources_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Resource_TeamId",
                table: "Resources",
                newName: "IX_Resources_TeamId");

            migrationBuilder.RenameIndex(
                name: "IX_Resource_ProjectId",
                table: "Resources",
                newName: "IX_Resources_ProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_Resource_OrganizationId",
                table: "Resources",
                newName: "IX_Resources_OrganizationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Resources",
                table: "Resources",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Resources_Organizations_OrganizationId",
                table: "Resources",
                column: "OrganizationId",
                principalTable: "Organizations",
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

            migrationBuilder.AddForeignKey(
                name: "FK_Resources_AspNetUsers_UserId",
                table: "Resources",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Resources_Organizations_OrganizationId",
                table: "Resources");

            migrationBuilder.DropForeignKey(
                name: "FK_Resources_Projects_ProjectId",
                table: "Resources");

            migrationBuilder.DropForeignKey(
                name: "FK_Resources_Teams_TeamId",
                table: "Resources");

            migrationBuilder.DropForeignKey(
                name: "FK_Resources_AspNetUsers_UserId",
                table: "Resources");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Resources",
                table: "Resources");

            migrationBuilder.RenameTable(
                name: "Resources",
                newName: "Resource");

            migrationBuilder.RenameIndex(
                name: "IX_Resources_UserId",
                table: "Resource",
                newName: "IX_Resource_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Resources_TeamId",
                table: "Resource",
                newName: "IX_Resource_TeamId");

            migrationBuilder.RenameIndex(
                name: "IX_Resources_ProjectId",
                table: "Resource",
                newName: "IX_Resource_ProjectId");

            migrationBuilder.RenameIndex(
                name: "IX_Resources_OrganizationId",
                table: "Resource",
                newName: "IX_Resource_OrganizationId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Resource",
                table: "Resource",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Resource_Organizations_OrganizationId",
                table: "Resource",
                column: "OrganizationId",
                principalTable: "Organizations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Resource_Projects_ProjectId",
                table: "Resource",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Resource_Teams_TeamId",
                table: "Resource",
                column: "TeamId",
                principalTable: "Teams",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Resource_AspNetUsers_UserId",
                table: "Resource",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
