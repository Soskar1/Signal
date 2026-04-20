using Signal.Core.Economy.Application;
using Signal.Core.Economy.Domain;
using System.Collections.Generic;

namespace Signal.Core.Economy.Infrastructure
{
    internal class ResourceCatalog : IResourceQuery
    {
        private readonly Dictionary<string, ResourceEntry> _resources;
        private readonly Dictionary<string, ResourceDefinition> _resourceDefinitions;

        internal IEnumerable<ResourceEntry> Entries => _resources.Values;

        public ResourceCatalog(IEnumerable<ResourceDefinition> resourceDefinitions)
        {
            _resources = new Dictionary<string, ResourceEntry>();
            _resourceDefinitions = new Dictionary<string, ResourceDefinition>();

            foreach (var resourceDefinition in resourceDefinitions)
            {
                var resource = ResourceFactory.Create(resourceDefinition);
                var entry = new ResourceEntry(resource, resourceDefinition);

                _resources.Add(resource.Id, entry);
                _resourceDefinitions.Add(resource.Id, resourceDefinition);
            }
        }

        public Resource Get(ResourceId resourceId) => _resources[resourceId.Id].Resource;
        
        public ResourceInfo GetResourceInfo(ResourceId resourceId)
        {
            var definition = _resourceDefinitions[resourceId.Id];
            var resource = Get(resourceId);

            return new ResourceInfo(definition.Sprite, resource.Count);
        }
    }
}
