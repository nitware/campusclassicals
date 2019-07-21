using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using CampusClassicals.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CampusClassicals.Data.Mappings
{
    public class RoleRightMap
    {
        public RoleRightMap(EntityTypeBuilder<RoleRight> entityConfig)
        {
            entityConfig.ToTable("ROLE_RIGHT");

            entityConfig.HasKey(x => x.Id);

            entityConfig.Property(x => x.Id).HasColumnName("Role_Right_Id");
            entityConfig.Property(x => x.RoleId).HasColumnName("Role_Id");
            entityConfig.Property(x => x.RightId).HasColumnName("Right_Id");

        }
    }




}
