using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkDesign2021.ServiceLocator
{
    public interface IModuleFactory
    {
        object CreateModuleByName(string name);
        object CreateMoudleType(Type type);
        //新增修改
        object CreateModulesByName(string name);
        //新增修改
        object CreateModulesByType(Type type);
    }
}
