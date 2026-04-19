using Signal.Core.Buildings;
using Signal.Core.Entities;
using Signal.Core.World;
using UnityEngine;

namespace Signal.Core.Gameplay.Application
{
    internal class EnemyStateMachine
    {
        private readonly EntityInstanceId _entity;
        private readonly float _attackInterval;
        private readonly int _attackDamage;
        private double _elapsedTime;

        private readonly IEntityMovement _entityMovement;
        private readonly IHealthApi _healthApi;

        private readonly BuildingInfo _target;

        public EnemyStateMachine(
            EntityInstanceId instanceId,
            BuildingInfo target,
            int attackDamage,
            float attackInterval,
            IEntityMovement movement,
            IHealthApi healthApi)
        {
            _entity = instanceId;
            _attackInterval = attackInterval;
            _attackDamage = attackDamage;
            _target = target;
            _entityMovement = movement;
            _healthApi = healthApi;
        }

        public void Tick(float deltaTime)
        {
            var currentEnemyPosition = _entityMovement.GetPosition(_entity);

            if (Vector2.Distance(currentEnemyPosition, _target.WorldPosition) > 1f)
            {
                _elapsedTime = 0;
                _entityMovement.MoveTowards(_entity, _target.WorldPosition, deltaTime);
            }
            else
            {
                _elapsedTime += deltaTime;

                if (_elapsedTime < _attackInterval)
                {
                    return;
                }

                bool isDamageApplied = _healthApi.TryApplyDamage(_target.HealthOwnerId, _attackDamage);

                if (!isDamageApplied)
                {
                    Debug.LogError("Damage is not applied!");
                }

                _elapsedTime = 0;
            }
        }
    }
}
