using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace PhoenixStandard.Core.Component
{
    public class ComponentManager : IComponentManager
    {
        private readonly IComponentFactory<IComponent> _factory;

        public ComponentManager(IComponentFactory<IComponent> factory)
        {
            _factory = factory;
        }

        public bool AddComponentToEntity(long entityId, IComponent component)
        {
            throw new NotImplementedException();
        }

        public bool EntityHasComponents(long entityId, IEnumerable<Type> componentTypes)
        {
            throw new NotImplementedException();
        }

        public ConcurrentDictionary<long, T> RegisterComponentType<T>() where T : IComponent
        {
            throw new NotImplementedException();
        }

        public bool RemoveComponentFromEntity(long entityId, Type componentType)
        {
            throw new NotImplementedException();
        }

        public bool UnregisterComponentType<T>() where T : IComponent
        {
            throw new NotImplementedException();
        }
    }
}