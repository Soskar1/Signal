using Signal.Core.Buildings.Domain;
using UnityEngine;

namespace Signal.Core.Buildings.Application
{
    internal class GridSnapper
    {
        private readonly BuildingGrid _grid;

        public GridSnapper(BuildingGrid grid)
        {
            _grid = grid;
        }

        public Vector3 GetSnappedWorldPosition(Vector3 worldPosition)
        {
            var gridPosition = GetGridPosition(worldPosition);
            return GetSnappedWorldPosition(gridPosition);
        }

        public GridPosition GetGridPosition(Vector3 worldPosition)
        {
            return _grid.WorldToGrid(worldPosition);
        }

        public Vector3 GetSnappedWorldPosition(GridPosition position)
        {
            return _grid.GridToWorld(position);
        }
    }
}
