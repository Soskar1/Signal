using System;

namespace Signal.Core.World
{
    public interface IHealthApi
    {
        event EventHandler<HealthChangedEventArgs> HealthChanged;

        HealthOwnerId Register(int maxHealth);
        void Unregister(HealthOwnerId ownerId);

        int GetCurrent(HealthOwnerId ownerId);
        int GetMax(HealthOwnerId ownerId);
        bool IsDead(HealthOwnerId ownerId);

        bool TryApplyDamage(HealthOwnerId ownerId, int amount);
    }
}
