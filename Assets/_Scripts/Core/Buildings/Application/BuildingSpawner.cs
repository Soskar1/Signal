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
        private readonly BuildingGrid _buildingGrid;
        private readonly GridOccupancy _gridOccupancy;
        private readonly BuildingRegistry _buildingRegistry;
        private readonly BuildingPresenterRegistry _buildingPresenterRegistry;
        private readonly IHealthApi _healthApi;
        private readonly IEntityInstanceIdFactory _entityInstanceIdFactory;

        public BuildingSpawner(
            BuildingPresenter buildingPresenterPrefab,
            BuildingCatalog catalog,
            BuildingActionFactory factory,
            BuildingGrid buildingGrid,
            GridOccupancy gridOccupancy,
            BuildingRegistry buildingRegistry,
            BuildingPresenterRegistry presenterRegistry,
            IHealthApi healthApi,
            IEntityInstanceIdFactory instanceIdFactory)
        {
            _buildingPresenterPrefab = buildingPresenterPrefab;
            _buildingCatalog = catalog;
            _buildingActionFactory = factory;
            _buildingGrid = buildingGrid;
            _gridOccupancy = gridOccupancy;
            _buildingRegistry = buildingRegistry;
            _buildingPresenterRegistry = presenterRegistry;
            _healthApi = healthApi;
            _entityInstanceIdFactory = instanceIdFactory;
        }

        public void Spawn(Vector2 worldPosition, string buildingId)
        {
            var gridPosition = GetGridPosition(worldPosition);
            Spawn(gridPosition, buildingId);
        }

        public void Spawn(GridPosition gridPosition, string buildingId)
        {
            var definition = _buildingCatalog.Get(buildingId);
            var action = _buildingActionFactory.Create(definition.ActionDefinition);

            var healthOwnerId = _healthApi.Register(definition.Health);
            var entityInstanceId = _entityInstanceIdFactory.Create(healthOwnerId);
            var building = new Building(definition.Id, entityInstanceId, action);

            _buildingRegistry.Add(building);

            var worldPosition = GetSnappedWorldPosition(gridPosition);

            var presenter = GameObject.Instantiate(_buildingPresenterPrefab, worldPosition, Quaternion.identity);
            presenter.Initialize(building, definition.BaseSprite, definition.HeadSprite);

            _gridOccupancy.Occupy(gridPosition);

            _buildingPresenterRegistry.Add(entityInstanceId, presenter);
        }

        public GridPosition GetGridPosition(Vector3 worldPosition)
        {
            return _buildingGrid.WorldToGrid(worldPosition);
        }

        public Vector3 GetSnappedWorldPosition(GridPosition position)
        {
            return _buildingGrid.GridToWorld(position);
        }

        public bool CanPlace(GridPosition position)
        {
            return !_gridOccupancy.IsOccupied(position);
        }
    }
}