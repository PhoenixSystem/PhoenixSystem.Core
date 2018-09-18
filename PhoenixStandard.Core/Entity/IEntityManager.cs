namespace PhoenixStandard.Core.Entity
{
    interface IEntityManager
    {
        long NewEntity();
        bool DeleteEntity(long id);
    }
}