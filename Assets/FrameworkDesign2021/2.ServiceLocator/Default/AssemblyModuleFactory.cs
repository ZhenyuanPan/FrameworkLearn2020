﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkDesign2021.ServiceLocator.Default
{
    public class AssemblyModuleFactory : IModuleFactory
    {
        //具体类型
        private List<Type> mConcreteTypeCache;

        //抽象类型 与 具体类型 对应的字典
        private Dictionary<Type, Type> mAbstractToConcrete = new Dictionary<Type, Type>();

        public AssemblyModuleFactory(Assembly assembly, Type baseModuleType) 
        {
            //具体类型
            mConcreteTypeCache = assembly
                .GetTypes()
                .Where(t => baseModuleType.IsAssignableFrom(t) && !t.IsAbstract)
                .ToList();

            //具体类型的父接口类型
            foreach (var type in mConcreteTypeCache)
            {
                var interfaces = type.GetInterfaces();
                foreach (var @interface in interfaces)
                {
                    //不是 Module 接口的父类型
                    if (baseModuleType.IsAssignableFrom(@interface) && @interface != baseModuleType)
                    {
                        //抽象类型(键) 具体类型(值)
                        mAbstractToConcrete.Add(@interface,type);
                    }
                }
            }
        }

        public object CreateModule(ModuleSearchKeys keys)
        {
            if (keys.Type.IsAbstract)
            {
                if (mAbstractToConcrete.ContainsKey(keys.Type))
                {
                    return mAbstractToConcrete[keys.Type].GetConstructors().First().Invoke(null);
                }
            }
            else 
            {
                if (mConcreteTypeCache.Contains(keys.Type))
                {
                    return keys.Type.GetConstructors().First().Invoke(null);
                }
            }
            return null;
        }

        public object CreateModules(ModuleSearchKeys keys)
        {
            return mConcreteTypeCache.Select(t => t.GetConstructors().First().Invoke(null));
        }
    }
}
