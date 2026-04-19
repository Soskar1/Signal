using System;

namespace Signal.Core.Buildings
{
    public class BuildingDestroyedEventArgs : EventArgs
    {
        public BuildingInfo BuildingInfo { get; }

        public BuildingDestroyedEventArgs(BuildingInfo buildingInfo)
        {
            BuildingInfo = buildingInfo;
        }
    }
}
