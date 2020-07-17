using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkDesign2021.ServiceLocator
{
    public interface IModuleFactory
    {
        object CreateModule(ModuleSearchKeys keys);
        object CreateModules(ModuleSearchKeys keys);
    }
}
