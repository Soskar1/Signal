using Reflex.Core;
using Signal.Core.Buildings;
using Signal.Core.Economy;
using UnityEngine;

namespace Signal.Core
{
    public class SceneInstaller : MonoBehaviour, IInstaller
    {
        [SerializeField] private EconomyInstaller _economyInstaller;
        [SerializeField] private BuildingsInstaller _buildingInstaller;

        public void InstallBindings(ContainerBuilder containerBuilder)
        {
            _economyInstaller.Install(containerBuilder);
            _buildingInstaller.Install(containerBuilder);
        }
    }
}