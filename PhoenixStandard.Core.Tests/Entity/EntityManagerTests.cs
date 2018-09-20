using PhoenixStandard.Core.Entity;
using Xunit;

namespace PhoenixStandard.Core.Tests.Entity
{
    public class EntityManagerTests
    {
        private readonly EntityManager _manager;

        public EntityManagerTests()
        {
            _manager = new EntityManager();
        }

        [Fact]
        public void CanCreateNewEntity()
        {
            Assert.Equal(0, _manager.NewEntity());
        }

        [Fact]
        public void CanCreateMultipleNewEntitiesWithSequentialIds()
        {
            for (var index = 0; index < 10; index++)
            {
                Assert.Equal(index, _manager.NewEntity());
            }
        }

        [Fact]
        public void CanDeleteEntities()
        {
            var entityId = _manager.NewEntity();
            Assert.True(_manager.DeleteEntity(entityId));
        }

        [Fact]
        public void CanDeleteEntitiesReturnsFalseIfNoEntityRemoved()
        {
            _manager.NewEntity();
            Assert.False(_manager.DeleteEntity(long.MaxValue));
        }
    }
}