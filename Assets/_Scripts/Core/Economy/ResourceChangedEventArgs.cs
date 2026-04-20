using System;

namespace Signal.Core.Economy
{
    public class ResourceChangedEventArgs : EventArgs
    {
        public string ResourceName { get; }
        public int CurrentCount { get; }

        public ResourceChangedEventArgs(string resourceName, int count)
        {
            ResourceName = resourceName;
            CurrentCount = count;
        }
    }
}
