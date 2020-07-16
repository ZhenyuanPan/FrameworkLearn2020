using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrameworkDesign2021.ServiceLocator;
namespace FrameworkDesign2021
{
    public class EditorPlatformModuleCache : IModuleCache
    {
        private IEnumerable<object> mModules;
        public void AddModuleByName(string name, object module)
        {
            throw new NotImplementedException();
        }

        public void AddModuleByType(Type type, object module)
        {
            throw new NotImplementedException();
        }

        public void AddModulesByName(string name, IEnumerable<object> modules)
        {
            mModules = modules;
        }

        public void AddModulesByType(Type type, IEnumerable<object> modules)
        {
            mModules = modules;
        }

        public object GetModuleByName(string name)
        {
            throw new NotImplementedException();
        }

        public object GetModuleByType(Type type)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<object> GetModulesByName(string name)
        {
            return mModules;
        }

        public IEnumerable<object> GetModulesByType(Type type)
        {
            return mModules;
        }
    }
}
