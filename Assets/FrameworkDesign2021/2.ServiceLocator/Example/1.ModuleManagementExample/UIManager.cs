using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace FrameworkDesign2021.ServiceLocator.ModuleManagementExample
{
    public interface IUIManager : IModule
    {
        void DoSomething();
    }
    public class UIManager : IUIManager
    {
        public IResManager ResManager { get; set; }
        public IEventManager EventManager { get; set; }

        public void DoSomething()
        {
            Debug.Log("UIManager DoSomething");
            ResManager.DoSomething();
            EventManager.DoSomething();
        }

        public void InitModule()
        {
            ResManager = ModuleManagementConfig.Container.GetModule<IResManager>();
            EventManager = ModuleManagementConfig.Container.GetModule<IEventManager>();
        }
    }
}
