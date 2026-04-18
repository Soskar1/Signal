namespace Signal.Core.Economy
{
    public interface IResourceWallet
    {
        public void Add(ResourceId resourceId, int amount);
        public bool TryWithdraw(ResourceId resourceId, int amount);
    }
}
