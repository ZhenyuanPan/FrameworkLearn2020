using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace FrameworkDesign2021.Example
{
    public class SingletonExample : MonoBehaviour
    {
        public class GameManager : Singleton<GameManager> 
        {
            private GameManager() { }

            public void PlayGame() 
            {
                print("PlayGame");
            }
        }
        private void Start()
        {
            GameManager.Instance.PlayGame();
            var instance = GameManager.Instance;
            var instance1 = GameManager.Instance;
            print(instance.GetHashCode() == instance1.GetHashCode());
        }
    }
}
