using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace PhoenixStandard.Core.Component
{
    public interface IEntityComponentManager
    {
        bool EntityHasComponents(long entityId, IEnumerable<Type> componentTypes);
        void AddComponentToEntity(long entityId, IComponent component);
        IComponent RemoveComponentFromEntity(long entityId, Type componentType);
    }
}