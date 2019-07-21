using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

//using Microsoft.Extensions.DependencyModel; //version 2.0.4

namespace CampusClassicals.Core.Infrastructure
{
    public class AppTypeFinder : ITypeFinder
    {
        public List<Assembly> GetAssemblies()
        {
            List<Assembly> assemblies = new List<Assembly>()
            {
                Assembly.Load(new AssemblyName("CampusClassicals.Data")),
                Assembly.Load(new AssemblyName("CampusClassicals.Domain")),
                Assembly.Load(new AssemblyName("CampusClassicals.Core"))
            };

            return assemblies;
        }

        //public List<Assembly> GetAssemblies()
        //{
        //    var assemblies = new List<Assembly>();
        //    var dependencies = DependencyContext.Default.RuntimeLibraries;
        //    foreach (var library in dependencies)
        //    {
        //        if (IsCandidateCompilationLibrary(library))
        //        {
        //            var assembly = Assembly.Load(new AssemblyName(library.Name));
        //            assemblies.Add(assembly);
        //        }
        //    }

        //    return assemblies;
        //}

        public List<TypeInfo> FindClassesOfType<T>()
        {
            List<Assembly> assemblies = GetAssemblies();
            return FindClassesOfTypeHelper<T>(assemblies);
        }

        public List<TypeInfo> FindClassesOfType<T>(List<Assembly> assemblies)
        {
            return FindClassesOfTypeHelper<T>(assemblies);
        }

        private List<TypeInfo> FindClassesOfTypeHelper<T>(List<Assembly> assemblies)
        {
            return assemblies
              .SelectMany(x => x.DefinedTypes)
              .Where(dr => dr.ImplementedInterfaces.Contains(typeof(T)))
              .Select(dr => dr).ToList();
        }

        //private static bool IsCandidateCompilationLibrary(RuntimeLibrary compilationLibrary)
        //{
        //    return compilationLibrary.Name.StartsWith(nameof(CampusClassicals)) || compilationLibrary.Dependencies.Any(d => d.Name.StartsWith(nameof(CampusClassicals)));
        //}

    }





}
