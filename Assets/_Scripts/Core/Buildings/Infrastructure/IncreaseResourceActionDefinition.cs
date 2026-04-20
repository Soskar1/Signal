using Signal.Core.Economy;
using System.Collections.Generic;
using UnityEngine;

namespace Signal.Core.Buildings.Infrastructure
{
    [CreateAssetMenu(fileName = "IncreaseResourceAction", menuName = "Signal/Buildings/Actions/Increase Resource")]
    internal class IncreaseResourceActionDefinition : BuildingActionDefinition
    {
        [SerializeField] private List<ResourceId> _resources;
        [SerializeField] private int _amount;

        public List<ResourceId> Resources => _resources;
        public int Amount => _amount;
    }
}
