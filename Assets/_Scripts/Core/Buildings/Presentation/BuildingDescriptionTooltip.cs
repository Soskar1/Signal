using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Signal.Core.Buildings.Presentation
{
    internal class BuildingDescriptionTooltip : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private TextMeshProUGUI _displayName;
        [SerializeField] private TextMeshProUGUI _description;
        [SerializeField] private List<ResourceCostPresenter> _resourceCostPresenter;

        public void Display(BuildingDefinition buildingDefinition)
        {
            _image.sprite = buildingDefinition.DisplaySprite;
            _displayName.text = buildingDefinition.DisplayName;
            _description.text = buildingDefinition.Description;

            var index = 0;
            while (index < buildingDefinition.BuildingCost.Count)
            {
                var cost = buildingDefinition.BuildingCost[index];
                _resourceCostPresenter[index].Display(cost);
                
                ++index;
            }

            while (index < _resourceCostPresenter.Count)
            {
                _resourceCostPresenter[index].gameObject.SetActive(false);
                ++index;
            }

            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}
