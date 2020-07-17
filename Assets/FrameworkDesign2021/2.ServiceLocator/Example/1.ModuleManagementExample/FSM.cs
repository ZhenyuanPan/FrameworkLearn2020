using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FrameworkDesign2021.ServiceLocator.ModuleManagementExample
{
    public interface IFSM : IModule 
    {
        void DoSomething();
    }
    public class FSM : IFSM
    {
        public void DoSomething()
        {
            Debug.Log("FSM DoSomeThing");
        }

        public void InitModule()
        {
          
        }
    }
}


