using Reflex.Attributes;
using Signal.Core.Buildings.Application;
using Signal.Core.Buildings.Presentation;
using UnityEngine;

namespace Signal.Core.Buildings
{
    public class BuildingBootstrap : MonoBehaviour
    {
        [SerializeField] private Transform _radarSpawnpoint;
        [SerializeField] private BuildingDefinition _radar;

        [SerializeField] private BuildingPanelPresenter _buildingPanel;

        private BuildingPlacement _buildingPlacement;
        private BuildingGridSnapper _gridSnapper;

        [Inject]
        internal void Inject(BuildingPlacement buildingPlacement, BuildingGridSnapper gridSnapper)
        {
            _buildingPlacement = buildingPlacement;
            _gridSnapper = gridSnapper;
        }

        public void Initialize()
        {
            _buildingPanel.Initialize();

            var gridPosition = _gridSnapper.ToGridPosition(_radarSpawnpoint.position);
            _buildingPlacement.PlaceBuilding(gridPosition, _radar.Id);
        }
    }
}
