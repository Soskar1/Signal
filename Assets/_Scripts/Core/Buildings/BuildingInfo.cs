using Signal.Core.World;
using UnityEngine;

namespace Signal.Core.Buildings
{
    public class BuildingInfo
    {
        public EntityInstanceId InstanceId { get; }
        public HealthOwnerId HealthOwnerId => InstanceId.HealthOwnerId;
        public BuildingId BuildingId { get; }
        public Vector2 WorldPosition { get; }

        public BuildingInfo(EntityInstanceId instanceId, BuildingId buildingId, Vector2 worldPosition)
        {
            InstanceId = instanceId;
            BuildingId = buildingId;
            WorldPosition = worldPosition;
        }
    }
}
