using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CampusClassicals.Data
{
    public class EFIdentityContext : IdentityDbContext<IdentityUser>
    {
        public EFIdentityContext(DbContextOptions<EFIdentityContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //builder.Entity<IdentityUser>().ToTable("USER");
            //builder.Entity<IdentityUser>(b =>
            //{
            //    b.Property(u => u.AccessFailedCount).HasColumnName("Access_Failed_Count");
            //    b.Property(u => u.ConcurrencyStamp).HasColumnName("Concurrency_Stamp");
            //    b.Property(u => u.EmailConfirmed).HasColumnName("Email_Confirmed");
            //    b.Property(u => u.LockoutEnabled).HasColumnName("Lockout_Enabled");
            //    b.Property(u => u.LockoutEnd).HasColumnName("Lockout_End");
            //    b.Property(u => u.NormalizedEmail).HasColumnName("Normalized_Email");
            //    b.Property(u => u.NormalizedUserName).HasColumnName("Normalized_Username");
            //    b.Property(u => u.PasswordHash).HasColumnName("Password_Hash");
            //    b.Property(u => u.PhoneNumber).HasColumnName("Phone_Number");
            //    b.Property(u => u.PhoneNumberConfirmed).HasColumnName("Phone_Number_Confirmed");
            //    b.Property(u => u.SecurityStamp).HasColumnName("Security_Stamp");
            //    b.Property(u => u.TwoFactorEnabled).HasColumnName("Two_Factor_Enabled");
            //    b.Property(u => u.UserName).HasColumnName("Username");
            //});
            
           

        }


    }
}
