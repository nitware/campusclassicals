
using CampusClassicals.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CampusClassicals.Data.Mappings
{
    public class GalleryMap
    {
        public GalleryMap(EntityTypeBuilder<Gallery> entityBuilder)
        {
            entityBuilder.ToTable("GALLERY");

            entityBuilder.HasKey(x => x.Id);

            entityBuilder.Property(x => x.Id).HasColumnName("Gallery_Id");
            entityBuilder.Property(x => x.Title).HasMaxLength(100);
            entityBuilder.Property(x => x.Short).HasMaxLength(150);
            entityBuilder.Property(x => x.Full).HasMaxLength(750);
            entityBuilder.Property(x => x.CreatedOn).HasColumnName("Created_On").IsRequired();
            entityBuilder.Property(x => x.UpdatedOn).HasColumnName("Updated_On");
            entityBuilder.Property(x => x.CreatedBy).HasMaxLength(450).HasColumnName("Created_By").IsRequired();
            entityBuilder.Property(x => x.UpdatedBy).HasMaxLength(450).HasColumnName("Updated_By");
            entityBuilder.Property(x => x.DisplayOrder).HasColumnName("Display_Order");
            entityBuilder.Property(x => x.MimeType).HasColumnName("Mime_Type").HasMaxLength(80).IsRequired();
            entityBuilder.Property(x => x.MediaId).HasColumnName("Media_Id");

            //entityBuilder.Property(x => x.MediaTypeId).HasColumnName("Media_Type_Id");




        }

    }
}
