using Signal.Core.Entities;
using Signal.Core.Gameplay.Infrastructure;
using UnityEngine;

namespace Signal.Core.Gameplay.Application
{
    internal class EnemySpawner
    {
        private readonly IEntitySpawner _entitySpawner;
        private readonly EnemyAi _enemyAi;
        private readonly float _outOfScreenSpawnMargin;

        private readonly EnemySpawnerConfiguration _spawnerConfiguration;

        private double _elapsedTime;

        public EnemySpawner(IEntitySpawner entitySpawner, EnemyAi enemy, float outOfScreenSpawnMargin, EnemySpawnerConfiguration configuration)
        {
            _entitySpawner = entitySpawner;
            _enemyAi = enemy;
            _outOfScreenSpawnMargin = outOfScreenSpawnMargin;
            _spawnerConfiguration = configuration;
        }

        public void Tick(float deltaTime)
        {
            if (_spawnerConfiguration == null)
            {
                return;
            }

            _elapsedTime += Time.deltaTime;

            if (_elapsedTime < _spawnerConfiguration.SpawnInterval)
            {
                return;
            }

            _elapsedTime = 0;
            Spawn();
        }

        private void Spawn()
        {
            var idRaw = Random.Range(0, _spawnerConfiguration.Entities.Count);
            var idToSpawn = _spawnerConfiguration.Entities[idRaw];

            var position = OffscreenSpawnPositionGenerator.Generate(Camera.main, _outOfScreenSpawnMargin);

            var instanceId = _entitySpawner.Spawn(idToSpawn, position);
            _enemyAi.RegisterEnemy(instanceId);
        }
    }
}
