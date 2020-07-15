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
        static ModuleContainer<IEditorPlatformModule> mModuleContainer = new ModuleContainer<IEditorPlatformModule>();

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
            mModuleContainer.Modules.Clear();
            //扫描
            mModuleContainer.Scan("Assembly-CSharp-Editor");
            editorPlatform.Show();
        }

        private void OnGUI()
        {
            //渲染
            foreach (var editorPlatformModule in mModuleContainer.Modules)
            {
                editorPlatformModule.OnGUI();
            }
        }

    }
   
}

