using Reflex.Core;
using Signal.Core.Buildings;
using Signal.Core.Economy;
using Signal.Core.Player;
using UnityEngine;

namespace Signal.Core
{
    public class SceneInstaller : MonoBehaviour, IInstaller
    {
        [SerializeField] private EconomyInstaller _economyInstaller;
        [SerializeField] private BuildingsInstaller _buildingInstaller;
        [SerializeField] private PlayerInstaller _playerInstaller;

        public void InstallBindings(ContainerBuilder containerBuilder)
        {
            _playerInstaller.Install(containerBuilder);
            _economyInstaller.Install(containerBuilder);
            _buildingInstaller.Install(containerBuilder);
        }
    }
}