using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MyNote.Identity.Infrastructure.Migrations.ApplicationDb
{
    public partial class NewResource3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserProjrcts_Projects_ProjectId",
                table: "UserProjrcts");

            migrationBuilder.DropForeignKey(
                name: "FK_UserProjrcts_AspNetUsers_UserId",
                table: "UserProjrcts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserProjrcts",
                table: "UserProjrcts");

            migrationBuilder.RenameTable(
                name: "UserProjrcts",
                newName: "UserProjects");

            migrationBuilder.RenameIndex(
                name: "IX_UserProjrcts_UserId",
                table: "UserProjects",
                newName: "IX_UserProjects_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserProjects",
                table: "UserProjects",
                columns: new[] { "ProjectId", "UserId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserProjects_Projects_ProjectId",
                table: "UserProjects",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserProjects_AspNetUsers_UserId",
                table: "UserProjects",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserProjects_Projects_ProjectId",
                table: "UserProjects");

            migrationBuilder.DropForeignKey(
                name: "FK_UserProjects_AspNetUsers_UserId",
                table: "UserProjects");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserProjects",
                table: "UserProjects");

            migrationBuilder.RenameTable(
                name: "UserProjects",
                newName: "UserProjrcts");

            migrationBuilder.RenameIndex(
                name: "IX_UserProjects_UserId",
                table: "UserProjrcts",
                newName: "IX_UserProjrcts_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserProjrcts",
                table: "UserProjrcts",
                columns: new[] { "ProjectId", "UserId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserProjrcts_Projects_ProjectId",
                table: "UserProjrcts",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserProjrcts_AspNetUsers_UserId",
                table: "UserProjrcts",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
