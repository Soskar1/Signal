using Reflex.Attributes;
using Signal.Core.Entities;
using Signal.Core.World;
using System.Collections.Generic;
using UnityEngine;

namespace Signal.Core.Gameplay.Presentation
{
    internal class EnemyAi : MonoBehaviour
    {
        [SerializeField] private Vector2 _target;

        private List<EntityInstanceId> _enemies = new();
        private IEntityMovement _entityMovement;

        [Inject]
        public void Inject(IEntityMovement entityMovement)
        {
            _entityMovement = entityMovement;
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
