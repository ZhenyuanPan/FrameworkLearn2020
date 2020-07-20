using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace FrameworkDesign2021.ServiceLocator.LayerdArchitectureExample 
{ 
    public interface ILoginController : ILogicController
    {
        void Login();
    }

    public class LoginController : ILogicController
    {
        public void Login() 
        {
            Debug.Log("登录成功");   
        }
    }
}
