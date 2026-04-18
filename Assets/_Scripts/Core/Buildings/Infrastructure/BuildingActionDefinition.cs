using UnityEngine;

namespace Signal.Core.Buildings.Infrastructure
{
    internal abstract class BuildingActionDefinition : ScriptableObject
    {
        [SerializeField] private float _cooldownInSeconds;

        public float CooldownInSeconds => _cooldownInSeconds;
    }
}
