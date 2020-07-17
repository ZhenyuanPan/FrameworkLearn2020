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
            //申请对象
            var moduleSearchKeys =  ModuleSearchKeys.Allocate<T>();
            var module = mCache.GetModule(moduleSearchKeys);
            if (module == null)
            {
                module = mFactory.CreateModule(moduleSearchKeys);
                mCache.AddModule(moduleSearchKeys, module);
            }
            //回收对象
            moduleSearchKeys.Release2Pool();
            return module as T;
        }

        #region 没用到name 不实现了
        //public object GetModule(string name)
        //{
        //    var moduleName = name;
        //    var module = mCache.GetModuleByName(moduleName);
        //    if (module == null)
        //    {
        //        module = mFactory.CreateModuleByName(moduleName);
        //        mCache.AddModuleByName(moduleName, module);
        //    }
        //    return module;
        //}
        #endregion
        public IEnumerable<T> GetAllModules<T>() where T : class
        {
            //申请对象
            var moduleSearchKeys = ModuleSearchKeys.Allocate<T>();
            var modules = mCache.GetAllModules() as IEnumerable<object>;
            if (modules == null || !modules.Any())
            {
                modules = mFactory.CreateAllModules() as IEnumerable<object>;
                foreach (var module in modules)
                {
                    mCache.AddModule(moduleSearchKeys,module);
                }
            }
            //回收对象
            moduleSearchKeys.Release2Pool();

            //这步是从object => T 是逆变。但是IEnumerable<out t> out修饰参数 只支持协变
            //return modules as IEnumerable<T>;
            return modules.Select(m => m as T);//改进部分
        }

        #region 同上
        //public IEnumerable<object> GetModules(string name)
        //{
        //    var moduleName = name;
        //    //新增修改
        //    var modules = mCache.GetModuleByName(moduleName) as IEnumerable<object>;
        //    if (modules == null || !modules.Any())
        //    {
        //        //新增修改
        //        modules = mFactory.CreateModulesByName(moduleName) as IEnumerable<object>;
        //        mCache.AddModuleByName(moduleName, modules);
        //    }
        //    return modules;
        //}
        #endregion


    }
}
