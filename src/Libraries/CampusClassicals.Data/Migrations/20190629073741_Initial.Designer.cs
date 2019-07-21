using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using CampusClassicals.Data;

namespace CampusClassicals.Data.Migrations
{
    [DbContext(typeof(EFDataContext))]
    [Migration("20190629073741_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CampusClassicals.Domain.Right", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Right_Id");

                    b.Property<string>("Description")
                        .HasColumnName("Right_Description")
                        .HasMaxLength(250);

                    b.Property<string>("Name")
                        .HasColumnName("Right_Name")
                        .HasMaxLength(80);

                    b.HasKey("Id");

                    b.ToTable("RIGHT");
                });

            modelBuilder.Entity("CampusClassicals.Domain.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Role_Id");

                    b.Property<string>("Description")
                        .HasColumnName("Role_Description");

                    b.Property<string>("Name")
                        .HasColumnName("Role_Name");

                    b.HasKey("Id");

                    b.ToTable("ROLE");
                });

            modelBuilder.Entity("CampusClassicals.Domain.RoleRight", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Role_Right_Id");

                    b.Property<int>("RightId")
                        .HasColumnName("Right_Id");

                    b.Property<int>("RoleId")
                        .HasColumnName("Role_Id");

                    b.HasKey("Id");

                    b.HasIndex("RightId");

                    b.HasIndex("RoleId");

                    b.ToTable("ROLE_RIGHT");
                });

            modelBuilder.Entity("CampusClassicals.Domain.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnName("Created_On");

                    b.Property<DateTime>("DateEntered")
                        .HasColumnName("Date_Entered");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnName("Email")
                        .HasMaxLength(20);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnName("First_Name")
                        .HasMaxLength(20);

                    b.Property<bool>("IsLocked")
                        .HasColumnName("Is_Locked");

                    b.Property<DateTime?>("LastUpdatedOn")
                        .HasColumnName("Last_Updated_On");

                    b.Property<string>("Mobile")
                        .IsRequired()
                        .HasColumnName("Mobile")
                        .HasMaxLength(20);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnName("Password")
                        .HasMaxLength(50);

                    b.Property<string>("PasswordSalt")
                        .IsRequired()
                        .HasColumnName("Password_Salt")
                        .HasMaxLength(150);

                    b.Property<int>("RoleId")
                        .HasColumnName("Role_Id");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnName("Surname")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("USER");
                });

            modelBuilder.Entity("CampusClassicals.Domain.RoleRight", b =>
                {
                    b.HasOne("CampusClassicals.Domain.Right", "Right")
                        .WithMany("RoleRights")
                        .HasForeignKey("RightId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CampusClassicals.Domain.Role", "Role")
                        .WithMany("RoleRights")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CampusClassicals.Domain.User", b =>
                {
                    b.HasOne("CampusClassicals.Domain.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
