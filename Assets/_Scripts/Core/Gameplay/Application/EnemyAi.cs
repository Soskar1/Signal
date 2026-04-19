using Signal.Core.Buildings;
using Signal.Core.Entities;
using Signal.Core.World;
using System.Collections.Generic;

namespace Signal.Core.Gameplay.Application
{
    internal class EnemyAi
    {
        private BuildingInfo _target;
        private List<EnemyStateMachine> _enemies = new();

        private readonly IEntityMovement _entityMovement;
        private readonly IBuildingQuery _buildingQuery;
        private readonly IEntityQuery _entityQuery;
        private readonly IHealthApi _healthApi;

        private bool _enabled = true;

        public EnemyAi(IEntityMovement entityMovement, IBuildingQuery buildingQuery, IEntityQuery entityQuery, IHealthApi healthApi)
        {
            _entityMovement = entityMovement;
            _buildingQuery = buildingQuery;
            _entityQuery = entityQuery;
            _healthApi = healthApi;
        }

        public void SetTargetBuilding(BuildingInfo buildingInfo)
        {
            _target = buildingInfo;
        }

        public void Disable()
        {
            _enabled = false;
        }

        public void RegisterEnemy(EntityInstanceId enemyInstanceId)
        {
            var entityInfo = _entityQuery.GetEntityInfo(enemyInstanceId);

            var stateMachine = new EnemyStateMachine(entityInfo, _target, _entityMovement, _healthApi, _buildingQuery);
            _enemies.Add(stateMachine);
        }

        public void Tick(float deltaTime)
        {
            if (!_enabled)
            {
                return;
            }

            if (_enemies.Count == 0)
            {
                return;
            }

            foreach (var enemy in _enemies)
            {
                enemy.Tick(deltaTime);
            }
        }
    }
}
