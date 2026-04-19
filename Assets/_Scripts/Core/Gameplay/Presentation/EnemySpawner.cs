using Reflex.Attributes;
using Signal.Core.Entities;
using Signal.Core.Gameplay.Application;
using Signal.Core.Gameplay.Infrastructure;
using UnityEngine;

namespace Signal.Core.Gameplay.Presentation
{
    internal class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private EnemyAi _enemyAi;
        [SerializeField] private float _outOfScreenSpawnMargin = 1.0f;

        private IEntitySpawner _entitySpawner;

        private EnemySpawnerConfiguration _currentConfiguration;
        private double _elapsedTime;

        [Inject]
        public void Inject(IEntitySpawner entitySpawner)
        {
            _entitySpawner = entitySpawner;
        }

        public void Configure(EnemySpawnerConfiguration configuration)
        {
            _currentConfiguration = configuration;
            _elapsedTime = 0;
        }

        public void Update()
        {
            if (_currentConfiguration == null)
            {
                return;
            }

            _elapsedTime += Time.deltaTime;

            if (_elapsedTime < _currentConfiguration.SpawnInterval)
            {
                return;
            }

            _elapsedTime = 0;
            Spawn();
        }

        private void Spawn()
        {
            var idRaw = Random.Range(0, _currentConfiguration.Entities.Count);
            var idToSpawn = _currentConfiguration.Entities[idRaw];

            var position = OffscreenSpawnPositionGenerator.Generate(Camera.main, _outOfScreenSpawnMargin);

            var instanceId = _entitySpawner.Spawn(idToSpawn, position);
            _enemyAi.RegisterEnemy(instanceId);
        }
    }
}