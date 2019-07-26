
using Microsoft.EntityFrameworkCore;
using CampusClassicals.Domain;
using CampusClassicals.Data.Mappings;

namespace CampusClassicals.Data
{
    public class EFDataContext : DbContext
    {
        public EFDataContext(DbContextOptions<EFDataContext> options) 
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MediaType>(x => new MediaTypeMap(x));


            //modelBuilder.Entity<User>(x => new UserMap(x));
            //modelBuilder.Entity<Role>(x => new RoleMap(x));
            //modelBuilder.Entity<Right>(x => new RightMap(x));
            //modelBuilder.Entity<RoleRight>(x => new RoleRightMap(x));


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
