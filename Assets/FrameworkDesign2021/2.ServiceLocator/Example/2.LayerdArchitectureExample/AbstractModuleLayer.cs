using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using FrameworkDesign2021.ServiceLocator.Default;
namespace FrameworkDesign2021.ServiceLocator.LayerdArchitectureExample
{
    public abstract class AbstractModuleLayer : IModuleLayer
    {
        private ModuleContainer mContainer = null;

        //在子类中提供
        protected abstract AssemblyModuleFactory mFactory { get; }

        public AbstractModuleLayer() 
        {
            Debug.Log("子类调用了父类的构造函数");
            mContainer = new ModuleContainer(new DefaultModuleCache(),mFactory);
        }

        public T GetModule<T>() where T : class
        {
            return mContainer.GetModule<T>();
        }
    }
}
