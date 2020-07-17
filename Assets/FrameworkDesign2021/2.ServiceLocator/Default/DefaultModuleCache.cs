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

        public void AddModules(ModuleSearchKeys keys, object modules)
        {
            var moduleCollection = (IEnumerable<object>)modules;
            if (mModulesByType.ContainsKey(keys.Type))
            {
                mModulesByType[keys.Type].AddRange(moduleCollection);
            }
            else
            {
                mModulesByType.Add(keys.Type,moduleCollection.ToList());
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

     
        public object GetModules(ModuleSearchKeys keys)
        {
            List<object> output = null;

            if (mModulesByType.TryGetValue(keys.Type, out output))
            {

            }

            return output;
        }

    }
}
