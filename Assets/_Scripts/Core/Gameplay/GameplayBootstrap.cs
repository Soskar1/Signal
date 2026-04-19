using Signal.Core.Gameplay.Infrastructure;
using Signal.Core.Gameplay.Presentation;
using UnityEngine;

namespace Signal.Core.Gameplay
{
    public class GameplayBootstrap : MonoBehaviour
    {
        [SerializeField] private EnemySpawnerConfiguration _initialSpawnerConfiguration;
        [SerializeField] private EnemySpawner _enemySpawner;
        [SerializeField] private EnemyAi _ai;

        public void Initialize()
        {
            _enemySpawner.Configure(_initialSpawnerConfiguration);
            _ai.Initialize();
        }
    }
}
