using Signal.Core.Economy;
using UnityEngine;

namespace Signal.Core.Gameplay.Infrastructure
{
    [System.Serializable]
    internal class StartingResource
    {
        [SerializeField] private ResourceId _resourceId;
        [SerializeField] private int _amount;

        public ResourceId ResourceId => _resourceId;
        public int Amount => _amount;
    }
}
