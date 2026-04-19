using Signal.Core.World;

namespace Signal.Core.Entities.Domain
{
    public class Entity
    {
        private readonly EntityInstanceId _instanceId;
        private readonly EntityId _definitionId;

        public EntityInstanceId InstanceId => _instanceId;
        public EntityId DefinitionId => _definitionId;
        public HealthOwnerId HealthOwnerId => InstanceId.HealthOwnerId;

        public Entity(EntityInstanceId instanceId, EntityId definitionId)
        {
            _instanceId = instanceId;
            _definitionId = definitionId;
        }
    }
}