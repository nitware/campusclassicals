using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CampusClassicals.Data.Migrations.EFData
{
    public partial class AddedSomeMediaEntities2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UpdatedBy",
                table: "MEDIA",
                newName: "Updated_By");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "MEDIA",
                newName: "Created_By");

            migrationBuilder.RenameColumn(
                name: "UpdatedBy",
                table: "GALLERY",
                newName: "Updated_By");

            migrationBuilder.RenameColumn(
                name: "CreatedBy",
                table: "GALLERY",
                newName: "Created_By");

            migrationBuilder.RenameColumn(
                name: "UpdatedBy",
                table: "EVENT",
                newName: "Updated_By");

            migrationBuilder.RenameColumn(
                name: "PostedOn",
                table: "EVENT",
                newName: "Posted_On");

            migrationBuilder.RenameColumn(
                name: "PostedBy",
                table: "EVENT",
                newName: "Posted_By");

            migrationBuilder.AlterColumn<string>(
                name: "Updated_By",
                table: "MEDIA",
                maxLength: 450,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Created_By",
                table: "MEDIA",
                maxLength: 450,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Updated_By",
                table: "GALLERY",
                maxLength: 450,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Created_By",
                table: "GALLERY",
                maxLength: 450,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Updated_By",
                table: "EVENT",
                maxLength: 450,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Posted_By",
                table: "EVENT",
                maxLength: 450,
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Published",
                table: "EVENT",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Published",
                table: "EVENT");

            migrationBuilder.RenameColumn(
                name: "Updated_By",
                table: "MEDIA",
                newName: "UpdatedBy");

            migrationBuilder.RenameColumn(
                name: "Created_By",
                table: "MEDIA",
                newName: "CreatedBy");

            migrationBuilder.RenameColumn(
                name: "Updated_By",
                table: "GALLERY",
                newName: "UpdatedBy");

            migrationBuilder.RenameColumn(
                name: "Created_By",
                table: "GALLERY",
                newName: "CreatedBy");

            migrationBuilder.RenameColumn(
                name: "Updated_By",
                table: "EVENT",
                newName: "UpdatedBy");

            migrationBuilder.RenameColumn(
                name: "Posted_On",
                table: "EVENT",
                newName: "PostedOn");

            migrationBuilder.RenameColumn(
                name: "Posted_By",
                table: "EVENT",
                newName: "PostedBy");

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "MEDIA",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 450,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "MEDIA",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 450);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "GALLERY",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 450,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CreatedBy",
                table: "GALLERY",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 450);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedBy",
                table: "EVENT",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 450,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PostedBy",
                table: "EVENT",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 450);
        }
    }
}
