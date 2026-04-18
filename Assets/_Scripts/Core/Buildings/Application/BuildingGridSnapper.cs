using Signal.Core.Buildings.Domain;
using UnityEngine;

namespace Signal.Core.Buildings.Application
{
    internal class BuildingGridSnapper
    {
        private readonly BuildingGrid _grid;

        public BuildingGridSnapper(BuildingGrid grid)
        {
            _grid = grid;
        }

        public GridPosition ToGridPosition(Vector3 worldPosition)
        {
            return _grid.WorldToGrid(worldPosition);
        }

        public Vector3 ToWorldPosition(GridPosition gridPosition)
        {
            return _grid.GridToWorld(gridPosition);
        }
    }
}
