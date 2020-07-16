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
        //新增
        private IEnumerable<IEditorPlatformModule> mModules;

        public void AddModuleByName(string name, object module)
        {
            throw new NotImplementedException();
        }

        public void AddModuleByType(Type type, object module)
        {
            throw new NotImplementedException();
        }

        public void AddModulesByName(string name, object modules)
        {
            throw new NotImplementedException();
        }

        
        public object GetModuleByName(string name)
        {
            throw new NotImplementedException();
        }

        public object GetModuleByType(Type type)
        {
            throw new NotImplementedException();
        }

        public object GetModulesByName(string name)
        {
            throw new NotImplementedException();
        }

        public object GetModulesByType(Type type)
        {
            return mModules;
        }
        //新增
        public void AddModulesByType(Type type, object modules)
        {
            mModules = modules as IEnumerable<IEditorPlatformModule>;
        }

    }
}
