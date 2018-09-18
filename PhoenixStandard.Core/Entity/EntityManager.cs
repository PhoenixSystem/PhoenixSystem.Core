using System.Collections.Generic;
using System.Linq;

namespace PhoenixStandard.Core.Entity
{
    public class EntityManager : IEntityManager
    {
        private readonly List<long> _entityIds = new List<long>();
        private readonly List<long> _availableEntityIds = new List<long>();

        public bool DeleteEntity(long id)
        {
            if (_entityIds.Contains(id))
            {
                _entityIds.Remove(id);
                _availableEntityIds.Add(id);
                _availableEntityIds.Sort();
                return true;
            }
            return false;
        }

        public long NewEntity()
        {
            long newId = -1;
            if (_availableEntityIds.Count > 0)
            {
                newId = _availableEntityIds[0];
                _availableEntityIds.RemoveAt(0);
            }
            else
            {
                newId = _entityIds.Last() + 1;
            }
            _entityIds.Add(newId);
            _entityIds.Sort();
            return newId;
        }
    }
}