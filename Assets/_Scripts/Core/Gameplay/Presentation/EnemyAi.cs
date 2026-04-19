using Reflex.Attributes;
using Signal.Core.Buildings;
using Signal.Core.Entities;
using Signal.Core.World;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Signal.Core.Gameplay.Presentation
{
    internal class EnemyAi : MonoBehaviour
    {
        [SerializeField] private BuildingId _targetBuildingId;
        private Vector2 _target;

        private List<EntityInstanceId> _enemies = new();
        private IEntityMovement _entityMovement;
        private IBuildingQuery _buildingQuery;

        [Inject]
        public void Inject(IEntityMovement entityMovement, IBuildingQuery buildingQuery)
        {
            _entityMovement = entityMovement;
            _buildingQuery = buildingQuery;
        }

        public void Initialize()
        {
            var targetBuilding = _buildingQuery.GetBuildingInfo(_targetBuildingId).FirstOrDefault();

            if (targetBuilding == null)
            {
                throw new System.Exception("Did not found a target building!");
            }

            _target = targetBuilding.WorldPosition;
        }

        public void RegisterEnemy(EntityInstanceId enemyInstanceId)
        {
            _enemies.Add(enemyInstanceId);
        }

        public void Update()
        {
            if (_enemies.Count == 0)
                return;

            foreach (var enemy in _enemies)
            {
                _entityMovement.MoveTowards(enemy, _target, Time.deltaTime);
            }
        }
    }
}
