using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using CampusClassicals.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CampusClassicals.Data.Mappings
{
    public class RightMap
    {
        public RightMap(EntityTypeBuilder<Right> entityConfig)
        {
            entityConfig.ToTable("RIGHT");

            entityConfig.HasKey(x => x.Id);

            entityConfig.Property(x => x.Id).HasColumnName("Right_Id");
            entityConfig.Property(x => x.Name).HasColumnName("Right_Name").HasMaxLength(80);
            entityConfig.Property(x => x.Description).HasColumnName("Right_Description").HasMaxLength(250);

            entityConfig.HasMany(t => t.RoleRights)
               .WithOne(a => a.Right);
        }
    }



}
