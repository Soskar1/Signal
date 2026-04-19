using Signal.Core.Entities.Infrastructure;
using Signal.Core.World;

namespace Signal.Core.Entities.Domain
{
    internal class Entity
    {
        private readonly EntityInstanceId _instanceId;
        private readonly EntityId _id;

        public EntityInstanceId InstanceId => _instanceId;
        public EntityId DefinitionId => _id;
        public HealthOwnerId HealthOwnerId => InstanceId.HealthOwnerId;
        public int AttackDamage { get; }
        public float AttackSpeed { get; }

        public Entity(EntityInstanceId instanceId, EntityDefinition entityDefinition)
        {
            _instanceId = instanceId;
            _id = entityDefinition.Id;
            AttackDamage = entityDefinition.AttackDamage;
            AttackSpeed = entityDefinition.AttackSpeed;
        }
    }
}