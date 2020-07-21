using FrameworkDesign2021.ServiceLocator.Default;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkDesign2021.ServiceLocator.LayerdArchitectureExample
{
    public interface ISystem { }
    public class BusinessModuleLayer : AbstractModuleLayer,IBusinessModuleLayer
    {
        private AssemblyModuleFactory _mFactory;

        protected override AssemblyModuleFactory mFactory { get { return new AssemblyModuleFactory(typeof(ISystem).Assembly, typeof(ISystem)); } }
    }
}
