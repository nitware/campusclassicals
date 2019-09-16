using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using CampusClassicals.Data;

namespace CampusClassicals.Data.Migrations.EFData
{
    [DbContext(typeof(EFDataContext))]
    [Migration("20190825153959_EventAndGalleryEntityCleanup")]
    partial class EventAndGalleryEntityCleanup
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

                    b.Property<int>("MediaId")
                        .HasColumnName("Media_Id");

                    b.Property<int>("MediaTypeId")
                        .HasColumnName("Media_Type_Id");

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

                    b.HasIndex("MediaTypeId");

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

                    b.Property<int>("MediaId")
                        .HasColumnName("Media_Id");

                    b.Property<int>("MediaTypeId")
                        .HasColumnName("Media_Type_Id");

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

                    b.HasIndex("MediaTypeId");

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

                    b.Property<byte[]>("File")
                        .IsRequired();

                    b.Property<int?>("Height");

                    b.Property<string>("MimeType")
                        .IsRequired()
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

            modelBuilder.Entity("CampusClassicals.Domain.MediaType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Media_Type_Id");

                    b.Property<string>("Description")
                        .HasColumnName("Media_Type_Description")
                        .HasMaxLength(250);

                    b.Property<string>("Name")
                        .HasColumnName("Media_Type_Name")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("MEDIA_TYPE");
                });

            modelBuilder.Entity("CampusClassicals.Domain.Event", b =>
                {
                    b.HasOne("CampusClassicals.Domain.Media", "Media")
                        .WithMany()
                        .HasForeignKey("MediaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CampusClassicals.Domain.MediaType", "MediaType")
                        .WithMany()
                        .HasForeignKey("MediaTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("CampusClassicals.Domain.Gallery", b =>
                {
                    b.HasOne("CampusClassicals.Domain.Media", "Media")
                        .WithMany()
                        .HasForeignKey("MediaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("CampusClassicals.Domain.MediaType", "MediaType")
                        .WithMany()
                        .HasForeignKey("MediaTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
