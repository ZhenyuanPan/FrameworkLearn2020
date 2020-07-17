using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FrameworkDesign2021.ServiceLocator 
{
    public interface IModuleCache
    {
        object GetModule(ModuleSearchKeys keys);
        //改动
        object GetAllModules();
        void AddModule(ModuleSearchKeys keys, object module);
    }

}
