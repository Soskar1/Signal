using Reflex.Core;
using Signal.Core.Economy;
using UnityEngine;

namespace Signal.Core
{
    public class SceneInstaller : MonoBehaviour, IInstaller
    {
        [SerializeField] private EconomyInstaller _economyInstaller;

        public void InstallBindings(ContainerBuilder containerBuilder)
        {
            _economyInstaller.Install(containerBuilder);
        }
    }
}