using UnityEngine;

namespace Signal.Core.Buildings
{
    public interface IBuildingPlacement
    {
        public void PlaceBuilding(Transform transform, BuildingId buildingId);
    }
}
