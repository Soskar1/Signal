using Signal.Core.Economy.Infrastructure;
using UnityEngine;
using UnityEngine.UI;

namespace Signal.Core.Economy.Presentation
{
    internal class ResourceCategoryPresenter : MonoBehaviour
    {
        [SerializeField] private Image _categoryImage;
        [SerializeField] private Transform _resourceContainer;

        public Transform ResourceContainer => _resourceContainer;

        public void Initialize(ResourceCategoryDefinition definition)
        {
            _categoryImage.sprite = definition.Icon;
        }
    }
}
