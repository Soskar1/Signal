using Signal.Core.Buildings.Domain;
using Signal.Core.Buildings.Infrastructure;
using Signal.Core.Buildings.Presentation;
using Signal.Core.Entities.Application;
using Signal.Core.World;
using UnityEngine;

namespace Signal.Core.Buildings.Application
{
    internal class BuildingSpawner
    {
        private readonly BuildingPresenter _buildingPresenterPrefab;
        private readonly BuildingCatalog _buildingCatalog;
        private readonly BuildingActionFactory _buildingActionFactory;
        private readonly BuildingRegistry _buildingRegistry;
        private readonly BuildingPresenterRegistry _buildingPresenterRegistry;
        private readonly GridSnapper _gridSnapper;
        private readonly IHealthApi _healthApi;
        private readonly IEntityInstanceIdFactory _entityInstanceIdFactory;

        public BuildingSpawner(
            BuildingPresenter buildingPresenterPrefab,
            BuildingCatalog catalog,
            BuildingActionFactory factory,
            BuildingRegistry buildingRegistry,
            BuildingPresenterRegistry presenterRegistry,
            GridSnapper gridSnapper,
            IHealthApi healthApi,
            IEntityInstanceIdFactory instanceIdFactory)
        {
            _buildingPresenterPrefab = buildingPresenterPrefab;
            _buildingCatalog = catalog;
            _buildingActionFactory = factory;
            _buildingRegistry = buildingRegistry;
            _buildingPresenterRegistry = presenterRegistry;
            _gridSnapper = gridSnapper;
            _healthApi = healthApi;
            _entityInstanceIdFactory = instanceIdFactory;
        }

        public void Spawn(Vector2 worldPosition, BuildingId buildingId)
        {
            var gridPosition = _gridSnapper.GetGridPosition(worldPosition);
            Spawn(gridPosition, buildingId);
        }

        public void Spawn(GridPosition gridPosition, BuildingId buildingId)
        {
            var worldPosition = _gridSnapper.GetSnappedWorldPosition(gridPosition);

            var definition = _buildingCatalog.Get(buildingId.Id);
            var action = _buildingActionFactory.Create(definition.ActionDefinition, worldPosition);

            var healthOwnerId = _healthApi.Register(definition.Health);
            var entityInstanceId = _entityInstanceIdFactory.Create(healthOwnerId);

            var building = new Building(definition.Id, entityInstanceId, gridPosition, worldPosition, action);

            _buildingRegistry.Add(building);

            var presenter = GameObject.Instantiate(_buildingPresenterPrefab, worldPosition, Quaternion.identity);
            presenter.Initialize(building, definition.BaseSprite, definition.HeadSprite, definition.AnimatorController);

            _buildingPresenterRegistry.Add(entityInstanceId, presenter);
        }

        public bool CanPlace(GridPosition position)
        {
            return !_buildingRegistry.IsOccupied(position);
        }
    }
}