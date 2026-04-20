using Signal.Core.Buildings.Presentation;
using Signal.Core.Economy;
using UnityEngine;

namespace Signal.Core.Buildings.Infrastructure
{
    [CreateAssetMenu(fileName = "ShootAction", menuName = "Signal/Buildings/Actions/Shoot")]
    internal class ShootActionDefinition : BuildingActionDefinition
    {
        [SerializeField] private Projectile _projectilePrefab;
        [SerializeField] private ResourceId _resource;
        [SerializeField] private int _amount;

        public Projectile ProjectilePrefab => _projectilePrefab;
        public ResourceId Resource => _resource;
        public int Amount => _amount;
    }
}
