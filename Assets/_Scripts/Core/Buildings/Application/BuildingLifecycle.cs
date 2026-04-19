using Signal.Core.Entities.Application;
using Signal.Core.World;
using System;
using UnityEngine;

namespace Signal.Core.Buildings.Application
{
    internal class BuildingLifecycle : IDisposable
    {
        private readonly BuildingRegistry _buildingRegistry;
        private readonly BuildingPresenterRegistry _presenterRegistry;
        private readonly IHealthApi _healthApi;

        public BuildingLifecycle(BuildingRegistry buildingRegistry, BuildingPresenterRegistry presenterRegistry, IHealthApi healthApi)
        {
            _buildingRegistry = buildingRegistry;
            _presenterRegistry = presenterRegistry;
            _healthApi = healthApi;
        }

        public void Initialize()
        {
            _healthApi.HealthChanged += HandleHealthChanged;
        }

        private void HandleHealthChanged(object _, HealthChangedEventArgs args)
        {
            if (!_buildingRegistry.TryGetByHealthOwner(args.OwnerId, out var building))
                return;

            if (!args.IsDead)
                return;

            Kill(building.InstanceId);
        }

        private void Kill(EntityInstanceId instanceId)
        {
            var buildingPresenter = _presenterRegistry.Get(instanceId);

            _healthApi.Unregister(instanceId.HealthOwnerId);
            _buildingRegistry.Remove(instanceId);

            if (_presenterRegistry.TryGet(instanceId, out var presenter))
            {
                _presenterRegistry.Remove(instanceId);
                GameObject.Destroy(presenter.gameObject);
            }
        }

        public void Dispose()
        {
            _healthApi.HealthChanged -= HandleHealthChanged;
        }
    }
}
