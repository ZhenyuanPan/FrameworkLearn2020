using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace FrameworkDesign2021.ServiceLocator.LayerdArchitectureExample
{
    public class ArchitectureConfig : IArchitecture
    {
        public ILogicLayer LogicLayer { get; private set; }

        public IBusinessModuleLayer BusinessModuleLayer { get; private set; }

        public IPublichModuleLayer PublichModuleLayer { get; private set; }

        public IUtiltyLayer UtiltyLayer { get; private set; }

        public IBasicModuleLayer BasicModuleLayer { get; private set; }

        public static ArchitectureConfig Architecture = null;

        /// <summary>
        /// 项目启动时自动执行
        /// </summary>
        [RuntimeInitializeOnLoadMethod]
        static void Config() 
        {
            Architecture = new ArchitectureConfig();
            //逻辑层配置
            Architecture.LogicLayer = new LogicLayer();

            //主动创建对象
            var logicController = Architecture.LogicLayer.GetModule<ILoginController>();
            var userInputManager = Architecture.LogicLayer.GetModule<IUserInputManager>();

            Debug.Log(logicController);
            Debug.Log(userInputManager);
        }

    }
}
