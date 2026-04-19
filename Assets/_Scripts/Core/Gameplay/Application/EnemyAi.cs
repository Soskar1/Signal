using Signal.Core.Buildings;
using Signal.Core.Entities;
using Signal.Core.World;
using System;
using System.Collections.Generic;

namespace Signal.Core.Gameplay.Application
{
    internal class EnemyAi : IDisposable
    {
        private BuildingInfo _target;
        private Dictionary<EntityInstanceId, EnemyStateMachine> _enemies = new();

        private readonly IEntityMovement _entityMovement;
        private readonly IBuildingQuery _buildingQuery;
        private readonly IEntityQuery _entityQuery;
        private readonly IHealthApi _healthApi;
        private readonly IEntityObserver _entityObserver;

        private bool _enabled = true;

        public EnemyAi(IEntityMovement entityMovement, IBuildingQuery buildingQuery, IEntityQuery entityQuery, IHealthApi healthApi, IEntityObserver entityObserver)
        {
            _entityMovement = entityMovement;
            _buildingQuery = buildingQuery;
            _entityQuery = entityQuery;
            _healthApi = healthApi;
            _entityObserver = entityObserver;

            _entityObserver.EntityDied += HandleEntityDied;
        }

        private void HandleEntityDied(object _, EntityDiedEventArgs args)
        {
            UnregisterEnemy(args.EntityInfo.InstanceId);
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
            _enemies.Add(enemyInstanceId, stateMachine);
        }

        public void UnregisterEnemy(EntityInstanceId enemyInstanceId)
        {
            _enemies.Remove(enemyInstanceId);
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

            foreach (var enemy in _enemies.Values)
            {
                enemy.Tick(deltaTime);
            }
        }

        public void Dispose()
        {
            _entityObserver.EntityDied -= HandleEntityDied;
        }
    }
}
