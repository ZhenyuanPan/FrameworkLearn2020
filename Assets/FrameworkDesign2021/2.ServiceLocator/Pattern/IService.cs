using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FrameworkDesign2021.ServiceLocator.Pattern
{
    public interface IService
    {
        string Name { get; }

        void Execute();
    }
}
