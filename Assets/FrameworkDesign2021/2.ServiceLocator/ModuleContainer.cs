using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using FrameworkDesign2021.ServiceLocator;
using System.Reflection;
namespace FrameworkDesign2021 
{
    public class ModuleContainer 
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

        public IEnumerable<T> GetModules<T>() where T : class
        {
            var moduleType = typeof(T);
            var modules = mCache.GetModulesByType(moduleType) as IEnumerable<object>;
            if (modules == null)
            {
                modules = mFactory.CreateModulesByType(moduleType) as IEnumerable<object>;
                mCache.AddModulesByType(moduleType,modules);
            }
            //这步是从object => T 是逆变。但是IEnumerable<out t> out修饰参数 只支持协变
            //return modules as IEnumerable<T>;
            return modules.Select(m => m as T);//改进部分
        }

        public IEnumerable<object> GetModules(string name)
        {
            var moduleName = name;
            //新增修改
            var modules = mCache.GetModuleByName(moduleName) as IEnumerable<object>;
            if (modules == null || !modules.Any())
            {
                //新增修改
                modules = mFactory.CreateModulesByName(moduleName) as IEnumerable<object>;
                mCache.AddModuleByName(moduleName,modules);
            }
            return modules;
        }



    }
}
