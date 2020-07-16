using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using FrameworkDesign2021.ServiceLocator;
using System.Reflection;
namespace FrameworkDesign2021 
{
    class ModuleContainer 
    {
        private IModuleCache mCache;
        private IModuleFactory mFactory;

        public ModuleContainer(IModuleCache cache,IModuleFactory factory) 
        {
            mCache = cache;
            mFactory = factory;
        }

        public T GetModule<T>() where T : class 
        {
            var moduleType = typeof(T);
            var module = mCache.GetModuleByType(moduleType);
            if (module == null)
            {
                module = mFactory.CreateMoudleType(moduleType);
                mCache.AddModuleByType(moduleType,module);
            }
            return module as T;
        }

        public object GetModule(string name) 
        {
            var moduleName = name;
            var module = mCache.GetModuleByName(moduleName);
            if (module == null)
            {
                module = mFactory.CreateModuleByName(moduleName);
                mCache.AddModuleByName(moduleName,module);
            }
            return module;
        }

        public IEnumerable<T> GetModules<T>() 
        {
            var moduleType = typeof(T);
            var modules = mCache.GetModulesByType(moduleType);
            if (modules == null || !modules.Any())
            {
                modules = mFactory.CreateModulesByType(moduleType);
                mCache.AddModulesByType(moduleType,modules);
            }
            return modules as IEnumerable<T>;
        }

        public IEnumerable<object> GetModules(string name)
        {
            var moduleName = name;
            var modules = mCache.GetModulesByName(name);
            if (modules == null || !modules.Any())
            {
                modules = mFactory.CreateModulesByName(moduleName);
                mCache.AddModuleByName(moduleName,modules);
            }
            return modules;
        }



    }
}
