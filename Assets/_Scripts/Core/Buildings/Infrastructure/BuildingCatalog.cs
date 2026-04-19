using System.Collections.Generic;
using System.Linq;

namespace Signal.Core.Buildings.Infrastructure
{
    internal class BuildingCatalog
    {
        private readonly Dictionary<string, BuildingDefinition> _buildingData;

        public IEnumerable<BuildingDefinition> Buildings => _buildingData.Values;

        public BuildingCatalog(IEnumerable<BuildingDefinition> buildingDefinitions)
        {
            _buildingData = buildingDefinitions.ToDictionary(definition => definition.Id.Id, definition => definition);
        }

        public BuildingDefinition Get(string id) => _buildingData[id];
    }
}
