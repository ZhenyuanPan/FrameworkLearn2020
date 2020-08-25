
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace FrameworkDesign2021
{
    public static class MonoSingletonCreator
    {
        //静态共有方法 where 是对泛型T 的约束
        public static T CreateMonoSingleton<T>() where T : MonoBehaviour,ISingleton 
        {
            //尝试获取场景内的 T 脚本
            var instance = Object.FindObjectOfType<T>();
            //如果存在则直接返回
            if (instance)
            {
                instance.OnSingletonInit();
                return instance;
            }
            //没有的话 创建实例
            if (!instance)
            {
                var gameObj = new GameObject(typeof(T).Name);
                Object.DontDestroyOnLoad(gameObj);
                instance = gameObj.AddComponent<T>();
            }
            instance.OnSingletonInit();
            return instance;
        }


    }
}
