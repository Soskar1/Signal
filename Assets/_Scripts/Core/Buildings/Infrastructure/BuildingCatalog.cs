using System.Collections.Generic;
using System.Linq;

namespace Signal.Core.Buildings.Infrastructure
{
    internal class BuildingCatalog : IBuildingCatalog
    {
        private readonly Dictionary<string, BuildingDefinition> _buildingData;

        public BuildingCatalog(IEnumerable<BuildingDefinition> buildingDefinitions)
        {
            _buildingData = buildingDefinitions.ToDictionary(definition => definition.Id, definition => definition);
        }

        public BuildingDefinition Get(BuildingId buildingId) => _buildingData[buildingId.Id];
    }
}
