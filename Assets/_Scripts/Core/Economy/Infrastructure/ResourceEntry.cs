using Signal.Core.Economy.Domain;

namespace Signal.Core.Economy.Infrastructure
{
    internal struct ResourceEntry
    {
        public Resource Resource { get; }
        public ResourceDefinition ResourceDefinition { get; }
        public ResourceCategory Category => ResourceDefinition.Category;

        public ResourceEntry(Resource resource, ResourceDefinition resourceDefinition)
        {
            Resource = resource;
            ResourceDefinition = resourceDefinition;
        }
    }
}
