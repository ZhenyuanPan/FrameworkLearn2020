using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace FrameworkDesign2021.ServiceLocator.ModuleManagementExample
{
    public interface IEventManager : IModule 
    {
        void DoSomething();
    }
    public class EventManager : IEventManager
    {
        public IPoolManager PoolManager { get; set; }
        public void DoSomething()
        {
            Debug.Log("EventManager DoSomeThing");
        }

        public void InitModule()
        {
            PoolManager = ModuleManagementConfig.Container.GetModule<IPoolManager>();
        }
    }
}
