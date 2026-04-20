using Signal.Core.Economy.Infrastructure;
using System;

namespace Signal.Core.Economy.Application
{
    internal class ResourceWallet : IResourceWallet, IResourceObserver
    {
        private readonly ResourceCatalog _resourceCatalog;

        public event EventHandler<ResourceChangedEventArgs> ResourceChanged;

        public ResourceWallet(ResourceCatalog resourceCatalog)
        {
            _resourceCatalog = resourceCatalog;
        }

        public void Add(ResourceId resourceId, int amount)
        {
            var resource = _resourceCatalog.Get(resourceId);
            resource.Add(amount);

            var args = new ResourceChangedEventArgs(resourceId.Id, resource.Count);
            ResourceChanged?.Invoke(this, args);
        }

        public bool TryWithdraw(ResourceId resourceId, int amount)
        {
            var resource = _resourceCatalog.Get(resourceId);
            var result = resource.TryWithdraw(amount);

            if (result)
            {
                var args = new ResourceChangedEventArgs(resourceId.Id, resource.Count);
                ResourceChanged?.Invoke(this, args);
            }

            return result;
        }
    }
}
