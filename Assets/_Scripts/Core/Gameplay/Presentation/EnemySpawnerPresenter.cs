using Reflex.Attributes;
using Signal.Core.Entities;
using Signal.Core.Gameplay.Application;
using Signal.Core.Gameplay.Infrastructure;
using System.Collections.Generic;
using UnityEngine;

namespace Signal.Core.Gameplay.Presentation
{
    internal class EnemySpawnerPresenter : MonoBehaviour
    {
        [SerializeField] private List<EnemySpawnerConfiguration> _enemySpawnerConfigurations;
        [SerializeField] private float _outOfScreenSpawnMargin = 1.0f;
        [SerializeField] private float _lastLevelTime;
        [SerializeField] private float _firstLevelStartTime;

        private List<EnemySpawner> _enemySpawners;
        private List<float> _levelTimes;

        private IEntitySpawner _entitySpawner;
        private EnemyAi _enemyAi;

        private float _elapsedTime = 0;

        [Inject]
        public void Inject(IEntitySpawner entitySpawner, EnemyAi ai)
        {
            _entitySpawner = entitySpawner;
            _enemyAi = ai;
        }

        public void Start()
        {
            _enemySpawners = new List<EnemySpawner>();

            for (var index = 0; index < _enemySpawnerConfigurations.Count; ++index)
            {
                var configuration = _enemySpawnerConfigurations[index];
                var spawner = new EnemySpawner(_entitySpawner, _enemyAi, _outOfScreenSpawnMargin, configuration);
                _enemySpawners.Add(spawner);
            }

            GenerateLevelTimes();
        }

        private void Update()
        {
            float deltaTime = Time.deltaTime;
            _elapsedTime += deltaTime;

            int currentLevel = GetCurrentLevel(_elapsedTime);

            for (int i = 0; i <= currentLevel && i < _enemySpawners.Count; i++)
            {
                _enemySpawners[i].Tick(deltaTime);
            }
        }

        private int GetCurrentLevel(float elapsedTime)
        {
            if (_levelTimes == null || _levelTimes.Count == 0)
                return -1;

            int level = -1;

            for (int i = 0; i < _levelTimes.Count; i++)
            {
                if (elapsedTime >= _levelTimes[i])
                    level = i;
                else
                    break;
            }

            return level;
        }

        private void GenerateLevelTimes()
        {
            int count = _enemySpawnerConfigurations.Count;

            _levelTimes = new List<float>(count);

            if (count == 0)
                return;

            if (count == 1)
            {
                _levelTimes.Add(_firstLevelStartTime);
                return;
            }

            float step = (_lastLevelTime - _firstLevelStartTime) / (count - 1);

            for (int i = 0; i < count; i++)
            {
                float time = _firstLevelStartTime + step * i;
                _levelTimes.Add(time);
            }
        }
    }
}