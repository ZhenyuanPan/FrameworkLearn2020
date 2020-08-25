using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
namespace FrameworkDesign2021
{
    public abstract class MonoSingleton<T> : MonoBehaviour, ISingleton where T : MonoSingleton<T>
    {
        protected static bool mOnApplicationQuit = false;
        public static bool IsApplicationQuit 
        {
            get => mOnApplicationQuit;
        }
        protected static T mInstance;
        public static T Instance 
        {
            get 
            {
                if (mInstance == null && !mOnApplicationQuit)
                {
                    mInstance = MonoSingletonCreator.CreateMonoSingleton<T>();
                }
                return mInstance;
            }
        }
        public virtual void OnSingletonInit() { }
        
        protected virtual void OnApplicationQuit() 
        {
            mOnApplicationQuit = true;
            if (mInstance == null)
            {
                return;
            }
            Destroy(mInstance.gameObject);
            mInstance = null;
        }

        public virtual void Dispose() 
        {
            Destroy(gameObject);
        }

        protected virtual void OnDestory() 
        {
            mInstance = null;
        }

    }

}
