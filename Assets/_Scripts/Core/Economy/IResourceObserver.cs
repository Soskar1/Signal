using System;

namespace Signal.Core.Economy
{
    public interface IResourceObserver
    {
        public event EventHandler<ResourceChangedEventArgs> ResourceChanged; 
    }
}
