using Signal.Core.World;
using UnityEngine;

namespace Signal.Core.Entities
{
    public class EntityInfo
    {
        public EntityInstanceId InstanceId { get; }
        public Vector2 WorldPosition { get; }
        public int AttackDamage { get; }
        public float AttackSpeed { get; }
        public float AttackDistance { get; }

        public EntityInfo(EntityInstanceId instanceId, int attackDamage, float attackSpeed, float attackDistance, Vector2 worldPosition)
        {
            InstanceId = instanceId;
            AttackDamage = attackDamage;
            AttackSpeed = attackSpeed;
            AttackDistance = attackDistance;
            WorldPosition = worldPosition;
        }
    }
}
