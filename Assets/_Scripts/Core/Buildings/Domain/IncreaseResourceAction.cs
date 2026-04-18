using Signal.Core.Economy;
using UnityEngine;

namespace Signal.Core.Buildings.Domain
{
    [System.Serializable]
    public class IncreaseResourceAction : BuildingAction
    {
        [SerializeField] private ResourceId _resourceId;
        [SerializeField] private int _increaseAmount;
        private readonly IResourceWallet _resourceWallet;

        public IncreaseResourceAction(IResourceWallet resourceWallet)
        {
            _resourceWallet = resourceWallet;
        }

        public override void Execute()
        {
            _resourceWallet.Add(_resourceId, _increaseAmount);
        }
    }
}
