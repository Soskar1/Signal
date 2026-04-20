using Signal.Core.Buildings.Domain;
using Signal.Core.Buildings.Infrastructure;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

namespace Signal.Core.Buildings
{
    [CreateAssetMenu(fileName = "BuildingDefinition", menuName = "Signal/Buildings/Building Definition")]
    internal class BuildingDefinition : ScriptableObject
    {
        [SerializeField] private BuildingId _id;

        [Header("Display Info")]
        [SerializeField] private string _displayName;
        [SerializeField] private string _description;
        [SerializeField] private Sprite _baseSprite;
        [SerializeField] private Sprite _headSprite;
        [SerializeField] private Sprite _displaySprite;
        [SerializeField] private BuildingCategory _category;
        [SerializeField] private AnimatorController _animatorController;

        [Header("Gameplay")]
        [SerializeField] private BuildingActionDefinition _actionDefinition;
        [SerializeField] private bool _isConstructable;
        [SerializeField] private int _health;
        [SerializeField] private List<ResourceCost> _buildingCost;

        public BuildingId Id => _id;
        public string DisplayName => _displayName;
        public string Description => _description;
        public Sprite BaseSprite => _baseSprite;
        public Sprite HeadSprite => _headSprite;
        public Sprite DisplaySprite => _displaySprite;
        public BuildingActionDefinition ActionDefinition => _actionDefinition;
        public BuildingCategory Category => _category;
        public bool IsConstructable => _isConstructable;
        public int Health => _health;
        public List<ResourceCost> BuildingCost => _buildingCost;
        public AnimatorController AnimatorController => _animatorController;
    }
}