using Signal.Core.World;
using System;
using UnityEngine;

namespace Signal.Core.Entities.Application
{
    internal class EntityLifecycle : IEntityObserver, IDisposable
    {
        private readonly IHealthApi _healthApi;
        private readonly EntityRegistry _entityRegistry;
        private readonly EntityPresenterRegistry _presenterRegistry;
        private readonly EntityPresenterPool _presenterPool;

        public event EventHandler<EntityDiedEventArgs> EntityDied;

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
            var success = _entityRegistry.TryGet(instanceId, out var entity);

            if (!success)
            {
                Debug.LogWarning("Entity not found!");
                return;
            }

            _healthApi.Unregister(entity.HealthOwnerId);
            _entityRegistry.Remove(instanceId);

            if (_presenterRegistry.TryGet(instanceId, out var presenter))
            {
                _presenterRegistry.Remove(instanceId);
                _presenterPool.Release(presenter, entity.DefinitionId);

                var entityInfo = new EntityInfo(instanceId, entity.AttackDamage, entity.AttackSpeed, entity.AttackDistance, presenter.transform.position);
                var args = new EntityDiedEventArgs(entityInfo);
                EntityDied?.Invoke(this, args);
            }
        }

        public void Dispose()
        {
            _healthApi.HealthChanged -= HandleHealthChanged;
        }
    }
}
