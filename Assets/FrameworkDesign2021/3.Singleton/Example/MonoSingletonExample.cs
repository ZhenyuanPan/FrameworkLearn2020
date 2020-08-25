using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace FrameworkDesign2021.Example
{
    public class MonoSingletonExample : MonoBehaviour
    {
        //MonoSingleton<T> 对 T 约束为必须派生自MonoSingleton<T>
        //GameManager 继承 MonoSingleton 那么正好满足泛型T的约束条件 所以 T 可以是 GameManager
        public class GameManager : MonoSingleton<GameManager> 
        {
            public override void OnSingletonInit()
            {
                print("GameManager Init");
            }
        }

        private void Start()
        {
            var instance1 = GameManager.Instance;
            var instance2 = GameManager.Instance;

            print(instance1.GetHashCode() == instance2.GetHashCode());
        }
    }

}
