using FrameworkDesign2021.ServiceLocator.Default;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkDesign2021.ServiceLocator.LayerdArchitectureExample
{
    public interface ILogicController { }
    public class LogicLayer : AbstractModuleLayer, ILogicLayer
    {
        protected override AssemblyModuleFactory mFactory
        {
            get { return new AssemblyModuleFactory(typeof(ILogicController).Assembly, typeof(ILogicController)); }
        }
    }
}
