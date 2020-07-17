using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.Reflection;

namespace FrameworkDesign2021.ServiceLocator.Pattern.Example 
{
    public class Example : MonoBehaviour
    {
        public class InitialContext : AbstractInitialContext 
        {
            public override IService LookUp(string name)
            {
                // 获取 Example 所在的 Service
                #region 这段代码性能不好
                //var assembly = typeof(Example).Assembly;

                //var serviceType = typeof(IService);

                //var service = assembly
                //    .GetTypes()

                //    // 获取所有实现 IService 接口的类型
                //    .Where(t => serviceType.IsAssignableFrom(t) && !t.IsAbstract)
                //    // 创建实例
                //    .Select(t => t.GetConstructors().First<ConstructorInfo>().Invoke(null))
                //    // 转型为 IService
                //    .Cast<IService>()
                //    // 获取符合条件的 Service 对象
                //    .SingleOrDefault(s => s.Name == name); 
                #endregion

                #region 根据name创建实例这种好很多 
                IService service = null;
                if (name == "bluetooth")
                {
                    service = new BluetoothService();
                }
                #endregion

                return service;
            }
        }

        /// <summary>
        /// 蓝牙服务
        /// </summary>
        public class BluetoothService : IService
        {
            /// <summary>
            /// 服务
            /// </summary>
            public string Name
            {
                get { return "bluetooth"; }
            }

            public void Execute()
            {
                Debug.Log("蓝牙服务启动");
            }
        }

        // Start is called before the first frame update
        void Start()
        {
            // 创建查找器
            var context = new InitialContext();

            // 创建服务定位器
            var serviceLocator = new ServiceLocator(context);

            // 获取蓝牙服务
            var bluetoothServie = serviceLocator.GetService("bluetooth");

            // 执行服务
            bluetoothServie.Execute();
        }
    }
}

