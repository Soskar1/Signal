using Signal.Core.Buildings.Presentation;
using Signal.Core.Economy;
using Signal.Core.Entities;
using Signal.Core.World;
using UnityEngine;

namespace Signal.Core.Buildings.Domain
{
    internal class ShootAction : IBuildingAction
    {
        private readonly Projectile _projectilePrefab;
        private readonly ResourceId _resourceId;
        private readonly int _amount;
        private readonly float _cooldownInSeconds;

        private readonly IResourceWallet _resourceWallet;
        private readonly IHealthApi _healthApi;
        private readonly IEntityQuery _entityQuery;

        private readonly Vector2 _buildingWorldPosition;

        private double _elapsed;

        public ShootAction(ResourceId resourceId, Projectile projectilePrefab, int amount, float cooldownInSeconds, IResourceWallet resourceWallet, IHealthApi healthApi, IEntityQuery entityQuery, Vector2 buildingWorldPosition)
        {
            _resourceId = resourceId;
            _amount = amount;
            _cooldownInSeconds = cooldownInSeconds;
            _resourceWallet = resourceWallet;
            _projectilePrefab = projectilePrefab;
            _entityQuery = entityQuery;

            _healthApi = healthApi;
            _buildingWorldPosition = buildingWorldPosition;
        }

        public void Tick(double deltaTime)
        {
            _elapsed += deltaTime;

            if (_elapsed < _cooldownInSeconds)
                return;

            _elapsed = 0;
            Execute();
        }

        public void Execute()
        {
            var nearestEntity = _entityQuery.GetNearestEntity(_buildingWorldPosition);

            if (nearestEntity == null)
            {
                return;
            }

            var success = _resourceWallet.TryWithdraw(_resourceId, _amount);

            if (success)
            {
                var projectileInstance = GameObject.Instantiate(_projectilePrefab, _buildingWorldPosition, Quaternion.identity);
                projectileInstance.Initialize(nearestEntity.InstanceId, _entityQuery, _healthApi);
            }
        }
    }
}
