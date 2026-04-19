using Signal.Core.Entities.Domain;
using Signal.Core.World;
using System.Collections.Generic;

namespace Signal.Core.Entities.Application
{
    internal sealed class EntityRegistry
    {
        private readonly Dictionary<EntityInstanceId, Entity> _entities = new();
        private readonly Dictionary<HealthOwnerId, EntityInstanceId> _entityByHealthOwner = new();

        public IEnumerable<Entity> Entities => _entities.Values;

        public void Add(Entity entity)
        {
            _entities.Add(entity.InstanceId, entity);
            _entityByHealthOwner.Add(entity.HealthOwnerId, entity.InstanceId);
        }

        public bool TryGet(EntityInstanceId instanceId, out Entity entity) => _entities.TryGetValue(instanceId, out entity);

        public bool TryGetByHealthOwner(HealthOwnerId ownerId, out Entity entity)
        {
            if (_entityByHealthOwner.TryGetValue(ownerId, out var instanceId) &&
                _entities.TryGetValue(instanceId, out entity))
            {
                return true;
            }

            entity = null;
            return false;
        }

        public void Remove(EntityInstanceId instanceId)
        {
            var entity = _entities[instanceId];
            _entities.Remove(instanceId);
            _entityByHealthOwner.Remove(entity.HealthOwnerId);
        }
    }
}