using Signal.Core.Buildings.Domain;
using Signal.Core.Buildings.Infrastructure;
using UnityEngine;

namespace Signal.Core.Buildings
{
    [CreateAssetMenu(fileName = "BuildingDefinition", menuName = "Signal/Buildings/Building Definition")]
    internal class BuildingDefinition : ScriptableObject
    {
        [SerializeField] private BuildingId _id;
        [SerializeField] private string _displayName;
        [SerializeField] private string _description;
        [SerializeField] private Sprite _sprite;
        [SerializeField] private int _health;
        [SerializeField] private BuildingActionDefinition _actionDefinition;

        public string Id => _id.Id;
        public string DisplayName => _displayName;
        public string Description => _description;
        public Sprite Sprite => _sprite;
        public BuildingActionDefinition ActionDefinition => _actionDefinition;
        public int Health => _health;
    }
}