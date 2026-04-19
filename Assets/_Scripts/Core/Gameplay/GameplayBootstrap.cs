using Reflex.Attributes;
using Signal.Core.Buildings;
using Signal.Core.Gameplay.Application;
using Signal.Core.Gameplay.Infrastructure;
using Signal.Core.Gameplay.Presentation;
using System.Linq;
using UnityEngine;

namespace Signal.Core.Gameplay
{
    public class GameplayBootstrap : MonoBehaviour
    {
        [SerializeField] private EnemySpawnerConfiguration _initialSpawnerConfiguration;
        [SerializeField] private EnemySpawner _enemySpawner;

        [SerializeField] private BuildingId _targetBuildingId;

        private EnemyAi _enemyAi;
        private IBuildingQuery _buildingQuery;
        private LoseConditionListener _loseConditionListener;

        [Inject]
        internal void Inject(EnemyAi ai, IBuildingQuery buildingQuery, LoseConditionListener loseConditionListener)
        {
            _enemyAi = ai;
            _buildingQuery = buildingQuery;
            _loseConditionListener = loseConditionListener;
        }

        public void Initialize()
        {
            _enemySpawner.Configure(_initialSpawnerConfiguration);

            var buildingInfo = _buildingQuery.GetBuildingInfo(_targetBuildingId).FirstOrDefault();

            if (buildingInfo == null)
            {
                throw new System.Exception("Did not found a target building!");
            }

            _enemyAi.SetTargetBuilding(buildingInfo);
        }

        public void OnDestroy()
        {
            _loseConditionListener.Dispose();
        }
    }
}
