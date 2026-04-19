using Signal.Core.Entities.Domain;
using Signal.Core.World;
using System.Linq;
using UnityEngine;

namespace Signal.Core.Entities.Application
{
    internal class EntityQuery : IEntityQuery
    {
        private readonly EntityRegistry _entityRegistry;
        private readonly EntityPresenterRegistry _entityPresenterRegistry;

        public EntityQuery(EntityRegistry entityRegistry, EntityPresenterRegistry entityPresenterRegistry)
        {
            _entityRegistry = entityRegistry;
            _entityPresenterRegistry = entityPresenterRegistry;
        }
        public EntityInfo GetEntityInfo(EntityInstanceId entityInstanceId)
        {
            var success = _entityRegistry.TryGet(entityInstanceId, out var entity);

            if (!success)
            {
                return null;
            }

            success = _entityPresenterRegistry.TryGet(entityInstanceId, out var presenter);

            if (!success)
            {
                return null;
            }

            return CreateEntityInfo(entity, presenter.transform.position);
        }

        public EntityInfo GetNearestEntity(Vector2 worldPosition)
        {
            var entities = _entityRegistry.Entities.ToList();

            if (entities.Count == 0)
                return null;

            var nearestEntity = entities[0];
            _entityPresenterRegistry.TryGet(nearestEntity.InstanceId, out var presenter);
            var nearestEntityWorldPosition = presenter.transform.position;

            var currentSmallestDistance = Vector2.Distance(presenter.transform.position, worldPosition);

            for (var index = 1; index < entities.Count; ++index)
            {
                var entity = entities[index];
                _entityPresenterRegistry.TryGet(entity.InstanceId, out presenter);

                var distance = Vector2.Distance(presenter.transform.position, worldPosition);

                if (distance < currentSmallestDistance)
                {
                    nearestEntity = entity;
                    currentSmallestDistance = distance;
                    nearestEntityWorldPosition = presenter.transform.position;
                }
            }

            return CreateEntityInfo(nearestEntity, nearestEntityWorldPosition);
        }

        private EntityInfo CreateEntityInfo(Entity entity, Vector2 position)
        {
            return new EntityInfo(entity.InstanceId, entity.AttackDamage, entity.AttackSpeed, entity.AttackDistance, position);
        }
    }
}
