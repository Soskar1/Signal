using System;

namespace Signal.Core.World
{
    public readonly struct HealthOwnerId
    {
        public Guid Id { get; }

        internal HealthOwnerId(Guid id)
        {
            Id = id;
        }
    }
}
