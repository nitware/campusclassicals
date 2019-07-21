using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using CampusClassicals.Domain;
using CampusClassicals.Data.Mappings;
using System.Reflection;

namespace CampusClassicals.Data
{
    public class EFDataContext : DbContext
    {
        public EFDataContext(DbContextOptions<EFDataContext> options) 
            : base(options)
        {
        }

        //public DbSet<Event> Events { get; set; }
        //public DbSet<Gallery> Galleries { get; set; }
        //public DbSet<Media> Medias { get; set; }
        //public DbSet<Media> MediaFiles { get; set; }
        //public DbSet<MediaType> MediaTypes { get; set; }
        //public DbSet<Right> Rights { get; set; }
        //public DbSet<Role> Roles { get; set; }
        //public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(x => new UserMap(x));
            modelBuilder.Entity<Role>(x => new RoleMap(x));
            modelBuilder.Entity<Right>(x => new RightMap(x));
            modelBuilder.Entity<RoleRight>(x => new RoleRightMap(x));
            modelBuilder.Entity<MediaType>(x => new MediaTypeMap(x));

            //modelBuilder.Entity<MediaType>(new MediaTypeMap().Configure);


            //var typesToRegister = from t in Assembly.GetEntryAssembly().GetTypes()
            //                      where t.FullName.Contains("Map")
            //                      select t;

            //foreach (var type in typesToRegister)
            //{
            //    dynamic entityTypeInstance = Activator.CreateInstance(type);
            //    modelBuilder.Configurations.Add(entityTypeInstance);
            //}





            base.OnModelCreating(modelBuilder);
        }

        

    }





}
