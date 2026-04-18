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

        private BuildingGridSnapper _gridSnapper;
        private BuildingPlacement _buildingPlacement;
        private GridOccupancy _gridOccupancy;

        private IInputReader _inputReader;
        private bool _readMouseInput = false;

        private BuildingDefinition _currentBuilding;
        private GridPosition _currentBuildingPosition;

        [Inject]
        public void Inject(IInputReader inputReader, BuildingGridSnapper buildingGridSnapper, BuildingPlacement buildingPlacement, GridOccupancy gridOccupancy)
        {
            _inputReader = inputReader;
            _gridSnapper = buildingGridSnapper;
            _buildingPlacement = buildingPlacement;
            _gridOccupancy = gridOccupancy;
        }

        public void Update()
        {
            if (!_readMouseInput)
            {
                return;
            }

            var screenMousePosition = _inputReader.MousePosition;
            var mouseWorldPosition = Camera.main.ScreenToWorldPoint(screenMousePosition);
            _currentBuildingPosition = _gridSnapper.ToGridPosition(mouseWorldPosition);

            var snappedPosition = _gridSnapper.ToWorldPosition(_currentBuildingPosition);
            _ghostBuilding.transform.position = new Vector2(snappedPosition.x, snappedPosition.y);

            _ghostBuilding.DisplayAsValid();
            
            var isTileOccupied = _gridOccupancy.IsOccupied(_currentBuildingPosition);
            if (isTileOccupied)
            {
                _ghostBuilding.DisplayAsInvalid();
            }

            if (_inputReader.IsBuildButtonPressed && !isTileOccupied)
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
