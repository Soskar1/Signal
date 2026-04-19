using Signal.Core.World;
using UnityEngine;

namespace Signal.Core.Buildings.Domain
{
    internal class Building
    {
        private readonly IBuildingAction _buildingAction;

        public BuildingId Id { get; }
        public EntityInstanceId InstanceId { get; }
        public HealthOwnerId HealthOwnerId => InstanceId.HealthOwnerId;
        public GridPosition GridPosition { get; }
        public Vector2 WorldPosition { get; }

        public Building(BuildingId id, EntityInstanceId instanceId, GridPosition gridPosition, Vector2 worldPosition, IBuildingAction buildingAction)
        {
            Id = id;
            InstanceId = instanceId;
            _buildingAction = buildingAction;
            GridPosition = gridPosition;
            WorldPosition = worldPosition;
        }

        public void Tick(double deltaTime)
        {
            _buildingAction.Tick(deltaTime);
        }
    }
}
