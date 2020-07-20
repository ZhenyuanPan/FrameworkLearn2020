using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
namespace FrameworkDesign2021.ServiceLocator.LayerdArchitectureExample
{
    public interface IUserInputManager : ILogicController 
    {
        void OnInput(KeyCode keyCode);
    }
    public class UserInputManager : IUserInputManager
    {
        public void OnInput(KeyCode keyCode)
        {
            Debug.Log("输入了:"+ keyCode);
        }
    }
}
