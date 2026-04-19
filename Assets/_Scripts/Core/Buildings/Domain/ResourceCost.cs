using Signal.Core.Economy;
using UnityEngine;

namespace Signal.Core.Buildings.Domain
{
    [System.Serializable]
    internal class ResourceCost
    {
        [SerializeField] private ResourceId _resourceId;
        [SerializeField] private int _cost;

        public ResourceId ResourceId => _resourceId;
        public int Cost => _cost;
    }
}
