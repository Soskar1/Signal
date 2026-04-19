namespace Signal.Core.World
{
    public interface IEntityInstanceIdFactory
    {
        public EntityInstanceId Create(HealthOwnerId healthOwnerId);
    }
}
