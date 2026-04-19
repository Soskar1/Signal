using Signal.Core.World.Domain;
using Signal.Core.World.Infrastructure;
using System;
using UnityEngine;

namespace Signal.Core.World.Application
{
    internal sealed class HealthApi : IHealthApi
    {
        private readonly HealthRegistry _registry;

        public event EventHandler<HealthChangedEventArgs> HealthChanged;

        public HealthApi(HealthRegistry registry)
        {
            _registry = registry;
        }

        public HealthOwnerId Register(int maxHealth)
        {
            var id = Guid.NewGuid();
            var ownerId = new HealthOwnerId(id);

            var health = _registry.Register(ownerId, maxHealth);
            RaiseHealthChanged(ownerId, health);

            return ownerId;
        }

        public void Unregister(HealthOwnerId ownerId) => _registry.Unregister(ownerId);
        
        public int GetCurrent(HealthOwnerId ownerId)
        {
            var foundHealth = _registry.TryGet(ownerId, out var health);

            if (!foundHealth)
            {
                Debug.LogWarning($"Health with ID {ownerId.Id} was not found!");
                return 0;
            }

            return health.Current;
        }

        public int GetMax(HealthOwnerId ownerId)
        {
            var foundHealth = _registry.TryGet(ownerId, out var health);

            if (!foundHealth)
            {
                Debug.LogWarning($"Health with ID {ownerId.Id} was not found!");
                return 0;
            }

            return health.Max;
        }

        public bool IsDead(HealthOwnerId ownerId)
        {
            var foundHealth = _registry.TryGet(ownerId, out var health);

            if (!foundHealth)
            {
                Debug.LogWarning($"Health with ID {ownerId.Id} was not found!");
                return true;
            }

            return health.IsDead;
        }

        public bool TryApplyDamage(HealthOwnerId ownerId, int amount)
        {
            var foundHealth = _registry.TryGet(ownerId, out var health);
            
            if (!foundHealth)
            {
                return false;
            }

            var isDamageApplied = health.TryApplyDamage(amount);

            if (isDamageApplied)
            {
                RaiseHealthChanged(ownerId, health);
            }

            return isDamageApplied;
        }

        private void RaiseHealthChanged(HealthOwnerId ownerId, Health health)
        {
            var args = new HealthChangedEventArgs(ownerId, health.Current, health.Max, health.IsDead);
            HealthChanged?.Invoke(this, args);
        }
    }
}
