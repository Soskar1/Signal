using Signal.Core.Economy.Domain;
using UnityEngine;

namespace Signal.Core.Economy.Infrastructure
{
    [CreateAssetMenu(fileName = "ResourceDefinition", menuName = "Signal/Economy/Resource Definition")]
    internal class ResourceDefinition : ScriptableObject
    {
        [SerializeField] private ResourceId _resourceId;
        [SerializeField] private string _displayName;
        [SerializeField] private Sprite _sprite;
        [SerializeField] private ResourceCategory _category;

        public string Id => _resourceId.Id;
        public string DisplayName => _displayName;
        public Sprite Sprite => _sprite;
        public ResourceCategory Category => _category;
    }
}