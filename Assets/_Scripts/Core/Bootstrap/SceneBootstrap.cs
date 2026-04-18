using Signal.Core.Buildings;
using Signal.Core.Economy;
using UnityEngine;

namespace Signal.Core.Bootstrap
{
    internal class SceneBootstrap : MonoBehaviour
    {
        [SerializeField] private EconomyBootstrap _economyBootstrap;
        [SerializeField] private BuildingBootstrap _buildingBootstrap;

        public void Start()
        {
            _economyBootstrap.Initialize();
            _buildingBootstrap.Initialize();
        }
    }
}
