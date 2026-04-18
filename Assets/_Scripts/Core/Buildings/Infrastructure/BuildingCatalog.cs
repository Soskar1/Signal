using System.Collections.Generic;

namespace Signal.Core.Buildings.Infrastructure
{
    internal class BuildingCatalog : IBuildingCatalog
    {
        private readonly IReadOnlyList<BuildingData> _buildingData;

        public BuildingCatalog(IReadOnlyList<BuildingData> buildingData)
        {
            _buildingData = buildingData;
        }

        public IEnumerable<BuildingViewData> GetBuildingViewData()
        {
            foreach (var data in _buildingData)
            {
                yield return new BuildingViewData(data.Name, data.Description, data.Sprite);
            }
        }
    }
}
