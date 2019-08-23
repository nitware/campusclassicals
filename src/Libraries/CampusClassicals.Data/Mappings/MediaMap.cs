using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using CampusClassicals.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CampusClassicals.Data.Mappings
{
    public class MediaMap
    {
        public MediaMap(EntityTypeBuilder<Media> entityBuilder)
        {
            entityBuilder.ToTable("MEDIA");

            entityBuilder.HasKey(x => x.Id);

            entityBuilder.Property(x => x.Id).HasColumnName("Media_Id");
            entityBuilder.Property(x => x.Name).HasColumnName("Media_Name").HasMaxLength(50);
            entityBuilder.Property(x => x.Description).HasColumnName("Media_Description").HasMaxLength(350);

            entityBuilder.Property(x => x.Url).HasColumnName("Url").HasMaxLength(300);
            entityBuilder.Property(x => x.CreatedOn).HasColumnName("Created_On");
            entityBuilder.Property(x => x.UpdatedOn).HasColumnName("Updated_On");
            entityBuilder.Property(x => x.MimeType).HasColumnName("Mime_Type").HasMaxLength(80);

            //     public string Url { get; set; }
            //public DateTime CreatedOn { get; set; }
            //public DateTime? UpdatedOn { get; set; }
            //public byte[] File { get; set; }
            //public string MimeType { get; set; }
        }


    }
}
