namespace PhoenixStandard.Core.Component
{
    public interface IComponentFactory<T> where T : IComponent
    {
        T Create();
    }
}