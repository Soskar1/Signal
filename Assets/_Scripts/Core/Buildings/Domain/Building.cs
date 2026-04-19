using Signal.Core.World;

namespace Signal.Core.Buildings.Domain
{
    internal class Building
    {
        private readonly IBuildingAction _buildingAction;

        public BuildingId Id { get; }
        public EntityInstanceId InstanceId { get; }
        public HealthOwnerId HealthOwnerId => InstanceId.HealthOwnerId;
        public GridPosition GridPosition { get; }

        public Building(BuildingId id, EntityInstanceId instanceId, GridPosition gridPosition, IBuildingAction buildingAction)
        {
            Id = id;
            InstanceId = instanceId;
            _buildingAction = buildingAction;
            GridPosition = gridPosition;
        }

        public void Tick(double deltaTime)
        {
            _buildingAction.Tick(deltaTime);
        }
    }
}
