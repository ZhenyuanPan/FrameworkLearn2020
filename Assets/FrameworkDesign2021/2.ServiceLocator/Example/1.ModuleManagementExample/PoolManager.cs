using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
namespace FrameworkDesign2021.ServiceLocator.ModuleManagementExample
{
    public interface IPoolManager : IModule
    {
        void DoSomething();
    }
    public class PoolManager : IPoolManager
    {
        public void DoSomething()
        {
            Debug.Log("PoolManager DoSomething");
        }

        public void InitModule()
        {
            
        }
    }
}
