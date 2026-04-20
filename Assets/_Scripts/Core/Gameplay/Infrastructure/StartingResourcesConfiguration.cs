using System.Collections.Generic;
using UnityEngine;

namespace Signal.Core.Gameplay.Infrastructure
{
    [CreateAssetMenu(fileName = "StartingResourcesConfiguration", menuName = "Signal/Gameplay/Starting Resources Configuration")]
    internal class StartingResourcesConfiguration : ScriptableObject
    {
        [SerializeField] private List<StartingResource> _startingResources;

        public List<StartingResource> StartingResources => _startingResources;
    }
}
