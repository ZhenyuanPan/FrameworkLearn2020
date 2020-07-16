using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FrameworkDesign2021.ServiceLocator;
namespace FrameworkDesign2021
{
    public class EditorPlatformModuleFactory : IModuleFactory
    {

        /// <summary>
        /// 缓存全部类型
        /// </summary>
        private List<Type> mModuleTypes;

        /// <summary>
        /// 在构造时候做扫描操作
        /// </summary>
        public EditorPlatformModuleFactory() 
        {
            mModuleTypes = AppDomain.CurrentDomain.GetAssemblies()
                //看看解决方案资源管理器就明白了了
                .Single(a => a.FullName.StartsWith("Assembly-CSharp-Editor"))
                .GetTypes()
                .Where(t => typeof(IEditorPlatformModule).IsAssignableFrom(t) && !t.IsAbstract)
                .ToList();
            var b = mModuleTypes;
        }
       

        private object CreateAllModules() 
        {
            return mModuleTypes.Select(t => t.GetConstructors().First().Invoke(null)).Cast<IEditorPlatformModule>();
        }

        #region 不实现了 用不到
        public object CreateModuleByName(string name)
        {
            throw new NotImplementedException();
        }

        public object CreateMoudleType(Type type)
        {
            throw new NotImplementedException();
        }
        #endregion


        public object CreateModulesByType(Type type)
        {
            return CreateAllModules();
        }
        public object CreateModulesByName(string name)
        {
            return CreateAllModules();
        }
    
    }
}
