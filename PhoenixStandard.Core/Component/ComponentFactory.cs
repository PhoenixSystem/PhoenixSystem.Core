using System;
using System.Collections.Generic;

namespace PhoenixStandard.Core.Component
{
    public class ComponentFactory : IComponentFactory
    {
        private readonly Dictionary<Type, Stack<IComponent>> _availableComponents = new Dictionary<Type, Stack<IComponent>>();
        public T Get<T>() where T: IComponent, new()
        {
            Stack<IComponent> _stack;
            Type t = typeof(T);
            if (_availableComponents.ContainsKey(t))
            {
                _stack = _availableComponents[t];
            }
            else
            {
                _stack = new Stack<IComponent>();
                _availableComponents.Add(t, _stack);
            }

            if (_stack.Count > 0)
            {
                return (T)_stack.Pop();
            }
            return new T();
        }

        public void Release(IComponent component)
        {
            Type t = component.GetType();
            component.Reset();
            _availableComponents[t].Push(component);
        }

    }
}