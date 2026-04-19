using Signal.Core.World.Domain;
using System;
using System.Collections.Generic;

namespace Signal.Core.World.Infrastructure
{
    internal sealed class HealthRegistry
    {
        private readonly Dictionary<HealthOwnerId, Health> _states = new();

        public Health Register(HealthOwnerId ownerId, int maxHealth)
        {
            if (_states.ContainsKey(ownerId))
                throw new InvalidOperationException($"Health for owner '{ownerId}' is already registered.");

            var health = new Health(maxHealth);
            _states.Add(ownerId, health);
            
            return health;
        }

        public void Unregister(HealthOwnerId ownerId)
        {
            _states.Remove(ownerId);
        }

        public Health Get(HealthOwnerId ownerId)
        {
            if (!_states.TryGetValue(ownerId, out var state))
                throw new KeyNotFoundException($"Health for owner '{ownerId}' was not found.");

            return state;
        }
    }
}
