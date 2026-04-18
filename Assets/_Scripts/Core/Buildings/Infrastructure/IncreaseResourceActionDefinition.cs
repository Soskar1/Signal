using Signal.Core.Economy;
using UnityEngine;

namespace Signal.Core.Buildings.Infrastructure
{
    [CreateAssetMenu(fileName = "IncreaseResourceAction", menuName = "Signal/Buildings/Actions/Increase Resource")]
    internal class IncreaseResourceActionDefinition : BuildingActionDefinition
    {
        [SerializeField] private ResourceId _resourceId;
        [SerializeField] private int _amount;

        public ResourceId ResourceId => _resourceId;
        public int Amount => _amount;
    }
}
