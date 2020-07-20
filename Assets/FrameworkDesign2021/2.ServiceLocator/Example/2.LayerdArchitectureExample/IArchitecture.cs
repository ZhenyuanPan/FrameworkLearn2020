using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkDesign2021.ServiceLocator.LayerdArchitectureExample
{
    public interface IArchitecture
    {
        ILogicLayer LogicLayer { get; }
        IBusinessModuleLayer BusinessModuleLayer { get; }
        IPublichModuleLayer PublichModuleLayer { get; }
        IUtiltyLayer UtiltyLayer { get; }
        IBasicModuleLayer BasicModuleLayer { get; }
    }
}
