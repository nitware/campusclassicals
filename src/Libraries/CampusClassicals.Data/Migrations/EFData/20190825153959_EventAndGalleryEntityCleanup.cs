using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CampusClassicals.Data.Migrations.EFData
{
    public partial class EventAndGalleryEntityCleanup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EVENT_MEDIA_MediaId",
                table: "EVENT");

            migrationBuilder.DropForeignKey(
                name: "FK_EVENT_MEDIA_TYPE_MediaTypeId",
                table: "EVENT");

            migrationBuilder.DropForeignKey(
                name: "FK_GALLERY_MEDIA_MediaId",
                table: "GALLERY");

            migrationBuilder.DropForeignKey(
                name: "FK_GALLERY_MEDIA_TYPE_MediaTypeId",
                table: "GALLERY");

            migrationBuilder.RenameColumn(
                name: "MediaTypeId",
                table: "GALLERY",
                newName: "Media_Type_Id");

            migrationBuilder.RenameColumn(
                name: "MediaId",
                table: "GALLERY",
                newName: "Media_Id");

            migrationBuilder.RenameIndex(
                name: "IX_GALLERY_MediaTypeId",
                table: "GALLERY",
                newName: "IX_GALLERY_Media_Type_Id");

            migrationBuilder.RenameIndex(
                name: "IX_GALLERY_MediaId",
                table: "GALLERY",
                newName: "IX_GALLERY_Media_Id");

            migrationBuilder.RenameColumn(
                name: "MediaTypeId",
                table: "EVENT",
                newName: "Media_Type_Id");

            migrationBuilder.RenameColumn(
                name: "MediaId",
                table: "EVENT",
                newName: "Media_Id");

            migrationBuilder.RenameIndex(
                name: "IX_EVENT_MediaTypeId",
                table: "EVENT",
                newName: "IX_EVENT_Media_Type_Id");

            migrationBuilder.RenameIndex(
                name: "IX_EVENT_MediaId",
                table: "EVENT",
                newName: "IX_EVENT_Media_Id");

            migrationBuilder.AlterColumn<int>(
                name: "Media_Type_Id",
                table: "GALLERY",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Media_Type_Id",
                table: "EVENT",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_EVENT_MEDIA_Media_Id",
                table: "EVENT",
                column: "Media_Id",
                principalTable: "MEDIA",
                principalColumn: "Media_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EVENT_MEDIA_TYPE_Media_Type_Id",
                table: "EVENT",
                column: "Media_Type_Id",
                principalTable: "MEDIA_TYPE",
                principalColumn: "Media_Type_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GALLERY_MEDIA_Media_Id",
                table: "GALLERY",
                column: "Media_Id",
                principalTable: "MEDIA",
                principalColumn: "Media_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GALLERY_MEDIA_TYPE_Media_Type_Id",
                table: "GALLERY",
                column: "Media_Type_Id",
                principalTable: "MEDIA_TYPE",
                principalColumn: "Media_Type_Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EVENT_MEDIA_Media_Id",
                table: "EVENT");

            migrationBuilder.DropForeignKey(
                name: "FK_EVENT_MEDIA_TYPE_Media_Type_Id",
                table: "EVENT");

            migrationBuilder.DropForeignKey(
                name: "FK_GALLERY_MEDIA_Media_Id",
                table: "GALLERY");

            migrationBuilder.DropForeignKey(
                name: "FK_GALLERY_MEDIA_TYPE_Media_Type_Id",
                table: "GALLERY");

            migrationBuilder.RenameColumn(
                name: "Media_Type_Id",
                table: "GALLERY",
                newName: "MediaTypeId");

            migrationBuilder.RenameColumn(
                name: "Media_Id",
                table: "GALLERY",
                newName: "MediaId");

            migrationBuilder.RenameIndex(
                name: "IX_GALLERY_Media_Type_Id",
                table: "GALLERY",
                newName: "IX_GALLERY_MediaTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_GALLERY_Media_Id",
                table: "GALLERY",
                newName: "IX_GALLERY_MediaId");

            migrationBuilder.RenameColumn(
                name: "Media_Type_Id",
                table: "EVENT",
                newName: "MediaTypeId");

            migrationBuilder.RenameColumn(
                name: "Media_Id",
                table: "EVENT",
                newName: "MediaId");

            migrationBuilder.RenameIndex(
                name: "IX_EVENT_Media_Type_Id",
                table: "EVENT",
                newName: "IX_EVENT_MediaTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_EVENT_Media_Id",
                table: "EVENT",
                newName: "IX_EVENT_MediaId");

            migrationBuilder.AlterColumn<int>(
                name: "MediaTypeId",
                table: "GALLERY",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "MediaTypeId",
                table: "EVENT",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_EVENT_MEDIA_MediaId",
                table: "EVENT",
                column: "MediaId",
                principalTable: "MEDIA",
                principalColumn: "Media_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EVENT_MEDIA_TYPE_MediaTypeId",
                table: "EVENT",
                column: "MediaTypeId",
                principalTable: "MEDIA_TYPE",
                principalColumn: "Media_Type_Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_GALLERY_MEDIA_MediaId",
                table: "GALLERY",
                column: "MediaId",
                principalTable: "MEDIA",
                principalColumn: "Media_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_GALLERY_MEDIA_TYPE_MediaTypeId",
                table: "GALLERY",
                column: "MediaTypeId",
                principalTable: "MEDIA_TYPE",
                principalColumn: "Media_Type_Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
