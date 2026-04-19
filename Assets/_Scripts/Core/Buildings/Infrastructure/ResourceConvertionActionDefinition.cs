using Signal.Core.Economy;
using UnityEngine;

namespace Signal.Core.Buildings.Infrastructure
{
    [CreateAssetMenu(fileName = "IncreaseResourceAction", menuName = "Signal/Buildings/Actions/Increase Resource")]
    internal class ResourceConvertionActionDefinition : BuildingActionDefinition
    {
        [SerializeField] private ResourceId _from;
        [SerializeField] private ResourceId _to;
        [SerializeField] private int _amount;

        public ResourceId From => _from;
        public ResourceId To => _to;
        public int Amount => _amount;
    }
}
