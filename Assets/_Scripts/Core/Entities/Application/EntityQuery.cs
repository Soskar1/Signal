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
        public EntityInfo GetEntityInfo(EntityInstanceId entityInstanceId)
        {
            var entity = _entityRegistry.Get(entityInstanceId);
            return new EntityInfo(entityInstanceId, entity.AttackDamage, entity.AttackSpeed, entity.AttackDistance);
        }
    }
}
