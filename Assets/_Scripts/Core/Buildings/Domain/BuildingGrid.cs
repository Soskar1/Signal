using UnityEngine;

namespace Signal.Core.Buildings.Domain
{
    internal class BuildingGrid
    {
        private readonly Vector3 _origin;
        private readonly float _cellSize;

        public BuildingGrid(Vector3 origin, float cellSize)
        {
            _origin = origin;
            _cellSize = cellSize;
        }

        public GridPosition WorldToGrid(Vector3 worldPosition)
        {
            var x = Mathf.RoundToInt((worldPosition.x - _origin.x) / _cellSize);
            var y = Mathf.RoundToInt((worldPosition.z - _origin.z) / _cellSize);

            return new GridPosition(x, y);
        }

        public Vector3 GridToWorld(GridPosition gridPosition)
        {
            return new Vector3(
                _origin.x + gridPosition.X * _cellSize,
                _origin.y,
                _origin.z + gridPosition.Y * _cellSize);
        }
    }
}
