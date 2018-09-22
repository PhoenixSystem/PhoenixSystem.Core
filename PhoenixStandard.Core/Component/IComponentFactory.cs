namespace PhoenixStandard.Core.Component
{
    public interface IComponentFactory
    {
        T Get<T>() where T : IComponent, new();
        void Release(IComponent component);
    }
}