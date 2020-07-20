using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace FrameworkDesign2021.ServiceLocator.LayerdArchitectureExample
{
    public class LayerdArchitectureExample : MonoBehaviour
    {
        private ILoginController mLoginController;
        private IUserInputManager mUserInputManager;

        private void Start()
        {
            mLoginController = ArchitectureConfig.Architecture.LogicLayer.GetModule<ILoginController>();
            mUserInputManager = ArchitectureConfig.Architecture.LogicLayer.GetModule<IUserInputManager>();
            mLoginController.Login();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                
                mUserInputManager.OnInput(KeyCode.Space);
            }
        }
    }
}
