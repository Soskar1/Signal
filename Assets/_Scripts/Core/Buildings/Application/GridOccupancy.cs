using Signal.Core.Buildings.Domain;
using System.Collections.Generic;

namespace Signal.Core.Buildings.Application
{
    internal class GridOccupancy
    {
        private readonly HashSet<GridPosition> _occupied = new();

        public bool IsOccupied(GridPosition position)
        {
            return _occupied.Contains(position);
        }

        public void Occupy(GridPosition position)
        {
            _occupied.Add(position);
        }

        public void Free(GridPosition position)
        {
            _occupied.Remove(position);
        }
    }
}
