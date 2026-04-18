using Reflex.Attributes;
using Signal.Core.Buildings.Application;
using Signal.Core.Buildings.Domain;
using Signal.Core.Player;
using UnityEngine;

namespace Signal.Core.Buildings.Presentation
{
    internal class BuildModePresenter : MonoBehaviour
    {
        [SerializeField] private GhostBuildingPresenter _ghostBuilding;

        private BuildingPlacement _buildingPlacement;

        private IInputReader _inputReader;
        private bool _readMouseInput = false;

        private BuildingDefinition _currentBuilding;
        private GridPosition _currentBuildingPosition;

        [Inject]
        public void Inject(IInputReader inputReader, BuildingPlacement buildingPlacement)
        {
            _inputReader = inputReader;
            _buildingPlacement = buildingPlacement;
        }

        public void Update()
        {
            if (!_readMouseInput)
            {
                return;
            }

            var screenMousePosition = _inputReader.MousePosition;
            var mouseWorldPosition = Camera.main.ScreenToWorldPoint(screenMousePosition);
            _currentBuildingPosition = _buildingPlacement.GetGridPosition(mouseWorldPosition);

            var snappedPosition = _buildingPlacement.GetSnappedWorldPosition(_currentBuildingPosition);
            _ghostBuilding.transform.position = new Vector2(snappedPosition.x, snappedPosition.y);

            _ghostBuilding.DisplayAsValid();
            
            var canPlace = _buildingPlacement.CanPlace(_currentBuildingPosition);
            if (!canPlace)
            {
                _ghostBuilding.DisplayAsInvalid();
            }

            if (_inputReader.IsBuildButtonPressed && canPlace)
            {
                Build();
                ExitBuildMode();
            }
        }

        public void EnterBuildMode(BuildingDefinition buildingDefinition)
        {
            _ghostBuilding.Display(buildingDefinition.Sprite);
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
            _buildingPlacement.PlaceBuilding(_currentBuildingPosition, _currentBuilding.Id);
            _currentBuilding = null;
        }
    }
}
