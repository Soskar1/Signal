using Signal.Core.Economy.Domain;
using Signal.Core.Economy.Infrastructure;

namespace Signal.Core.Economy.Application
{
    internal static class ResourceFactory
    {
        public static Resource Create(ResourceDefinition definition)
        {
            return new Resource(definition.Id);
        }
    }
}
