using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MyNote.Identity.API.Migrations
{
    public partial class OrganizationChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Organizations_Addresses_AddressId",
                table: "Organizations");

            migrationBuilder.DropForeignKey(
                name: "FK_Organizations_Companies_CompanyId",
                table: "Organizations");

            migrationBuilder.DropIndex(
                name: "IX_Organizations_CompanyId",
                table: "Organizations");

            migrationBuilder.AlterColumn<Guid>(
                name: "CompanyId",
                table: "Organizations",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "AddressId",
                table: "Organizations",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.CreateIndex(
                name: "IX_Organizations_CompanyId",
                table: "Organizations",
                column: "CompanyId",
                unique: true,
                filter: "[CompanyId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Organizations_Addresses_AddressId",
                table: "Organizations",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Organizations_Companies_CompanyId",
                table: "Organizations",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Organizations_Addresses_AddressId",
                table: "Organizations");

            migrationBuilder.DropForeignKey(
                name: "FK_Organizations_Companies_CompanyId",
                table: "Organizations");

            migrationBuilder.DropIndex(
                name: "IX_Organizations_CompanyId",
                table: "Organizations");

            migrationBuilder.AlterColumn<Guid>(
                name: "CompanyId",
                table: "Organizations",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "AddressId",
                table: "Organizations",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Organizations_CompanyId",
                table: "Organizations",
                column: "CompanyId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Organizations_Addresses_AddressId",
                table: "Organizations",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Organizations_Companies_CompanyId",
                table: "Organizations",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
