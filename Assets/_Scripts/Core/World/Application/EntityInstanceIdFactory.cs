namespace Signal.Core.World.Application
{
    internal class EntityInstanceIdFactory : IEntityInstanceIdFactory
    {
        private int _nextInstanceId = 1;

        public EntityInstanceId Create(HealthOwnerId healthOwnerId)
        {
            var instanceId = new EntityInstanceId(_nextInstanceId, healthOwnerId);
            ++_nextInstanceId;

            return instanceId;
        }
    }
}
