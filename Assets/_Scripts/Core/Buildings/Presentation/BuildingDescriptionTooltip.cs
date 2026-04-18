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

        public void Display(BuildingDefinition buildingDefinition)
        {
            _image.sprite = buildingDefinition.Sprite;
            _displayName.text = buildingDefinition.DisplayName;
            _description.text = buildingDefinition.Description;

            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}
