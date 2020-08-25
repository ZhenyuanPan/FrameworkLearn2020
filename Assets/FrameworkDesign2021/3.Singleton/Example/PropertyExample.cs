using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace FrameworkDesign2021.Example
{
    public class PropertyExample : MonoBehaviour
    {
        //定义基类
        public class BaseManager : MonoBehaviour 
        {
            
        }
        //定义实现类
        public class GameManage : BaseManager, ISingleton 
        {
            public static GameManage Instance 
            {
                get => MonoSingletonProperty<GameManage>.Instance;
            }

            public void OnSingletonInit()
            {
                print("GameManager Init");
            }
        }

        //定义基类
        public class BaseService { }

        public class BluetoothService : BaseService, ISingleton 
        {
            private BluetoothService() { }

            public static BluetoothService Instance 
            {
                get => SingletonProperty<BluetoothService>.Instance;
            }

            public void OnSingletonInit()
            {
                print("BluetoothService Init");
            }
        }


        private void Start()
        {
            var instance1 = GameManage.Instance;
            var instance2 = GameManage.Instance;

            print(instance1.GetHashCode() == instance2.GetHashCode());

            var service1 = BluetoothService.Instance;
            var service2 = BluetoothService.Instance;

            Debug.Log(service1.GetHashCode() == service2.GetHashCode());
        }

    }
}
