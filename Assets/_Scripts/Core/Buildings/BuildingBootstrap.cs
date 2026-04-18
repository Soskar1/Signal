using Reflex.Attributes;
using UnityEngine;

namespace Signal.Core.Buildings
{
    public class BuildingBootstrap : MonoBehaviour
    {
        [SerializeField] private Transform _radarSpawnpoint;
        [SerializeField] private BuildingId _radarId;

        private IBuildingPlacement _buildingPlacement;

        [Inject]
        public void Inject(IBuildingPlacement buildingPlacement)
        {
            _buildingPlacement = buildingPlacement;
        }

        public void Initialize()
        {
            _buildingPlacement.PlaceBuilding(_radarSpawnpoint, _radarId);
        }
    }
}
