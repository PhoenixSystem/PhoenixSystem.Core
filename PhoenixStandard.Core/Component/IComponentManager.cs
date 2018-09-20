using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace PhoenixStandard.Core.Component
{
    interface IComponentManager
    {
        ConcurrentDictionary<long,T> RegisterComponentType<T>() where T:IComponent;
        bool UnregisterComponentType<T>() where T:IComponent;
        bool EntityHasComponents(long entityId, IEnumerable<Type> componentTypes);
        bool AddComponentToEntity(long entityId, IComponent component);
        bool RemoveComponentFromEntity(long entityId, Type componentType);
        
    }
}