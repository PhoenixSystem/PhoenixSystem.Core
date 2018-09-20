namespace PhoenixStandard.Core.Component
{
    public interface IComponent
    {
        long AttachedEntityId { get; }
        void Reset();
    }
}