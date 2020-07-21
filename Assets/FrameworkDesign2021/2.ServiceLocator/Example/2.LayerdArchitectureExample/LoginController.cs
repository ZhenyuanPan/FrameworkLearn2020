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

    public class LoginController : ILoginController
    {
        public void Login() 
        {
            var accountSystem = ArchitectureConfig.Architecture.BusinessModuleLayer.GetModule<IAccountSystem>();
            accountSystem.Login("hello", "abc", (succeed) =>
            {
                if (succeed)
                {
                    Debug.Log("登录成功");
                }
            });
        }
    }
}
