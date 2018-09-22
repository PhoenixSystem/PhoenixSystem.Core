using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace PhoenixStandard.Core.Component
{
    public class EntityComponentManager : IEntityComponentManager
    {
        readonly Dictionary<Type, ConcurrentDictionary<long, IComponent>> _componentLists = new Dictionary<Type, ConcurrentDictionary<long, IComponent>>();
        public EntityComponentManager()
        {

        }

        public void AddComponentToEntity(long entityId, IComponent component)
        {
            Type t = component.GetType();
            ConcurrentDictionary<long, IComponent> dic;
            if (_componentLists.ContainsKey(t))
            {
                dic = _componentLists[t];
            }
            else
            {
                dic = new ConcurrentDictionary<long, IComponent>();
                _componentLists.Add(t, dic);
            }
            if (dic.ContainsKey(entityId))
                throw new ApplicationException($"EntityId: {entityId} already has component of type {t.ToString()}");
            dic.TryAdd(entityId, component);
            component.AttachedEntityId = entityId;
        }

        public bool EntityHasComponents(long entityId, IEnumerable<Type> componentTypes)
        {
            foreach(Type t in componentTypes) {
                if(!_componentLists.ContainsKey(t))
                    return false;
                if(!_componentLists[t].ContainsKey(entityId))
                    return false;
            }
            return true;
        }

        public IComponent RemoveComponentFromEntity(long entityId, Type componentType)
        {
            IComponent deleted;
            if(!_componentLists.ContainsKey(componentType))
                throw new ApplicationException($"No entities exist with component type {componentType.ToString()}");
            var success = _componentLists[componentType].TryRemove(entityId, out deleted);
            if(!success)
                throw new ApplicationException($"EntityId {entityId} does not have component of type {componentType.ToString()} to remove");
            return deleted;
        }

    }
}