using System.Collections.Generic;
using System.Linq;

namespace Signal.Core.Entities.Infrastructure
{
    internal class EntityDefinitionCatalog
    {
        private readonly Dictionary<string, EntityDefinition> _entities;

        public IEnumerable<EntityDefinition> Entities => _entities.Values;

        public EntityDefinitionCatalog(IEnumerable<EntityDefinition> buildingDefinitions)
        {
            _entities = buildingDefinitions.ToDictionary(definition => definition.Id, definition => definition);
        }

        public EntityDefinition Get(string id) => _entities[id];
    }
}
