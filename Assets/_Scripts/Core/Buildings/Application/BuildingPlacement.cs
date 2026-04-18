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

        public BuildingPlacement(BuildingPresenter buildingPresenterPrefab, BuildingCatalog catalog, BuildingActionFactory factory)
        {
            _buildingPresenterPrefab = buildingPresenterPrefab;
            _buildingCatalog = catalog;
            _buildingActionFactory = factory;
        }

        public void PlaceBuilding(Transform transform, BuildingId buildingId)
        {
            var definition = _buildingCatalog.Get(buildingId);
            var action = _buildingActionFactory.Create(definition.ActionDefinition);
            var building = new Building(definition.Id, action);

            var presenter = GameObject.Instantiate(_buildingPresenterPrefab, transform);
            presenter.Initialize(building, definition.Sprite);
        }
    }
}