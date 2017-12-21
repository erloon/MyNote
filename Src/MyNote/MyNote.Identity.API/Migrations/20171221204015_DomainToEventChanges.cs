using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace MyNote.Identity.API.Migrations
{
    public partial class DomainToEventChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_Addresses_AddressId",
                table: "Companies");

            migrationBuilder.DropForeignKey(
                name: "FK_Organizations_Addresses_AddressId",
                table: "Organizations");

            migrationBuilder.RenameColumn(
                name: "Modyfication",
                table: "Users",
                newName: "Modification");

            migrationBuilder.RenameColumn(
                name: "Modyfication",
                table: "Teams",
                newName: "Modification");

            migrationBuilder.RenameColumn(
                name: "Modyfication",
                table: "Resources",
                newName: "Modification");

            migrationBuilder.RenameColumn(
                name: "Modyfication",
                table: "Projects",
                newName: "Modification");

            migrationBuilder.RenameColumn(
                name: "Modyfication",
                table: "Organizations",
                newName: "Modification");

            migrationBuilder.RenameColumn(
                name: "Modyfication",
                table: "Companies",
                newName: "Modification");

            migrationBuilder.AlterColumn<Guid>(
                name: "AddressId",
                table: "Organizations",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "AddressId",
                table: "Companies",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Create",
                table: "Addresses",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "CreateBy",
                table: "Addresses",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<DateTime>(
                name: "Modification",
                table: "Addresses",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "UpdateBy",
                table: "Addresses",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_Addresses_AddressId",
                table: "Companies",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Organizations_Addresses_AddressId",
                table: "Organizations",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Companies_Addresses_AddressId",
                table: "Companies");

            migrationBuilder.DropForeignKey(
                name: "FK_Organizations_Addresses_AddressId",
                table: "Organizations");

            migrationBuilder.DropColumn(
                name: "Create",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "CreateBy",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "Modification",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "UpdateBy",
                table: "Addresses");

            migrationBuilder.RenameColumn(
                name: "Modification",
                table: "Users",
                newName: "Modyfication");

            migrationBuilder.RenameColumn(
                name: "Modification",
                table: "Teams",
                newName: "Modyfication");

            migrationBuilder.RenameColumn(
                name: "Modification",
                table: "Resources",
                newName: "Modyfication");

            migrationBuilder.RenameColumn(
                name: "Modification",
                table: "Projects",
                newName: "Modyfication");

            migrationBuilder.RenameColumn(
                name: "Modification",
                table: "Organizations",
                newName: "Modyfication");

            migrationBuilder.RenameColumn(
                name: "Modification",
                table: "Companies",
                newName: "Modyfication");

            migrationBuilder.AlterColumn<Guid>(
                name: "AddressId",
                table: "Organizations",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<Guid>(
                name: "AddressId",
                table: "Companies",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AddForeignKey(
                name: "FK_Companies_Addresses_AddressId",
                table: "Companies",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Organizations_Addresses_AddressId",
                table: "Organizations",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
