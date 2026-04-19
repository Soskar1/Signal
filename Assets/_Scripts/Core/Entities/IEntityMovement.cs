using Signal.Core.World;
using UnityEngine;

namespace Signal.Core.Entities
{
    public interface IEntityMovement
    {
        Vector2 GetPosition(EntityInstanceId entityId);
        void MoveTowards(EntityInstanceId entityId, Vector2 targetPosition, float deltaTime);
    }
}
