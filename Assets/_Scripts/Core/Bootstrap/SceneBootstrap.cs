using Signal.Core.Economy;
using UnityEngine;

namespace Signal.Core.Bootstrap
{
    internal class SceneBootstrap : MonoBehaviour
    {
        [SerializeField] private EconomyBootstrap _economyBootstrap;

        public void Start()
        {
            _economyBootstrap.Initialize();
        }
    }
}
