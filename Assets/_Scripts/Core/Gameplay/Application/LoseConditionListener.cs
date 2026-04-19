using Signal.Core.Buildings;
using Signal.Core.Gameplay.Presentation;
using System;

namespace Signal.Core.Gameplay.Application
{
    internal class LoseConditionListener : IDisposable
    {
        private readonly BuildingId _targetBuilding;
        private readonly IBuildingObserver _buildingObserver;
        private readonly EnemyAi _enemyAi;
        private readonly Timer _timer;
        private readonly GameOverScreen _gameOverScreen;

        public LoseConditionListener(BuildingId targetBuilding, IBuildingObserver buildingObserver, EnemyAi enemyAi, Timer timer, GameOverScreen gameOverScreen)
        {
            _targetBuilding = targetBuilding;
            _buildingObserver = buildingObserver;
            _enemyAi = enemyAi;
            _timer = timer;
            _gameOverScreen = gameOverScreen;

            _buildingObserver.BuildingDestroyed += HandleBuildingDestroyed;
        }

        private void HandleBuildingDestroyed(object _, BuildingDestroyedEventArgs args)
        {
            var buildingInfo = args.BuildingInfo;

            if (buildingInfo.BuildingId.Id == _targetBuilding.Id)
            {
                _enemyAi.Disable();
                _timer.Stop();
                _gameOverScreen.Display();
            }
        }

        public void Dispose()
        {
            _buildingObserver.BuildingDestroyed -= HandleBuildingDestroyed;
        }
    }
}
