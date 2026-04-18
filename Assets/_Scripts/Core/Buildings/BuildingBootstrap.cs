using Reflex.Attributes;
using Signal.Core.Buildings.Presentation;
using UnityEngine;

namespace Signal.Core.Buildings
{
    public class BuildingBootstrap : MonoBehaviour
    {
        [SerializeField] private Transform _radarSpawnpoint;
        [SerializeField] private BuildingId _radarId;

        [SerializeField] private BuildingPanelPresenter _buildingPanel;

        private IBuildingPlacement _buildingPlacement;

        [Inject]
        public void Inject(IBuildingPlacement buildingPlacement)
        {
            _buildingPlacement = buildingPlacement;
        }

        public void Initialize()
        {
            _buildingPanel.Initialize();
            _buildingPlacement.PlaceBuilding(_radarSpawnpoint, _radarId);
        }
    }
}
