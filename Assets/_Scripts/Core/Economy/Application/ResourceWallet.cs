using Signal.Core.Economy.Infrastructure;

namespace Signal.Core.Economy.Application
{
    internal class ResourceWallet : IResourceWallet
    {
        private readonly ResourceCatalog _resourceCatalog;

        public ResourceWallet(ResourceCatalog resourceCatalog)
        {
            _resourceCatalog = resourceCatalog;
        }

        public void Add(ResourceId resourceId, int amount)
        {
            var resource = _resourceCatalog.Get(resourceId);
            resource.Add(amount);
        }

        public bool TryWithdraw(ResourceId resourceId, int amount)
        {
            var resource = _resourceCatalog.Get(resourceId);
            return resource.TryWithdraw(amount);
        }
    }
}
