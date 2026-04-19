using UnityEngine;

namespace Signal.Core.Entities
{
    public interface IEntitySpawner
    {
        EntityInstanceId Spawn(EntityId entityId, Vector2 position);
        void Release(EntityInstanceId presenter);
    }
}
