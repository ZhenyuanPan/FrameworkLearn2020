using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace FrameworkDesign2021.ServiceLocator.LayerdArchitectureExample
{
    public interface IAccountSystem : ISystem 
    {
        bool IsLogin { get; }
        void Login(string username, string password, Action<bool> onLogin);
        void Logout(Action onLogOut);
    }
    public class AccountSystem : IAccountSystem
    {
        public bool IsLogin { get; private set; }

        public void Login(string username, string password, Action<bool> onLogin)
        {
            PlayerPrefs.SetString("username",username);
            PlayerPrefs.SetString("password",password);
            IsLogin = true;
            onLogin(true);
        }

        public void Logout(Action onLogOut)
        {
            PlayerPrefs.SetString("username",string.Empty);
            PlayerPrefs.SetString("password",string.Empty);
            IsLogin = false;
        }
    }
}
