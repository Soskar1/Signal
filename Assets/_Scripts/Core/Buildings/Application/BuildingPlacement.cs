using Signal.Core.Buildings.Domain;
using Signal.Core.Buildings.Infrastructure;
using Signal.Core.Buildings.Presentation;
using UnityEngine;

namespace Signal.Core.Buildings.Application
{
    internal class BuildingPlacement : IBuildingPlacement
    {
        private readonly BuildingPresenter _buildingPresenterPrefab;
        private readonly BuildingCatalog _buildingCatalog;
        private readonly BuildingActionFactory _buildingActionFactory;
        private readonly BuildingGrid _grid;

        public BuildingPlacement(BuildingPresenter buildingPresenterPrefab, BuildingCatalog catalog, BuildingActionFactory factory, BuildingGrid buildingGrid)
        {
            _buildingPresenterPrefab = buildingPresenterPrefab;
            _buildingCatalog = catalog;
            _buildingActionFactory = factory;
            _grid = buildingGrid;
        }

        public void PlaceBuilding(Vector3 worldPosition, BuildingId buildingId)
        {
            var definition = _buildingCatalog.Get(buildingId);
            var action = _buildingActionFactory.Create(definition.ActionDefinition);
            var building = new Building(definition.Id, action);

            var cell = _grid.WorldToGrid(worldPosition);
            var snappedPosition = _grid.GridToWorld(cell);

            var presenter = GameObject.Instantiate(_buildingPresenterPrefab, snappedPosition, Quaternion.identity);
            presenter.Initialize(building, definition.Sprite);
        }
    }
}