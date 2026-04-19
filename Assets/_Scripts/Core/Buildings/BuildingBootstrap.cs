using Reflex.Attributes;
using Signal.Core.Buildings.Application;
using Signal.Core.Buildings.Presentation;
using UnityEngine;

namespace Signal.Core.Buildings
{
    public class BuildingBootstrap : MonoBehaviour
    {
        [SerializeField] private Vector2 _radarSpawnpoint;
        [SerializeField] private Vector2 _landingPadSpawnpoint;
        [SerializeField] private BuildingDefinition _radar;
        [SerializeField] private BuildingDefinition _landingPad;

        [SerializeField] private BuildingPanelPresenter _buildingPanel;

        private BuildingSpawner _buildingSpawner;
        private BuildingLifecycle _buildingLifecycle;

        [Inject]
        internal void Inject(BuildingSpawner BuildingSpawner, BuildingLifecycle buildingLifecycle)
        {
            _buildingSpawner = BuildingSpawner;
            _buildingLifecycle = buildingLifecycle;
        }

        public void Initialize()
        {
            _buildingPanel.Initialize();
            _buildingSpawner.Spawn(_radarSpawnpoint, _radar.Id);
            _buildingSpawner.Spawn(_landingPadSpawnpoint, _landingPad.Id);
        }

        public void OnDestroy()
        {
            _buildingLifecycle.Dispose();
        }
    }
}
