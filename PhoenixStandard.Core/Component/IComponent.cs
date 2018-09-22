namespace PhoenixStandard.Core.Component
{
    public interface IComponent
    {
        long AttachedEntityId { get; set; }
        void Reset();
    }
}