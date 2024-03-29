﻿
using CampusClassicals.Core.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using CampusClassicals.Domain;
using CampusClassicals.Core.Data;


namespace CampusClassicals.Data.Setup
{
    public class DependencyRegistrar : IDependencyRegistrar
    {
        public int Order => 1;

        public void Register(IServiceCollection services, string connectionString = null)
        {
            services.AddDbContext<EFDataContext>(o => o.UseSqlServer(connectionString));
            services.AddDbContext<EFIdentityContext>(o => o.UseSqlServer(connectionString));


            services.AddIdentity<User, IdentityRole>(o =>
            {
                o.User.RequireUniqueEmail = true;

                o.Password.RequiredLength = 6;
                o.Password.RequireNonAlphanumeric = false;
                o.Password.RequireLowercase = false;
                o.Password.RequireUppercase = false;
                o.Password.RequireDigit = false;

                o.Cookies.ApplicationCookie.LoginPath = "/Account/Login";
            })
            .AddEntityFrameworkStores<EFIdentityContext>()
            .AddDefaultTokenProviders();

            
            services.AddTransient<IRepository<Media>, EFRepository<Media>>();
            services.AddTransient<IRepository<Gallery>, EFRepository<Gallery>>();
            services.AddTransient<IRepository<Event>, EFRepository<Event>>();

        }
    }





}
