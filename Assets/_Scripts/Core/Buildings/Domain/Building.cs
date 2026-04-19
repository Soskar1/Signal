using Signal.Core.World;

namespace Signal.Core.Buildings.Domain
{
    internal class Building
    {
        private readonly string _id;
        private readonly EntityInstanceId _instanceId;
        private readonly IBuildingAction _buildingAction;

        public EntityInstanceId InstanceId => _instanceId;
        public HealthOwnerId HealthOwnerId => _instanceId.HealthOwnerId;

        public Building(string id, EntityInstanceId instanceId, IBuildingAction buildingAction)
        {
            _id = id;
            _instanceId = instanceId;
            _buildingAction = buildingAction;
        }

        public void Tick(double deltaTime)
        {
            _buildingAction.Tick(deltaTime);
        }
    }
}
