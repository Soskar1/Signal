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
        private readonly BuildingGridSnapper _gridSnapper;
        private readonly GridOccupancy _gridOccupancy;

        public BuildingPlacement(BuildingPresenter buildingPresenterPrefab, BuildingCatalog catalog, BuildingActionFactory factory, BuildingGridSnapper gridSnapper, GridOccupancy gridOccupancy)
        {
            _buildingPresenterPrefab = buildingPresenterPrefab;
            _buildingCatalog = catalog;
            _buildingActionFactory = factory;
            _gridSnapper = gridSnapper;
            _gridOccupancy = gridOccupancy;
        }

        public void PlaceBuilding(GridPosition gridPosition, string buildingId)
        {
            var definition = _buildingCatalog.Get(buildingId);
            var action = _buildingActionFactory.Create(definition.ActionDefinition);
            var building = new Building(definition.Id, action);

            var worldPosition = _gridSnapper.ToWorldPosition(gridPosition);

            var presenter = GameObject.Instantiate(_buildingPresenterPrefab, worldPosition, Quaternion.identity);
            presenter.Initialize(building, definition.Sprite);

            _gridOccupancy.Occupy(gridPosition);
        }
    }
}