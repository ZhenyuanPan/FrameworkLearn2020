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
            //组装 Contariner
            var cache = new EditorPlatformModuleCache();
            var factory = new EditorPlatformModuleFactory();

            editorPlatform.mModuleContainer = new ModuleContainer(cache,factory);

            editorPlatform.Show();
        }

        private void OnGUI()
        {
            //获取全部模块
            var modules = mModuleContainer.GetModules<IEditorPlatformModule>();

            //渲染
            foreach (var editorPlatformModule in modules)
            {
                editorPlatformModule.OnGUI();
            }
        }

    }
   
}

