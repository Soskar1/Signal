using Signal.Core.Buildings;
using Signal.Core.Entities;
using Signal.Core.World;
using UnityEngine;

namespace Signal.Core.Gameplay.Application
{
    internal class EnemyStateMachine
    {
        private readonly EntityInfo _entity;
        private double _elapsedTime;

        private readonly IEntityMovement _entityMovement;
        private readonly IHealthApi _healthApi;
        private readonly IBuildingQuery _buildingQuery;

        private readonly BuildingInfo _primaryTarget;
        private BuildingInfo _currentTarget;

        public EnemyStateMachine(
            EntityInfo entityInfo,
            BuildingInfo target,
            IEntityMovement movement,
            IHealthApi healthApi,
            IBuildingQuery buildingQuery)
        {
            _entity = entityInfo;
            _primaryTarget = target;
            _entityMovement = movement;
            _healthApi = healthApi;
            _buildingQuery = buildingQuery;

            _currentTarget = _primaryTarget;
        }

        public void Tick(float deltaTime)
        {
            var currentEnemyPosition = _entityMovement.GetPosition(_entity.InstanceId);

            if (Vector2.Distance(currentEnemyPosition, _currentTarget.WorldPosition) > _entity.AttackDistance)
            {
                _elapsedTime = 0;

                Vector2 direction = (_currentTarget.WorldPosition - currentEnemyPosition).normalized;
                Vector2 pointInFront = currentEnemyPosition + direction * _entity.AttackDistance;

                var buildingInfo = _buildingQuery.GetBuildingAt(pointInFront);

                if (buildingInfo != null)
                {
                    _currentTarget = buildingInfo;
                }

                _entityMovement.MoveTowards(_entity.InstanceId, _currentTarget.WorldPosition, deltaTime);
            }
            else
            {
                _elapsedTime += deltaTime;

                if (_elapsedTime < _entity.AttackSpeed)
                {
                    return;
                }

                _healthApi.TryApplyDamage(_currentTarget.HealthOwnerId, _entity.AttackDamage);
                
                _elapsedTime = 0;
                _currentTarget = _primaryTarget;
            }
        }
    }
}
