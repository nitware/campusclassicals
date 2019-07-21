using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using CampusClassicals.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CampusClassicals.Data.Mappings
{
    public class RoleMap
    {
        public RoleMap(EntityTypeBuilder<Role> entityBuilder)
        {
            entityBuilder.ToTable("ROLE");

            entityBuilder.HasKey(x => x.Id);

            entityBuilder.Property(x => x.Id).HasColumnName("Role_Id");
            entityBuilder.Property(x => x.Name).HasColumnName("Role_Name");
            entityBuilder.Property(x => x.Description).HasColumnName("Role_Description");

            entityBuilder.HasMany(t => t.RoleRights)
                .WithOne(a => a.Role);
                
        }
    }



}
