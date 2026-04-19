using System;

namespace Signal.Core.World
{
    public readonly struct EntityInstanceId : IEquatable<EntityInstanceId>
    {
        public int Value { get; }
        public HealthOwnerId HealthOwnerId { get; }

        public EntityInstanceId(int value, HealthOwnerId healthOwnerId)
        {
            Value = value;
            HealthOwnerId = healthOwnerId;
        }

        public bool Equals(EntityInstanceId other) => Value == other.Value;
        public override bool Equals(object obj) => obj is EntityInstanceId other && Equals(other);
        public override int GetHashCode() => Value;
        public override string ToString() => Value.ToString();
    }
}
