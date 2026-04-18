using Signal.Core.Buildings.Domain;
using UnityEngine;

namespace Signal.Core.Buildings.Infrastructure
{
    [CreateAssetMenu(fileName = "BuildingCategoryDefinition", menuName = "Signal/Buildings/Building Category Definition")]
    internal class BuildingCategoryDefinition : ScriptableObject
    {
        [SerializeField] private BuildingCategory _buildingCategory;
        [SerializeField] private Sprite _sprite;

        public BuildingCategory Category => _buildingCategory;
        public Sprite Sprite => _sprite;
    }
}
