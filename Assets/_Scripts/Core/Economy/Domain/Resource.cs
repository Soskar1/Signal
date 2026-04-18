using System;

namespace Signal.Core.Economy.Domain
{
    internal class Resource
    {
        public string Id { get; }

        private int _count;
        public int Count
        {
            get => _count;
            private set
            {
                _count = value;

                if (_count < 0)
                {
                    _count = 0;
                }

                var args = new ResourceChangedEventArgs(Id, _count);
                ResourceChanged?.Invoke(this, args);
            }
        }

        public event EventHandler<ResourceChangedEventArgs> ResourceChanged;

        public Resource(string id)
        {
            Id = id;
        }

        public void Add(int count) => Count += count;

        public bool TryWithdraw(int count)
        {
            if (Count >= count)
            {
                Count -= count;
                return true;
            }

            return false;
        }
    }
}