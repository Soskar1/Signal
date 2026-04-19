using System;

namespace Signal.Core.World.Domain
{
    internal class Health
    {
        public int Current { get; private set; }
        public int Max { get; }

        public bool IsDead => Current <= 0;

        public Health(int max)
        {
            if (max <= 0)
                throw new ArgumentOutOfRangeException(nameof(max));

            Max = max;
            Current = max;
        }

        public bool TryApplyDamage(int amount)
        {
            if (amount < 0)
                throw new ArgumentOutOfRangeException(nameof(amount));

            if (IsDead)
                return false;

            Current = Math.Max(0, Current - amount);
            return true;
        }
    }
}