using Signal.Core.Entities.Application;
using Signal.Core.World;
using System;
using UnityEngine;

namespace Signal.Core.Buildings.Application
{
    internal class BuildingLifecycle : IBuildingObserver, IDisposable
    {
        private readonly BuildingRegistry _buildingRegistry;
        private readonly BuildingPresenterRegistry _presenterRegistry;
        private readonly IHealthApi _healthApi;

        public event EventHandler<BuildingDestroyedEventArgs> BuildingDestroyed;

        public BuildingLifecycle(BuildingRegistry buildingRegistry, BuildingPresenterRegistry presenterRegistry, IHealthApi healthApi)
        {
            _buildingRegistry = buildingRegistry;
            _presenterRegistry = presenterRegistry;
            _healthApi = healthApi;

            _healthApi.HealthChanged += HandleHealthChanged;
        }

        private void HandleHealthChanged(object _, HealthChangedEventArgs args)
        {
            if (!_buildingRegistry.TryGet(args.OwnerId, out var building))
                return;

            var buildingPresenter = _presenterRegistry.Get(building.InstanceId);
            buildingPresenter.UpdateHealthBar(args.Current, args.Max);

            if (!args.IsDead)
                return;

            Kill(building.InstanceId);
        }

        private void Kill(EntityInstanceId instanceId)
        {
            var buildingPresenter = _presenterRegistry.Get(instanceId);

            _healthApi.Unregister(instanceId.HealthOwnerId);
            var building = _buildingRegistry.Get(instanceId);
            _buildingRegistry.Remove(instanceId);

            if (_presenterRegistry.TryGet(instanceId, out var presenter))
            {
                _presenterRegistry.Remove(instanceId);
                GameObject.Destroy(presenter.gameObject);
            }

            var buildingInfo = new BuildingInfo(instanceId, building.Id, building.WorldPosition);
            var args = new BuildingDestroyedEventArgs(buildingInfo);
            BuildingDestroyed?.Invoke(this, args);
        }

        public void Dispose()
        {
            _healthApi.HealthChanged -= HandleHealthChanged;
        }
    }
}
