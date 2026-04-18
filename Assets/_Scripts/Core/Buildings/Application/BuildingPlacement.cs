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

        public BuildingPlacement(BuildingPresenter buildingPresenterPrefab, BuildingCatalog catalog)
        {
            _buildingPresenterPrefab = buildingPresenterPrefab;
            _buildingCatalog = catalog;
        }

        public void PlaceBuilding(Transform transform, BuildingId buildingId)
        {
            var definition = _buildingCatalog.Get(buildingId);
            var building = new Building(definition.Id, definition.BuildingAction);

            var presenter = GameObject.Instantiate(_buildingPresenterPrefab, transform);
            presenter.Initialize(building);
        }
    }
}