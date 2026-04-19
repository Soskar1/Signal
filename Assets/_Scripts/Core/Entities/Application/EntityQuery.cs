using Signal.Core.World;

namespace Signal.Core.Entities.Application
{
    internal class EntityQuery : IEntityQuery
    {
        private readonly EntityRegistry _entityRegistry;

        public EntityQuery(EntityRegistry entityRegistry)
        {
            _entityRegistry = entityRegistry;
        }

        public int GetEntityAttackDamage(EntityInstanceId entityId)
        {
            var entity = _entityRegistry.Get(entityId);
            return entity.AttackDamage;
        }

        public float GetEntityAttackSpeed(EntityInstanceId entityId)
        {
            var entity = _entityRegistry.Get(entityId);
            return entity.AttackSpeed;
        }
    }
}
