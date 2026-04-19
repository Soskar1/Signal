using System;

namespace Signal.Core.World
{
    public class HealthChangedEventArgs : EventArgs
    {
        public HealthOwnerId OwnerId { get; }
        public int Current { get; }
        public int Max { get; }
        public bool IsDead { get; }

        public HealthChangedEventArgs(HealthOwnerId ownerId, int current, int max, bool isDead)
        {
            OwnerId = ownerId;
            Current = current;
            Max = max;
            IsDead = isDead;
        }
    }
}
