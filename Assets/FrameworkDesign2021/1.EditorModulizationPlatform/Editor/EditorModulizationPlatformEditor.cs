using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using System.Reflection;
using FrameworkDesign2021.ServiceLocator.Default;

namespace FrameworkDesign2021
{
    public class EditorModulizationPlatformEditor : EditorWindow
    {
        /// <summary>
        /// 用来缓存模块的容器
        /// </summary>
        private ModuleContainer mModuleContainer = null;

        /// <summary>
        /// 打开窗口
        /// </summary>
        [MenuItem("FrameworkDesign2021/0.EditorModulizationPlatform")]
        public static void Open() 
        {
            //产生一个对话框
            var editorPlatform = GetWindow<EditorModulizationPlatformEditor>();
            //规定对话框的大小位置
            editorPlatform.position = new Rect(Screen.width/2,Screen.height*2/3,600,500);
            //组装 Contariner 这地方做了修改
            var moduleType = typeof(IEditorPlatformModule);
            var cache = new DefaultModuleCache();
            var factory = new AssemblyModuleFactory(moduleType.Assembly,moduleType);

            editorPlatform.mModuleContainer = new ModuleContainer(cache,factory);

            editorPlatform.Show();
        }

        private void OnGUI()
        {
            //改动部分
            //获取全部模块
            var modules = mModuleContainer.GetAllModules<IEditorPlatformModule>();

            //渲染
            foreach (var editorPlatformModule in modules)
            {
                editorPlatformModule.OnGUI();
            }
        }

    }
   
}

