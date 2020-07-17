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

        public void AddModule(ModuleSearchKeys keys, object module)
        {
            if (mModulesByType.ContainsKey(keys.Type))
            {
                mModulesByType[keys.Type].Add(module);
            }
            else
            {
                mModulesByType.Add(keys.Type,new List<object>() { module});
            }
        }

        public object GetModule(ModuleSearchKeys keys)
        {
            List<object> output = null;
            if (mModulesByType.TryGetValue(keys.Type,out output))
            {
                return output.FirstOrDefault();
            }
            return null;
        }

        //改动
        public object GetAllModules()
        {
            //就是把list<object>拆分成object了
            return mModulesByType.Values.SelectMany(list => list);
        }

    }
}
