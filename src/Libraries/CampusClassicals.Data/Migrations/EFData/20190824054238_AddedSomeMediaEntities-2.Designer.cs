using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using CampusClassicals.Data;

namespace CampusClassicals.Data.Migrations.EFData
{
    [DbContext(typeof(EFDataContext))]
    [Migration("20190824054238_AddedSomeMediaEntities-2")]
    partial class AddedSomeMediaEntities2
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

                    b.Property<string>("PostedBy")
                        .IsRequired()
                        .HasColumnName("Posted_By")
                        .HasMaxLength(450);

                    b.Property<DateTime>("PostedOn")
                        .HasColumnName("Posted_On");

                    b.Property<bool>("Published");

                    b.Property<string>("Title")
                        .HasMaxLength(100);

                    b.Property<string>("UpdatedBy")
                        .HasColumnName("Updated_By")
                        .HasMaxLength(450);

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnName("Updated_On");

                    b.HasKey("Id");

                    b.HasIndex("MediaId");

                    b.ToTable("EVENT");
                });

            modelBuilder.Entity("CampusClassicals.Domain.Gallery", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Gallery_Id");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnName("Created_By")
                        .HasMaxLength(450);

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnName("Created_On");

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

                    b.Property<string>("UpdatedBy")
                        .HasColumnName("Updated_By")
                        .HasMaxLength(450);

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnName("Updated_On");

                    b.HasKey("Id");

                    b.HasIndex("MediaId");

                    b.ToTable("GALLERY");
                });

            modelBuilder.Entity("CampusClassicals.Domain.Media", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Media_Id");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnName("Created_By")
                        .HasMaxLength(450);

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnName("Created_On");

                    b.Property<byte[]>("File");

                    b.Property<int?>("Height");

                    b.Property<string>("MimeType")
                        .HasColumnName("Mime_Type")
                        .HasMaxLength(80);

                    b.Property<string>("UpdatedBy")
                        .HasColumnName("Updated_By")
                        .HasMaxLength(450);

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnName("Updated_On");

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
