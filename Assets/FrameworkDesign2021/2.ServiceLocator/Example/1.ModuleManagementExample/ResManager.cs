using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace FrameworkDesign2021.ServiceLocator.ModuleManagementExample
{
    public interface IResManager : IModule
    {
        void DoSomething();
    }
    public class ResManager : IResManager
    {
        public IPoolManager PoolManager { get; set; }
       
        public void DoSomething()
        {
            Debug.Log("ResManager DoSomethings");
        }

        public void InitModule()
        {
            PoolManager = ModuleManagementConfig.Container.GetModule<IPoolManager>();
        }
    }
}
