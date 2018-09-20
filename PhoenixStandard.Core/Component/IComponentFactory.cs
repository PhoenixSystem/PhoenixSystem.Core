namespace PhoenixStandard.Core.Component
{
    public interface IComponentFactory<T> where T : IComponent
    {
        IComponent Create();
    }
}