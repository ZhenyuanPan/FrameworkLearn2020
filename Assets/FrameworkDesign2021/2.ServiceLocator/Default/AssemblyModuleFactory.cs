using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkDesign2021.ServiceLocator.Default
{
    public class AssemblyModuleFactory : IModuleFactory
    {
        private List<Type> mTypeCache;

        public AssemblyModuleFactory(Assembly assembly, Type baseModuleType) 
        {
            mTypeCache = assembly
                .GetTypes()
                .Where(t => baseModuleType.IsAssignableFrom(t) && !t.IsAbstract)
                .ToList();
        }

        public object CreateModule(ModuleSearchKeys keys)
        {
            if (mTypeCache.Contains(keys.Type))
            {
                return keys.Type.GetConstructors().First().Invoke(null);
            }
            return null;
        }

        public object CreateModules(ModuleSearchKeys keys)
        {
            return mTypeCache.Select(t => t.GetConstructors().First().Invoke(null));
        }
    }
}
