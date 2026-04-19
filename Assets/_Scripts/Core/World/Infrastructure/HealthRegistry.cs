using Signal.Core.World.Domain;
using System;
using System.Collections.Generic;

namespace Signal.Core.World.Infrastructure
{
    internal sealed class HealthRegistry
    {
        private readonly Dictionary<HealthOwnerId, Health> _healths = new();

        public Health Register(HealthOwnerId ownerId, int maxHealth)
        {
            if (_healths.ContainsKey(ownerId))
                throw new InvalidOperationException($"Health for owner '{ownerId}' is already registered.");

            var health = new Health(maxHealth);
            _healths.Add(ownerId, health);
            
            return health;
        }

        public void Unregister(HealthOwnerId ownerId)
        {
            _healths.Remove(ownerId);
        }

        public bool TryGet(HealthOwnerId ownerId, out Health health)
        {
            if (_healths.TryGetValue(ownerId, out health))
            {
                return true;
            }

            return false;
        }
    }
}
