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

        public object CreateModuleByName(string name)
        {
            return null;
        }

        public object CreateModulesByName(string name)
        {
            throw new NotImplementedException();
        }

        public object CreateModulesByType(Type type)
        {
            //为什么这里不用为空判断
            //这里是对list里存储的每一个元素都做了实例化对象操作吗 是的
            //那为什么return的是一个object 因为object是IEnumerable<object>的基类
            return mTypeCache.Select(t=>t.GetConstructors().First().Invoke(null));
        }

        public object CreateMoudleType(Type type)
        {
            if (mTypeCache.Contains(type))
            {
                return type.GetConstructors().First().Invoke(null);
            }
            return null;
        }
    }
}
