using System.Collections.Generic;
using UnityEngine;

namespace Signal.Core.Buildings
{
    public interface IBuildingQuery
    {
        public BuildingInfo GetBuildingAt(Vector2 worldPosition);
        public IEnumerable<BuildingInfo> GetBuildingInfo(BuildingId buildingId);
    }
}
