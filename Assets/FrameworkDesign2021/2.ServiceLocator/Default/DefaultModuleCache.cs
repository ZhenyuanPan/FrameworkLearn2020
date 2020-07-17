using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkDesign2021.ServiceLocator.Default
{
    public class DefaultModuleCache : IModuleCache
    {
        private Dictionary<Type, List<object>> mModulesByType = new Dictionary<Type, List<object>>();
        private Dictionary<string, List<object>> mModulesByName = new Dictionary<string, List<object>>();

        public object GetModuleByName(string name) 
        {
            List<object> output = null;
            if (mModulesByName.TryGetValue(name,out output))
            {
                return output.FirstOrDefault();
            }
            return null;
        }
        public object GetModuleByType(Type type)
        {
            List<object> output = null;
            if (mModulesByType.TryGetValue(type,out output))
            {
                return output.FirstOrDefault();
            }
            return null;
        }
        public object GetModulesByName(string name)
        {
            List<object> output = null;

            if (mModulesByName.TryGetValue(name, out output))
            {
            }

            return output;
        }

        public object GetModulesByType(Type type)
        {
            List<object> output = null;

            if (mModulesByType.TryGetValue(type, out output))
            {
            }

            return output;
        }

        public void AddModuleByName(string name, object module)
        {
            if (mModulesByName.ContainsKey(name))
            {
                mModulesByName[name].Add(module);
            }
            else 
            {
                //数据式的构造方法
                mModulesByName.Add(name, new List<object>() { module });
            }
        }

        public void AddModuleByType(Type type, object module)
        {
            if (mModulesByType.ContainsKey(type))
            {
                mModulesByType[type].Add(module);
            }
            else
            {
                mModulesByType.Add(type,new List<object>() { module});
            }
        }

        public void AddModulesByName(string name, object modules)
        {
            var moduleCollection = (IEnumerable<object>)modules;
            if (mModulesByName.ContainsKey(name))
            {
                //所有元素添加到队列最后
                mModulesByName[name].AddRange(moduleCollection);
            }
            else 
            {
                mModulesByName.Add(name,moduleCollection.ToList());
            }
        }

        public void AddModulesByType(Type type, object modules)
        {
            var moduleCollection = (IEnumerable<object>)modules;
            if (mModulesByType.ContainsKey(type))
            {
                mModulesByType[type].AddRange(moduleCollection);
            }
            else
            {
                mModulesByType.Add(type,moduleCollection.ToList());
            }
        }
    }
}
