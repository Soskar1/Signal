using System;

namespace Signal.Core.Economy.Domain
{
    internal class ResourceChangedEventArgs : EventArgs
    {
        public string ResourceName { get; }
        public int Count { get; }

        public ResourceChangedEventArgs(string resourceName, int count)
        {
            ResourceName = resourceName;
            Count = count;
        }
    }
}
