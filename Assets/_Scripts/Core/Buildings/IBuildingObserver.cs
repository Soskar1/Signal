using System;

namespace Signal.Core.Buildings
{
    public interface IBuildingObserver
    {
        public event EventHandler<BuildingDestroyedEventArgs> BuildingDestroyed;
    }
}
