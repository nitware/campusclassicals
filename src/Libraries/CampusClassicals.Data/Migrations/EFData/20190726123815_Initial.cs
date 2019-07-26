using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CampusClassicals.Data.Migrations.EFData
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MEDIA_TYPE",
                columns: table => new
                {
                    Media_Type_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Media_Type_Description = table.Column<string>(nullable: true),
                    Media_Type_Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MEDIA_TYPE", x => x.Media_Type_Id);
                });

            migrationBuilder.CreateTable(
                name: "RIGHT",
                columns: table => new
                {
                    Right_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Right_Description = table.Column<string>(maxLength: 250, nullable: true),
                    Right_Name = table.Column<string>(maxLength: 80, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RIGHT", x => x.Right_Id);
                });

            migrationBuilder.CreateTable(
                name: "ROLE",
                columns: table => new
                {
                    Role_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Role_Description = table.Column<string>(nullable: true),
                    Role_Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ROLE", x => x.Role_Id);
                });

            migrationBuilder.CreateTable(
                name: "ROLE_RIGHT",
                columns: table => new
                {
                    Role_Right_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Right_Id = table.Column<int>(nullable: false),
                    Role_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ROLE_RIGHT", x => x.Role_Right_Id);
                    table.ForeignKey(
                        name: "FK_ROLE_RIGHT_RIGHT_Right_Id",
                        column: x => x.Right_Id,
                        principalTable: "RIGHT",
                        principalColumn: "Right_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ROLE_RIGHT_ROLE_Role_Id",
                        column: x => x.Role_Id,
                        principalTable: "ROLE",
                        principalColumn: "Role_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "USER",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Created_On = table.Column<DateTime>(nullable: false),
                    Date_Entered = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(maxLength: 20, nullable: false),
                    First_Name = table.Column<string>(maxLength: 20, nullable: false),
                    Is_Locked = table.Column<bool>(nullable: false),
                    Last_Updated_On = table.Column<DateTime>(nullable: true),
                    Mobile = table.Column<string>(maxLength: 20, nullable: false),
                    Password = table.Column<string>(maxLength: 50, nullable: false),
                    Password_Salt = table.Column<string>(maxLength: 150, nullable: false),
                    Role_Id = table.Column<int>(nullable: false),
                    Surname = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USER", x => x.Id);
                    table.ForeignKey(
                        name: "FK_USER_ROLE_Role_Id",
                        column: x => x.Role_Id,
                        principalTable: "ROLE",
                        principalColumn: "Role_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ROLE_RIGHT_Right_Id",
                table: "ROLE_RIGHT",
                column: "Right_Id");

            migrationBuilder.CreateIndex(
                name: "IX_ROLE_RIGHT_Role_Id",
                table: "ROLE_RIGHT",
                column: "Role_Id");

            migrationBuilder.CreateIndex(
                name: "IX_USER_Role_Id",
                table: "USER",
                column: "Role_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MEDIA_TYPE");

            migrationBuilder.DropTable(
                name: "ROLE_RIGHT");

            migrationBuilder.DropTable(
                name: "USER");

            migrationBuilder.DropTable(
                name: "RIGHT");

            migrationBuilder.DropTable(
                name: "ROLE");
        }
    }
}
