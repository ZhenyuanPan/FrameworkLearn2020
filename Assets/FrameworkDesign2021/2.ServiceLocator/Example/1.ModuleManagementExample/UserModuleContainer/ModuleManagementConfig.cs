using FrameworkDesign2021.ServiceLocator.Default;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace FrameworkDesign2021.ServiceLocator.ModuleManagementExample
{
    public class ModuleManagementConfig : MonoBehaviour
    {
        public static ModuleContainer Container = null;
        private void Awake()
        {
            var baseType = typeof(IModule);
            var cache = new DefaultModuleCache();
            var factory = new AssemblyModuleFactory(baseType.Assembly,baseType);

            Container = new ModuleContainer(cache,factory);

            //主动去创建对象
            var poolManager = Container.GetModule<IPoolManager>();
            var fsm = Container.GetModule<IFSM>();
            var resManager = Container.GetModule<IResManager>();
            var eventManager = Container.GetModule<IEventManager>();
            var uiManager = Container.GetModule<IUIManager>();

            //设置依赖关系
            //这步骤有两种处理方式: 依赖注入 与 实现类的内部去设置依赖对象
            //(uiManager as UIManager).EventManager = eventManager;
            //(uiManager as UIManager).ResManager = resManager;
            //(eventManager as EventManager).PoolManager = poolManager;
            //(resManager as ResManager).PoolManager = poolManager;

            //初始化模块
            var modules = Container.GetAllModules<IModule>();
            //改动
            foreach (var module in modules)
            {
                module.InitModule();
            }

        }

        private void Start()
        {
            var uiManager = ModuleManagementConfig.Container.GetModule<IUIManager>();
            uiManager.DoSomething();
        }

    }
}
