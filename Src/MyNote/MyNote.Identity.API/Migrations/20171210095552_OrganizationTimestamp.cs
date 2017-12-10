using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MyNote.Identity.API.Migrations
{
    public partial class OrganizationTimestamp : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TimeSpan",
                table: "Organizations");

            migrationBuilder.AddColumn<byte[]>(
                name: "Timestamp",
                table: "Organizations",
                rowVersion: true,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Timestamp",
                table: "Organizations");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "TimeSpan",
                table: "Organizations",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }
    }
}
