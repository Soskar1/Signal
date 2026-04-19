using Signal.Core.World;
using System;

namespace Signal.Core.Entities.Application
{
    internal class EntityLifecycle : IDisposable
    {
        private readonly IHealthApi _healthApi;
        private readonly EntityRegistry _entityRegistry;
        private readonly EntityPresenterRegistry _presenterRegistry;
        private readonly EntityPresenterPool _presenterPool;

        public EntityLifecycle(IHealthApi healthApi, EntityRegistry entityRegistry, EntityPresenterRegistry presenterRegistry, EntityPresenterPool presenterPool)
        {
            _healthApi = healthApi;
            _entityRegistry = entityRegistry;
            _presenterRegistry = presenterRegistry;
            _presenterPool = presenterPool;
        }

        public void Initialize()
        {
            _healthApi.HealthChanged += HandleHealthChanged;
        }

        private void HandleHealthChanged(object _, HealthChangedEventArgs args)
        {
            if (!_entityRegistry.TryGetByHealthOwner(args.OwnerId, out var entity))
                return;

            if (!args.IsDead)
                return;

            Kill(entity.InstanceId);
        }

        private void Kill(EntityInstanceId instanceId)
        {
            var entity = _entityRegistry.Get(instanceId);

            _healthApi.Unregister(entity.HealthOwnerId);
            _entityRegistry.Remove(instanceId);

            if (_presenterRegistry.TryGet(instanceId, out var presenter))
            {
                _presenterRegistry.Remove(instanceId);
                _presenterPool.Release(presenter, entity.DefinitionId);
            }
        }

        public void Dispose()
        {
            _healthApi.HealthChanged -= HandleHealthChanged;
        }
    }
}
