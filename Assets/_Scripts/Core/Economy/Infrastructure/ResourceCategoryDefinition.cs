using Signal.Core.Economy.Domain;
using UnityEngine;

namespace Signal.Core.Economy.Infrastructure
{
    [CreateAssetMenu(fileName = "ResourceCategoryDefinition", menuName = "Signal/Resource Category Definition")]
    internal class ResourceCategoryDefinition : ScriptableObject
    {
        [SerializeField] private ResourceCategory _category;
        [SerializeField] private Sprite _icon;

        public ResourceCategory Category => _category;
        public Sprite Icon => _icon;
    }
}
