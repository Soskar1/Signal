using Reflex.Attributes;
using Signal.Core.Buildings;
using Signal.Core.Economy;
using Signal.Core.Gameplay.Application;
using Signal.Core.Gameplay.Infrastructure;
using System.Linq;
using UnityEngine;

namespace Signal.Core.Gameplay
{
    public class GameplayBootstrap : MonoBehaviour
    {
        [SerializeField] private StartingResourcesConfiguration _startingResourceConfiguration;
        [SerializeField] private BuildingId _targetBuildingId;

        private EnemyAi _enemyAi;
        private IBuildingQuery _buildingQuery;
        private IResourceWallet _resourceWallet;
        private LoseConditionListener _loseConditionListener;
        private WinConditionListener _winConditionListener;

        [Inject]
        internal void Inject(EnemyAi ai, IBuildingQuery buildingQuery, IResourceWallet resourceWallet, LoseConditionListener loseConditionListener, WinConditionListener winConditionListener)
        {
            _enemyAi = ai;
            _buildingQuery = buildingQuery;
            _resourceWallet = resourceWallet;
            _loseConditionListener = loseConditionListener;
            _winConditionListener = winConditionListener;
        }

        public void Initialize()
        {
            foreach (var startingResource in _startingResourceConfiguration.StartingResources)
            {
                _resourceWallet.Add(startingResource.ResourceId, startingResource.Amount);
            }

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
            _enemyAi.Dispose();
            _winConditionListener.Dispose();
        }
    }
}
