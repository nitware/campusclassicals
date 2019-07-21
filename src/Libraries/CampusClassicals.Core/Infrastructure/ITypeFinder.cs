using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace CampusClassicals.Core.Infrastructure
{
    public interface ITypeFinder
    {
        List<Assembly> GetAssemblies();
        List<TypeInfo> FindClassesOfType<T>();
        List<TypeInfo> FindClassesOfType<T>(List<Assembly> assemblies);
    }
}
