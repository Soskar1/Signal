using Signal.Core.Entities.Infrastructure;
using Signal.Core.World;
using UnityEngine;

namespace Signal.Core.Entities.Application
{
    internal sealed class EntityMovement : IEntityMovement
    {
        private readonly EntityRegistry _entityRegistry;
        private readonly EntityDefinitionCatalog _definitionCatalog;
        private readonly EntityPresenterRegistry _presenterRegistry;

        public EntityMovement(EntityRegistry entityRegistry, EntityDefinitionCatalog definitionCatalog, EntityPresenterRegistry presenterRegistry)
        {
            _entityRegistry = entityRegistry;
            _definitionCatalog = definitionCatalog;
            _presenterRegistry = presenterRegistry;
        }

        public Vector2 GetPosition(EntityInstanceId entityId)
        {
            var presenter = _presenterRegistry.Get(entityId);
            return presenter.transform.position;
        }

        public void MoveTowards(EntityInstanceId entityId, Vector2 targetPosition, float deltaTime)
        {
            var entity = _entityRegistry.Get(entityId);
            var definition = _definitionCatalog.Get(entity.DefinitionId.Id);
            var presenter = _presenterRegistry.Get(entityId);

            var currentPosition = (Vector2)presenter.transform.position;
            var nextPosition = Vector2.MoveTowards(currentPosition, targetPosition, definition.MoveSpeed * deltaTime);

            presenter.transform.position = nextPosition;
        }
    }
}
