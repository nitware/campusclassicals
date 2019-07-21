using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using CampusClassicals.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CampusClassicals.Data.Mappings
{
    public class UserMap
    {
        public UserMap(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("USER");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.FirstName).HasColumnName("First_Name").HasMaxLength(20).IsRequired();
            builder.Property(x => x.Surname).HasColumnName("Surname").HasMaxLength(20).IsRequired();
            builder.Property(x => x.Email).HasColumnName("Email").HasMaxLength(20).IsRequired();
            builder.Property(x => x.CreatedOn).HasColumnName("Created_On");
            builder.Property(x => x.DateEntered).HasColumnName("Date_Entered");
            builder.Property(x => x.IsLocked).HasColumnName("Is_Locked");
            builder.Property(x => x.LastUpdatedOn).HasColumnName("Last_Updated_On");
            builder.Property(x => x.Mobile).HasColumnName("Mobile").HasMaxLength(20).IsRequired();
            builder.Property(x => x.Password).HasColumnName("Password").HasMaxLength(50).IsRequired();
            builder.Property(x => x.PasswordSalt).HasColumnName("Password_Salt").HasMaxLength(150).IsRequired();
            builder.Property(x => x.RoleId).HasColumnName("Role_Id");

            builder.HasOne(x => x.Role).WithMany();
        }



    }


}
