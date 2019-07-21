using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using CampusClassicals.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CampusClassicals.Data.Mappings
{
    public class MediaTypeMap
    {
        //public MediaTypeMap()
        //{

        //}
        public MediaTypeMap(EntityTypeBuilder<MediaType> entityBuilder)
        {
            entityBuilder.ToTable("MEDIA_TYPE");

            entityBuilder.HasKey(x => x.Id);
            
            entityBuilder.Property(x => x.Id).HasColumnName("Media_Type_Id");
            entityBuilder.Property(x => x.Name).HasColumnName("Media_Type_Name");
            entityBuilder.Property(x => x.Description).HasColumnName("Media_Type_Description");
        }

        //public void Configure(EntityTypeBuilder<MediaType> entityBuilder)
        //{
        //    entityBuilder.ToTable("MEDIA_TYPE");

        //    entityBuilder.HasKey(x => x.Id);

        //    entityBuilder.Property(x => x.Id).HasColumnName("Media_Type_Id");
        //    entityBuilder.Property(x => x.Name).HasColumnName("Media_Type_Name");
        //    entityBuilder.Property(x => x.Description).HasColumnName("Media_Type_Description");
        //}
    }



}
