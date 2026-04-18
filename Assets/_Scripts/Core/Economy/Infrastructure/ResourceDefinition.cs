using Signal.Core.Economy.Domain;
using UnityEngine;

namespace Signal.Core.Economy.Infrastructure
{
    [CreateAssetMenu(fileName = "ResourceDefinition", menuName = "Signal/Resource Definition")]
    internal class ResourceDefinition : ScriptableObject
    {
        [SerializeField] private string _id;
        [SerializeField] private string _displayName;
        [SerializeField] private Sprite _sprite;
        [SerializeField] private ResourceCategory _category;

        public string Id => _id;
        public string DisplayName => _displayName;
        public Sprite Sprite => _sprite;
        public ResourceCategory Category => _category;
    }
}