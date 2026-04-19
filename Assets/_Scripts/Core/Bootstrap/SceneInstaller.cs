using Reflex.Core;
using Signal.Core.Buildings;
using Signal.Core.Economy;
using Signal.Core.Entities;
using Signal.Core.Gameplay;
using Signal.Core.Player;
using Signal.Core.World;
using UnityEngine;

namespace Signal.Core
{
    public class SceneInstaller : MonoBehaviour, IInstaller
    {
        [SerializeField] private EconomyInstaller _economyInstaller;
        [SerializeField] private BuildingsInstaller _buildingInstaller;
        [SerializeField] private EntityInstaller _entityInstaller;
        [SerializeField] private GameplayInstaller _gameplayInstaller;

        public void InstallBindings(ContainerBuilder containerBuilder)
        {
            containerBuilder
                .InstallPlayer()
                .InstallWorld();

            _entityInstaller.Install(containerBuilder);
            _economyInstaller.Install(containerBuilder);
            _buildingInstaller.Install(containerBuilder);
            _gameplayInstaller.Install(containerBuilder);
        }
    }
}