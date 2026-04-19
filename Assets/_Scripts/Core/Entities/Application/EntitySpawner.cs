using Signal.Core.Entities;
using Signal.Core.Entities.Application;
using Signal.Core.Entities.Infrastructure;
using Signal.Core.World;
using UnityEngine;
using EntityId = Signal.Core.Entities.EntityId;

namespace Singal.Core.Entities.Application
{
    internal class EntitySpawner : IEntitySpawner
    {
        private readonly EntityFactory _entityFactory;
        private readonly EntityPresenterPool _presenterPool;
        private readonly EntityRegistry _entityRegistry;
        private readonly EntityPresenterRegistry _presenterRegistry;
        private readonly EntityDefinitionCatalog _entityCatalog;
        private readonly IHealthApi _healthApi;

        public EntitySpawner(
            EntityFactory entityFactory,
            EntityPresenterPool presenterPool,
            EntityRegistry entityRegistry,
            EntityPresenterRegistry presenterRegistry,
            EntityDefinitionCatalog entityCatalog,
            IHealthApi healthApi)
        {
            _entityFactory = entityFactory;
            _presenterPool = presenterPool;
            _entityRegistry = entityRegistry;
            _presenterRegistry = presenterRegistry;
            _entityCatalog = entityCatalog;
            _healthApi = healthApi;
        }

        public EntityInstanceId Spawn(EntityId entityId, Vector2 position)
        {
            var entity = _entityFactory.Create(entityId);
            _entityRegistry.Add(entity);

            var definition = _entityCatalog.Get(entityId.RawId);
            var presenter = _presenterPool.Get(entityId);

            presenter.Initialize(entity, definition.Sprite);
            presenter.transform.position = position;

            _presenterRegistry.Add(entity.InstanceId, presenter);

            return entity.InstanceId;
        }

        public void Release(EntityInstanceId instanceId)
        {
            var success = _entityRegistry.TryGet(instanceId, out var entity);

            if (!success)
            {
                Debug.LogWarning("Entity not found");
                return;
            }

            _healthApi.Unregister(entity.HealthOwnerId);
            _entityRegistry.Remove(instanceId);

            if (_presenterRegistry.TryGet(instanceId, out var presenter))
            {
                _presenterRegistry.Remove(instanceId);
                _presenterPool.Release(presenter, entity.DefinitionId);
            }
        }
    }
}
