using Reflex.Attributes;
using Signal.Core.Buildings.Domain;
using Signal.Core.Economy;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Signal.Core.Buildings.Presentation
{
    internal class ResourceCostPresenter : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private TextMeshProUGUI _countText;

        private IResourceQuery _resourceQuery;

        [Inject]
        public void Inject(IResourceQuery resourceQuery)
        {
            _resourceQuery = resourceQuery;
        }

        public void Display(ResourceCost cost)
        {
            var resourceInfo = _resourceQuery.GetResourceInfo(cost.ResourceId);
            
            _image.sprite = resourceInfo.Sprite;
            _countText.text = cost.Cost.ToString();

            gameObject.SetActive(true);
        }
    }
}