namespace PhoenixStandard.Core.Component
{
    public interface IComponentManager
    {
        void RegisterComponentType<T>() where T:IComponent, new();
        void UnregisterComponentType<T>() where T: IComponent, new();
    }
}