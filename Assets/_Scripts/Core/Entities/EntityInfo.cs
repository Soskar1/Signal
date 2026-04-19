using Signal.Core.World;

namespace Signal.Core.Entities
{
    public struct EntityInfo
    {
        public EntityInstanceId InstanceId { get; }
        public int AttackDamage { get; }
        public float AttackSpeed { get; }
        public float AttackDistance { get; }

        public EntityInfo(EntityInstanceId instanceId, int attackDamage, float attackSpeed, float attackDistance)
        {
            InstanceId = instanceId;
            AttackDamage = attackDamage;
            AttackSpeed = attackSpeed;
            AttackDistance = attackDistance;
        }
    }
}
