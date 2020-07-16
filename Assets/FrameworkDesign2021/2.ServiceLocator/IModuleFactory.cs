using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkDesign2021.ServiceLocator
{
    interface IModuleFactory
    {
        object CreateModuleByName(string name);
        object CreateMoudleType(Type type);
        IEnumerable<object> CreateModulesByName(string name);
        IEnumerable<object> CreateModulesByType(Type type);
    }
}
