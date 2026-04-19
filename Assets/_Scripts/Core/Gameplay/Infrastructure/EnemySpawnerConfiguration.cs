using System.Collections.Generic;
using UnityEngine;
using EntityId = Signal.Core.Entities.EntityId;

namespace Signal.Core.Gameplay.Infrastructure
{
    [CreateAssetMenu(fileName = "EnemySpawnerConfiguration", menuName = "Signal/Gameplay/Enemy Spawner Configuration")]
    internal class EnemySpawnerConfiguration : ScriptableObject
    {
        [SerializeField] private int _spawnInterval;
        [SerializeField] private List<EntityId> _entities;

        public int SpawnInterval => _spawnInterval;
        public List<EntityId> Entities => _entities;
    }
}
