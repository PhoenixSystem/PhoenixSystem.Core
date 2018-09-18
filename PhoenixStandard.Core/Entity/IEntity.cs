using PhoenixStandard.Core.Component;

namespace PhoenixStandard.Core.Entity
{
    interface IEntity
    {
        bool HasComponent<T>() where T : IComponent;
        
    }
}