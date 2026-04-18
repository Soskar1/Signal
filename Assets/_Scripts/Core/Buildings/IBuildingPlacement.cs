using UnityEngine;

namespace Signal.Core.Buildings
{
    public interface IBuildingPlacement
    {
        public void PlaceBuilding(Vector3 worldPosition, BuildingId buildingId);
    }
}
