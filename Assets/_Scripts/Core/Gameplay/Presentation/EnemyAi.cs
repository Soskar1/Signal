using Reflex.Attributes;
using Signal.Core.Buildings;
using Signal.Core.Entities;
using Signal.Core.Gameplay.Application;
using Signal.Core.World;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Signal.Core.Gameplay.Presentation
{
    internal class EnemyAi : MonoBehaviour
    {
        [SerializeField] private BuildingId _targetBuildingId;
        private BuildingInfo _target;

        private List<EnemyStateMachine> _enemies = new();
        private IEntityMovement _entityMovement;
        private IBuildingQuery _buildingQuery;
        private IEntityQuery _entityQuery;
        private IHealthApi _healthApi;

        [Inject]
        public void Inject(IEntityMovement entityMovement, IBuildingQuery buildingQuery, IEntityQuery entityQuery, IHealthApi healthApi)
        {
            _entityMovement = entityMovement;
            _buildingQuery = buildingQuery;
            _entityQuery = entityQuery;
            _healthApi = healthApi;
        }

        public void Initialize()
        {
            _target = _buildingQuery.GetBuildingInfo(_targetBuildingId).FirstOrDefault();

            if (_target == null)
            {
                throw new System.Exception("Did not found a target building!");
            }
        }

        public void RegisterEnemy(EntityInstanceId enemyInstanceId)
        {
            var attackDamage = _entityQuery.GetEntityAttackDamage(enemyInstanceId);
            var attackSpeed = _entityQuery.GetEntityAttackSpeed(enemyInstanceId);

            var stateMachine = new EnemyStateMachine(enemyInstanceId, _target, attackDamage, attackSpeed, _entityMovement, _healthApi);
            _enemies.Add(stateMachine);
        }

        public void Update()
        {
            if (_enemies.Count == 0)
                return;

            foreach (var enemy in _enemies)
            {
                enemy.Tick(Time.deltaTime);
            }
        }
    }
}
