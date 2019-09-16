using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CampusClassicals.Data.Migrations.EFData
{
    public partial class AddedMediaTypeEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Mime_Type",
                table: "MEDIA",
                maxLength: 80,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 80,
                oldNullable: true);

            migrationBuilder.AlterColumn<byte[]>(
                name: "File",
                table: "MEDIA",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MediaTypeId",
                table: "GALLERY",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MediaTypeId",
                table: "EVENT",
                nullable: true);

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
                name: "IX_GALLERY_MediaTypeId",
                table: "GALLERY",
                column: "MediaTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_EVENT_MediaTypeId",
                table: "EVENT",
                column: "MediaTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_EVENT_MEDIA_TYPE_MediaTypeId",
                table: "EVENT",
                column: "MediaTypeId",
                principalTable: "MEDIA_TYPE",
                principalColumn: "Media_Type_Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GALLERY_MEDIA_TYPE_MediaTypeId",
                table: "GALLERY",
                column: "MediaTypeId",
                principalTable: "MEDIA_TYPE",
                principalColumn: "Media_Type_Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EVENT_MEDIA_TYPE_MediaTypeId",
                table: "EVENT");

            migrationBuilder.DropForeignKey(
                name: "FK_GALLERY_MEDIA_TYPE_MediaTypeId",
                table: "GALLERY");

            migrationBuilder.DropTable(
                name: "MEDIA_TYPE");

            migrationBuilder.DropIndex(
                name: "IX_GALLERY_MediaTypeId",
                table: "GALLERY");

            migrationBuilder.DropIndex(
                name: "IX_EVENT_MediaTypeId",
                table: "EVENT");

            migrationBuilder.DropColumn(
                name: "MediaTypeId",
                table: "GALLERY");

            migrationBuilder.DropColumn(
                name: "MediaTypeId",
                table: "EVENT");

            migrationBuilder.AlterColumn<string>(
                name: "Mime_Type",
                table: "MEDIA",
                maxLength: 80,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 80);

            migrationBuilder.AlterColumn<byte[]>(
                name: "File",
                table: "MEDIA",
                nullable: true,
                oldClrType: typeof(byte[]));
        }
    }
}
