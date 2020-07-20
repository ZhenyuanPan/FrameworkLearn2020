﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrameworkDesign2021.ServiceLocator.LayerdArchitectureExample
{
    /// <summary>
    /// 层级基类
    /// </summary>
    public interface IModuleLayer
    {
        T GetModule<T>() where T : class;
    }

    /// <summary>
    /// 逻辑层, UI/Game
    /// </summary>
    public interface ILogicLayer : IModuleLayer 
    {
        
    }

    /// <summary>
    /// 业务模块层
    /// </summary>
    public interface IBusinessModuleLayer : IModuleLayer 
    {
        
    }

    /// <summary>
    /// 公共模块层
    /// </summary>
    public interface IPublichModuleLayer : IModuleLayer
    {
    }

    /// <summary>
    /// 基础设施层
    /// </summary>
    public interface IBasicModuleLayer : IModuleLayer
    {
    }

    /// <summary>
    /// 工具层
    /// </summary>
    public interface IUtiltyLayer : IModuleLayer
    {
    }
}
