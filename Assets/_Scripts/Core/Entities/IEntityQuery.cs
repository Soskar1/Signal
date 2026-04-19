using Signal.Core.World;

namespace Signal.Core.Entities
{
    public interface IEntityQuery
    {
        public int GetEntityAttackDamage(EntityInstanceId entityId);
        public float GetEntityAttackSpeed(EntityInstanceId entityId);
    }
}
