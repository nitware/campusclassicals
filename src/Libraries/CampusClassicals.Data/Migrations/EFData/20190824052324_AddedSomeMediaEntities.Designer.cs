using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using CampusClassicals.Data;

namespace CampusClassicals.Data.Migrations.EFData
{
    [DbContext(typeof(EFDataContext))]
    [Migration("20190824052324_AddedSomeMediaEntities")]
    partial class AddedSomeMediaEntities
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CampusClassicals.Domain.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Event_Id");

                    b.Property<string>("Body")
                        .HasMaxLength(3000);

                    b.Property<int>("DisplayOrder")
                        .HasColumnName("Display_Order");

                    b.Property<int>("MediaId");

                    b.Property<string>("PostedBy");

                    b.Property<DateTime>("PostedOn")
                        .HasColumnName("PostedOn")
                        .HasMaxLength(120);

                    b.Property<string>("Title")
                        .HasMaxLength(100);

                    b.Property<string>("UpdatedBy");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnName("Updated_On")
                        .HasMaxLength(120);

                    b.HasKey("Id");

                    b.HasIndex("MediaId");

                    b.ToTable("EVENT");
                });

            modelBuilder.Entity("CampusClassicals.Domain.Gallery", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Gallery_Id");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnName("Created_On")
                        .HasMaxLength(120);

                    b.Property<int>("DisplayOrder")
                        .HasColumnName("Display_Order");

                    b.Property<string>("Full")
                        .HasMaxLength(750);

                    b.Property<int>("MediaId");

                    b.Property<bool>("Published");

                    b.Property<string>("Short")
                        .HasMaxLength(150);

                    b.Property<string>("Title")
                        .HasMaxLength(100);

                    b.Property<string>("UpdatedBy");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnName("Updated_On")
                        .HasMaxLength(120);

                    b.HasKey("Id");

                    b.HasIndex("MediaId");

                    b.ToTable("GALLERY");
                });

            modelBuilder.Entity("CampusClassicals.Domain.Media", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Media_Id");

                    b.Property<string>("CreatedBy");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnName("Created_On")
                        .HasMaxLength(120);

                    b.Property<byte[]>("File");

                    b.Property<int?>("Height");

                    b.Property<string>("MimeType")
                        .HasColumnName("Mime_Type")
                        .HasMaxLength(80);

                    b.Property<string>("UpdatedBy");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnName("Updated_On")
                        .HasMaxLength(120);

                    b.Property<int?>("Width");

                    b.HasKey("Id");

                    b.ToTable("MEDIA");
                });

            modelBuilder.Entity("CampusClassicals.Domain.Event", b =>
                {
                    b.HasOne("CampusClassicals.Domain.Media", "Media")
                        .WithMany()
                        .HasForeignKey("MediaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CampusClassicals.Domain.Gallery", b =>
                {
                    b.HasOne("CampusClassicals.Domain.Media", "Media")
                        .WithMany()
                        .HasForeignKey("MediaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
