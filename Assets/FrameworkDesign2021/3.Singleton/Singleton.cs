using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkDesign2021
{
    //接口是最高级别的抽象用来指定规则 抽象函数次之!!!
    public abstract class Singleton<T> : ISingleton where T : Singleton<T>
    {
        protected static T mInstance;
        static object mLock = new object();

        public static T Instance
        {
            get
            {
                lock (mLock)
                {
                    if (mInstance == null)
                    {
                        mInstance = SingletonCreator.CreateSingleton<T>();
                    }
                }
                return mInstance;
            }
        }

        public virtual void Dispose() 
        {
            mInstance = null;
        }

        public void OnSingletonInit()
        {
          
        }
    }
}
