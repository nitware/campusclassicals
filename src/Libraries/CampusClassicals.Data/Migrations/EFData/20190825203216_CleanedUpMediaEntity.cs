using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CampusClassicals.Data.Migrations.EFData
{
    public partial class CleanedUpMediaEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EVENT_MEDIA_TYPE_Media_Type_Id",
                table: "EVENT");

            migrationBuilder.DropForeignKey(
                name: "FK_GALLERY_MEDIA_TYPE_Media_Type_Id",
                table: "GALLERY");

            migrationBuilder.DropTable(
                name: "MEDIA_TYPE");

            migrationBuilder.DropIndex(
                name: "IX_GALLERY_Media_Type_Id",
                table: "GALLERY");

            migrationBuilder.DropIndex(
                name: "IX_EVENT_Media_Type_Id",
                table: "EVENT");

            migrationBuilder.DropColumn(
                name: "Created_By",
                table: "MEDIA");

            migrationBuilder.DropColumn(
                name: "Created_On",
                table: "MEDIA");

            migrationBuilder.DropColumn(
                name: "Height",
                table: "MEDIA");

            migrationBuilder.DropColumn(
                name: "Mime_Type",
                table: "MEDIA");

            migrationBuilder.DropColumn(
                name: "Updated_By",
                table: "MEDIA");

            migrationBuilder.DropColumn(
                name: "Updated_On",
                table: "MEDIA");

            migrationBuilder.DropColumn(
                name: "Width",
                table: "MEDIA");

            migrationBuilder.DropColumn(
                name: "Media_Type_Id",
                table: "GALLERY");

            migrationBuilder.DropColumn(
                name: "Media_Type_Id",
                table: "EVENT");

            migrationBuilder.AlterColumn<byte[]>(
                name: "File",
                table: "MEDIA",
                nullable: true,
                oldClrType: typeof(byte[]));

            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "MEDIA",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Height",
                table: "GALLERY",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Mime_Type",
                table: "GALLERY",
                maxLength: 80,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "Width",
                table: "GALLERY",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Url",
                table: "MEDIA");

            migrationBuilder.DropColumn(
                name: "Height",
                table: "GALLERY");

            migrationBuilder.DropColumn(
                name: "Mime_Type",
                table: "GALLERY");

            migrationBuilder.DropColumn(
                name: "Width",
                table: "GALLERY");

            migrationBuilder.AlterColumn<byte[]>(
                name: "File",
                table: "MEDIA",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Created_By",
                table: "MEDIA",
                maxLength: 450,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "Created_On",
                table: "MEDIA",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "Height",
                table: "MEDIA",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Mime_Type",
                table: "MEDIA",
                maxLength: 80,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Updated_By",
                table: "MEDIA",
                maxLength: 450,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Updated_On",
                table: "MEDIA",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Width",
                table: "MEDIA",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Media_Type_Id",
                table: "GALLERY",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Media_Type_Id",
                table: "EVENT",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "MEDIA_TYPE",
                columns: table => new
                {
                    Media_Type_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Media_Type_Description = table.Column<string>(maxLength: 250, nullable: true),
                    Media_Type_Name = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MEDIA_TYPE", x => x.Media_Type_Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GALLERY_Media_Type_Id",
                table: "GALLERY",
                column: "Media_Type_Id");

            migrationBuilder.CreateIndex(
                name: "IX_EVENT_Media_Type_Id",
                table: "EVENT",
                column: "Media_Type_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EVENT_MEDIA_TYPE_Media_Type_Id",
                table: "EVENT",
                column: "Media_Type_Id",
                principalTable: "MEDIA_TYPE",
                principalColumn: "Media_Type_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GALLERY_MEDIA_TYPE_Media_Type_Id",
                table: "GALLERY",
                column: "Media_Type_Id",
                principalTable: "MEDIA_TYPE",
                principalColumn: "Media_Type_Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
