using Signal.Core.Gameplay.Domain;
using Signal.Core.Gameplay.Presentation;
using System;

namespace Signal.Core.Gameplay.Application
{
    internal class WinConditionListener : IDisposable
    {
        private readonly GameplayTime _time;
        private readonly Timer _timer;
        private readonly EnemyAi _enemyAi;
        private readonly int _winConditionTime;
        private readonly YouWonScreen _youWonScreen;
        private readonly EnemySpawnerPresenter _enemySpawnerPresenter;

        public WinConditionListener(GameplayTime time, Timer timer, int winConditionTimeInMinutes, EnemyAi enemyAi, YouWonScreen youWonScreen, EnemySpawnerPresenter enemySpawnerPresenter)
        {
            _time = time;
            _timer = timer;
            _winConditionTime = winConditionTimeInMinutes;
            _enemyAi = enemyAi;
            _youWonScreen = youWonScreen;
            _enemySpawnerPresenter = enemySpawnerPresenter;

            _time.GameplayTimeChanged += HandleGameplayTimeChanged;
        }

        public void Dispose()
        {
            _time.GameplayTimeChanged -= HandleGameplayTimeChanged;
        }

        private void HandleGameplayTimeChanged(object _, GameplayTimeChangedEventArgs args)
        {
            if (args.Minutes >= _winConditionTime)
            {
                _enemyAi.Disable();
                _youWonScreen.gameObject.SetActive(true);
                _timer.Stop();
                _enemySpawnerPresenter.enabled = false;
            }
        }
    }
}
