
using System;
using CampusClassicals.Core.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace CampusClassicals.Data.Setup
{
    public class DependencyRegistrar : IDependencyRegistrar
    {
        public int Order => 1;

        public void Register(IServiceCollection service, string connectionString = null)
        {
            service.AddDbContext<EFDataContext>(o => o.UseSqlServer(connectionString));

            //service.AddDbContext<DataContext>(o => o.UseSqlServer("Server=.;Database=CampusClassicals;Trusted_Connection=True;"));
        }
    }





}
