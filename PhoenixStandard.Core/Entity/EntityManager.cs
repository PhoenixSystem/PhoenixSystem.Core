using System.Collections.Generic;
using System.Linq;

namespace PhoenixStandard.Core.Entity
{
    public class EntityManager : IEntityManager
    {
        private readonly List<long> _availableEntityIds = new List<long>();
        private readonly List<long> _entityIds = new List<long>();

        public bool DeleteEntity(long id)
        {
            if (!_entityIds.Contains(id))
                return false;

            _entityIds.Remove(id);
            _availableEntityIds.Add(id);
            _availableEntityIds.Sort();
            return true;
        }

        public long NewEntity()
        {
            var newId = GetNewEntityId();
            _entityIds.Add(newId);
            _entityIds.Sort();
            return newId;
        }

        protected long GetNewEntityId()
        {
            if (!HasAnyEntities())
                return 0;

            if (!HasAnyEntitiesAvailableForReuse())
                return _entityIds.Last() + 1;

            var newId = _availableEntityIds[0];
            _availableEntityIds.RemoveAt(0);

            return newId;
        }

        protected bool HasAnyEntitiesAvailableForReuse()
        {
            return _availableEntityIds.Count > 0;
        }

        protected bool HasAnyEntities()
        {
            return _entityIds.Count > 0;
        }
    }
}