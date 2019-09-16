﻿using System;
using System.Collections.Generic;
using CampusClassicals.Core.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using System.Linq;

namespace CampusClassicals.Web.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void RegisterCustomServices(this IServiceCollection services, string connectionString = null)
        {
            // get type finder
            IServiceProvider serviceProvider = services.BuildServiceProvider();
            ITypeFinder typeFinder = serviceProvider.GetService<ITypeFinder>();

            //get registrars
            List<TypeInfo> registrars = typeFinder.FindClassesOfType<IDependencyRegistrar>();

            // create registrar instance list
            List<IDependencyRegistrar> registrarList = new List<IDependencyRegistrar>();
            registrars.ForEach(dr => registrarList.Add(Activator.CreateInstance(dr.AsType()) as IDependencyRegistrar));

            //sort
            registrarList = registrarList.OrderBy(x => x.Order).ToList();

            //register dependencies
            registrarList.ForEach(dr => dr.Register(services, connectionString));
        }



    }
}
