using Signal.Core.World;

namespace Signal.Core.Entities
{
    public interface IEntityQuery
    {
        public EntityInfo GetEntityInfo(EntityInstanceId entityInstanceId);
    }
}
