using Signal.Core.Entities.Domain;
using Signal.Core.Entities.Infrastructure;
using Signal.Core.World;

namespace Signal.Core.Entities.Application
{
    internal class EntityFactory
    {
        private readonly IHealthApi _healthApi;
        private readonly IEntityInstanceIdFactory _instanceIdFactory;
        private readonly EntityDefinitionCatalog _entityCatalog;

        public EntityFactory(EntityDefinitionCatalog entityCatalog, IHealthApi healthApi, IEntityInstanceIdFactory instanceIdFactory)
        {
            _entityCatalog = entityCatalog;
            _healthApi = healthApi;
            _instanceIdFactory = instanceIdFactory;
        }

        public Entity Create(EntityId entityId)
        {
            var definition = _entityCatalog.Get(entityId.Id);

            var healthOwnerId = _healthApi.Register(definition.Health);
            var instanceId = _instanceIdFactory.Create(healthOwnerId);

            return new Entity(instanceId, entityId);
        }
    }
}