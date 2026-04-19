using Signal.Core.Buildings;
using Signal.Core.Economy;
using Signal.Core.Entities;
using Signal.Core.Gameplay;
using UnityEngine;

namespace Signal.Core.Bootstrap
{
    internal class SceneBootstrap : MonoBehaviour
    {
        [SerializeField] private EconomyBootstrap _economyBootstrap;
        [SerializeField] private BuildingBootstrap _buildingBootstrap;
        [SerializeField] private EntityBootstrap _entityBootstrap;
        [SerializeField] private GameplayBootstrap _gameplayBootstrap;

        public void Start()
        {
            _economyBootstrap.Initialize();
            _buildingBootstrap.Initialize();
            _entityBootstrap.Initialize();
            _gameplayBootstrap.Initialize();
        }
    }
}
