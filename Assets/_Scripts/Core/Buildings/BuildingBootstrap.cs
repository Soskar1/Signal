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

        [Inject]
        internal void Inject(BuildingPlacement buildingPlacement)
        {
            _buildingPlacement = buildingPlacement;
        }

        public void Initialize()
        {
            _buildingPanel.Initialize();
            _buildingPlacement.PlaceBuilding(_radarSpawnpoint.position, _radar.Id);
        }
    }
}
