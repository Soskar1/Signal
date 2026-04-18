using Signal.Core.Buildings.Domain;
using Signal.Core.Buildings.Infrastructure;
using Signal.Core.Buildings.Presentation;
using UnityEngine;

namespace Signal.Core.Buildings.Application
{
    internal class BuildingPlacement
    {
        private readonly BuildingPresenter _buildingPresenterPrefab;
        private readonly BuildingCatalog _buildingCatalog;
        private readonly BuildingActionFactory _buildingActionFactory;
        private readonly BuildingGrid _buildingGrid;
        private readonly GridOccupancy _gridOccupancy;

        public BuildingPlacement(BuildingPresenter buildingPresenterPrefab, BuildingCatalog catalog, BuildingActionFactory factory, BuildingGrid buildingGrid, GridOccupancy gridOccupancy)
        {
            _buildingPresenterPrefab = buildingPresenterPrefab;
            _buildingCatalog = catalog;
            _buildingActionFactory = factory;
            _buildingGrid = buildingGrid;
            _gridOccupancy = gridOccupancy;
        }

        public void PlaceBuilding(Vector2 worldPosition, string buildingId)
        {
            var gridPosition = GetGridPosition(worldPosition);
            PlaceBuilding(gridPosition, buildingId);
        }

        public void PlaceBuilding(GridPosition gridPosition, string buildingId)
        {
            var definition = _buildingCatalog.Get(buildingId);
            var action = _buildingActionFactory.Create(definition.ActionDefinition);
            var building = new Building(definition.Id, action);

            var worldPosition = GetSnappedWorldPosition(gridPosition);

            var presenter = GameObject.Instantiate(_buildingPresenterPrefab, worldPosition, Quaternion.identity);
            presenter.Initialize(building, definition.BaseSprite, definition.HeadSprite);

            _gridOccupancy.Occupy(gridPosition);
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