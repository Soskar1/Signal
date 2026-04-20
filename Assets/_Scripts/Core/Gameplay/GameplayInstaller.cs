using Reflex.Core;
using Reflex.Enums;
using Signal.Core.Buildings;
using Signal.Core.Gameplay.Application;
using Signal.Core.Gameplay.Domain;
using Signal.Core.Gameplay.Presentation;
using UnityEngine;
using Resolution = Reflex.Enums.Resolution;

namespace Signal.Core.Gameplay
{
    public class GameplayInstaller : MonoBehaviour
    {
        [SerializeField] private BuildingId _targetBuildingId;
        [SerializeField] private GameOverScreen _gameOverScreen;
        [SerializeField] private int _winConditionTimeInMinutes;
        [SerializeField] private YouWonScreen _youWonScreen;
        [SerializeField] private EnemySpawnerPresenter _enemySpawnerPresenter;

        public void Install(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType(typeof(GameplayTime), Lifetime.Singleton, Resolution.Lazy);
            containerBuilder.RegisterFactory(container =>
                new Timer(
                    container.Resolve<GameplayTime>()),
                Lifetime.Singleton, Resolution.Lazy);

            containerBuilder.RegisterType(typeof(EnemyAi), Lifetime.Singleton, Resolution.Lazy);
            containerBuilder.RegisterFactory(container =>
                new LoseConditionListener(
                    _targetBuildingId,
                    container.Resolve<IBuildingObserver>(),
                    container.Resolve<EnemyAi>(),
                    container.Resolve<Timer>(),
                    _gameOverScreen),
                Lifetime.Singleton, Resolution.Lazy);

            containerBuilder.RegisterFactory(container =>
                new WinConditionListener(
                    container.Resolve<GameplayTime>(),
                    container.Resolve<Timer>(),
                    _winConditionTimeInMinutes,
                    container.Resolve<EnemyAi>(),
                    _youWonScreen,
                    _enemySpawnerPresenter),
                Lifetime.Singleton, Resolution.Lazy);
        }
    }
}
