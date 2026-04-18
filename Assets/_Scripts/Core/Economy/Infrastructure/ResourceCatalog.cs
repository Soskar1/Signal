using Signal.Core.Economy.Application;
using Signal.Core.Economy.Domain;
using System.Collections.Generic;

namespace Signal.Core.Economy.Infrastructure
{
    internal class ResourceCatalog
    {
        private readonly Dictionary<string, ResourceEntry> _resources;

        internal IEnumerable<ResourceEntry> Entries => _resources.Values;

        public ResourceCatalog(IEnumerable<ResourceDefinition> resourceDefinitions)
        {
            _resources = new Dictionary<string, ResourceEntry>();

            foreach (var resourceDefinition in resourceDefinitions)
            {
                var resource = ResourceFactory.Create(resourceDefinition);
                var entry = new ResourceEntry(resource, resourceDefinition);

                _resources.Add(resource.Id, entry);
            }
        }

        public Resource Get(ResourceId resourceId) => _resources[resourceId.Id].Resource;
    }
}
