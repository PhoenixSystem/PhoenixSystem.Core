using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace PhoenixStandard.Core.Component
{
    public class ComponentManager : IComponentManager
    {
        private readonly ConcurrentDictionary<long, IComponent> _entities;
        private readonly ConcurrentBag<IComponent> _components;
        private readonly IComponentFactory<IComponent> _factory;

        public ComponentManager(IComponentFactory<IComponent> factory)
        {
            _factory = factory;
            _entities = new ConcurrentDictionary<long, IComponent>();
            _components = new ConcurrentBag<IComponent>();            
        }

        public bool AddComponentToEntity(long entityId, IComponent component)
        {
            _components.Add(component);
            return _entities.TryAdd(entityId, component);
        }

        public bool EntityHasComponents(long entityId, IEnumerable<Type> componentTypes)
        {
            if (componentTypes == null) return false;
            return _entities.ContainsKey(entityId) &&
                   _entities.TryGetValue(entityId, out var component) &&
                   componentTypes.Contains(component.GetType());
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