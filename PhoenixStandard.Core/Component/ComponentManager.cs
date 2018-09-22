using System;
using System.Collections.Generic;

namespace PhoenixStandard.Core.Component
{
    public class ComponentManager : IComponentManager
    {
        readonly ComponentFactory _factory = new ComponentFactory();
        void IComponentManager.RegisterComponentType<T>()
        {
            
        }

        void IComponentManager.UnregisterComponentType<T>()
        {
            throw new global::System.NotImplementedException();
        }
    }
}