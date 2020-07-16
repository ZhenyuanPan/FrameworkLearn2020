using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FrameworkDesign2021.ServiceLocator 
{
    public interface IModuleCache
    {
        object GetModuleByName(string name);
        object GetModuleByType(Type type);
        IEnumerable<object> GetModulesByName(string name);
        IEnumerable<object> GetModulesByType(Type type);
        void AddModuleByName(string name,object module);
        void AddModuleByType(Type type,object module);
        void AddModulesByName(string name,IEnumerable<object> modules);
        void AddModulesByType(Type type,IEnumerable<object> modules);
    }

}
