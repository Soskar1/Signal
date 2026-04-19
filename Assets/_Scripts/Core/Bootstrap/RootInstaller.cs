using Reflex.Core;
using Reflex.Enums;
using UnityEngine;
using Resolution = Reflex.Enums.Resolution;

namespace Signal.Core.Bootstrap
{
    internal class RootInstaller : MonoBehaviour, IInstaller
    {
        [SerializeField] private int _mainMenuSceneBuildIndex;
        [SerializeField] private int _gameSceneBuildIndex;

        public void InstallBindings(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterFactory(container =>
                    new Signal(
                        _mainMenuSceneBuildIndex,
                        _gameSceneBuildIndex),
                Lifetime.Singleton, Resolution.Lazy);
        }
    }
}
