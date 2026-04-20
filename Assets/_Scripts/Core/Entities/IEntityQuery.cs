using Signal.Core.World;
using UnityEngine;

namespace Signal.Core.Entities
{
    public interface IEntityQuery
    {
        public EntityInfo GetEntityInfo(EntityInstanceId entityInstanceId);
        public EntityInfo GetNearestEntity(Vector2 worldPosition);
    }
}
