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
            entityBuilder.Property(x => x.Url).HasMaxLength(500);

            //entityBuilder.Property(x => x.File).IsRequired();
            //entityBuilder.Property(x => x.CreatedOn).HasColumnName("Created_On").IsRequired();
            //entityBuilder.Property(x => x.UpdatedOn).HasColumnName("Updated_On");
            //entityBuilder.Property(x => x.CreatedBy).HasMaxLength(450).HasColumnName("Created_By").IsRequired();
            //entityBuilder.Property(x => x.UpdatedBy).HasMaxLength(450).HasColumnName("Updated_By");
            //

        }


    }
}
