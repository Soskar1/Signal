using Reflex.Attributes;
using Signal.Core.Buildings.Application;
using Signal.Core.Buildings.Domain;
using Signal.Core.Player;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Signal.Core.Buildings.Presentation
{
    internal class BuildModePresenter : MonoBehaviour
    {
        [SerializeField] private GhostBuildingPresenter _ghostBuilding;

        private BuildingSpawner _buildingSpawner;

        private IInputReader _inputReader;
        private bool _readMouseInput = false;

        private BuildingDefinition _currentBuilding;
        private GridSnapper _gridSnapper;
        private GridPosition _currentBuildingPosition;

        [Inject]
        public void Inject(IInputReader inputReader, BuildingSpawner buildingSpawner, GridSnapper gridSnapper)
        {
            _inputReader = inputReader;
            _buildingSpawner = buildingSpawner;
            _gridSnapper = gridSnapper;
        }

        public void Update()
        {
            if (!_readMouseInput)
            {
                return;
            }

            var screenMousePosition = _inputReader.MousePosition;
            var mouseWorldPosition = Camera.main.ScreenToWorldPoint(screenMousePosition);
            _currentBuildingPosition = _gridSnapper.GetGridPosition(mouseWorldPosition);

            var snappedPosition = _gridSnapper.GetSnappedWorldPosition(_currentBuildingPosition);
            _ghostBuilding.transform.position = new Vector2(snappedPosition.x, snappedPosition.y);

            _ghostBuilding.DisplayAsValid();
            
            var canPlace = _buildingSpawner.CanPlace(_currentBuildingPosition);
            if (!canPlace)
            {
                _ghostBuilding.DisplayAsInvalid();
            }

            var mouseIsOverUi = EventSystem.current.IsPointerOverGameObject();
            if (_inputReader.IsBuildButtonPressed && canPlace && !mouseIsOverUi)
            {
                Build();
                ExitBuildMode();
            }
        }

        public void EnterBuildMode(BuildingDefinition buildingDefinition)
        {
            _ghostBuilding.Display(buildingDefinition.DisplaySprite);
            _currentBuilding = buildingDefinition;
            _readMouseInput = true;
        }

        private void ExitBuildMode()
        {
            _ghostBuilding.Hide();
            _readMouseInput = false;
        }

        private void Build()
        {
            _buildingSpawner.Spawn(_currentBuildingPosition, _currentBuilding.Id);
            _currentBuilding = null;
        }
    }
}
