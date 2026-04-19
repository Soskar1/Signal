using Signal.Core.Entities.Domain;
using Signal.Core.Entities.Infrastructure;
using Signal.Core.World;

namespace Signal.Core.Entities.Application
{
    internal class EntityFactory
    {
        private readonly IHealthApi _healthApi;
        private readonly EntityDefinitionCatalog _entityCatalog;
        private int _nextInstanceId = 1;

        public EntityFactory(EntityDefinitionCatalog entityCatalog, IHealthApi healthApi)
        {
            _entityCatalog = entityCatalog;
            _healthApi = healthApi;
        }

        public Entity Create(EntityId entityId)
        {
            var definition = _entityCatalog.Get(entityId.Id);

            var healthOwnerId = _healthApi.Register(definition.Health);
            var instanceId = new EntityInstanceId(_nextInstanceId, healthOwnerId);
            ++_nextInstanceId;

            return new Entity(instanceId, entityId);
        }
    }
}