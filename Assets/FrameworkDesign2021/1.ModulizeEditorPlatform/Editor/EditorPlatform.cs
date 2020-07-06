using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using System.Reflection;
namespace FrameworkDesign2021
{
    public class EditorModulizationPlatformEditor : EditorWindow
    {
        /// <summary>
        /// 用来储存模块
        /// </summary>
        static List<IEditorPlatformModule> mModules = new List<IEditorPlatformModule>();

        ///这个方法显示到菜单栏，对应的是下面的地址产生的按钮
        [MenuItem("FrameworkDesign2021/0.EditorModulizationPlatform")]
        public static void Open() 
        {
            //产生一个对话框
            var editorPlatform = GetWindow<EditorModulizationPlatformEditor>();
            //规定对话框的大小位置
            editorPlatform.position = new Rect(Screen.width/2,Screen.height*2/3,600,500);
            //启动
            editorPlatform.Show();

            //清空之前的实例
            mModules.Clear();
            //1.获取当前项目中所有的assembly(可以理解为代码编译好的DLL)
            var assemblies = AppDomain.CurrentDomain.GetAssemblies();
            //2.获取编辑器环境(DLL)
            var editorAssembly = assemblies.First(assembly => assembly.FullName.StartsWith("Assembly-CSharp-Editor"));
            //3.获取 IEditorPlatformModule 类型
            var moduleType = typeof(IEditorPlatformModule);

            mModules = editorAssembly
               //获取所有的编辑器环境中的类型 
               .GetTypes()
               //过滤掉抽象类型（接口/抽象类)、和未实现 IEditorPlatformModule 的类型
               .Where(type => moduleType.IsAssignableFrom(type) && !type.IsAbstract)
               //获取类型的构造创造实例
               .Select(type => type.GetConstructors().First().Invoke(null))
               //强制转换成 IEdiorPlatformModule 类型
               .Cast<IEditorPlatformModule>()
               //转换成 List<IEditorPlatformModule>
               .ToList();

            editorPlatform.Show();
        }

        private void OnGUI()
        {
            //渲染
            foreach (var editorPlatformModule in mModules)
            {
                editorPlatformModule.OnGUI();
            }
        }

    }
   
}

