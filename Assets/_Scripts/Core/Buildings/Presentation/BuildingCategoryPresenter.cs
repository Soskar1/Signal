using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Signal.Core.Buildings.Presentation
{
    internal class BuildingCategoryPresenter : MonoBehaviour
    {
        [SerializeField] private Image _categoryImage;
        [SerializeField] private Image _categoryTabImage;
        [SerializeField] private Sprite _tabActiveSprite;
        [SerializeField] private Sprite _tabNonActiveSprite;
        [SerializeField] private Button _button;

        public void Initialize(Sprite categorySprite, IEnumerable<BuildingButtonPresenter> buttonsToDisplay, IEnumerable<BuildingButtonPresenter> buttonsToHide, IEnumerable<BuildingCategoryPresenter> categoryButtons)
        {
            _categoryImage.sprite = categorySprite;

            _button.onClick.AddListener(() => DisplayCategoryButtons(buttonsToDisplay));
            _button.onClick.AddListener(() => HideNonCategoryButtons(buttonsToHide));
            _button.onClick.AddListener(() => ActivateTab(categoryButtons));
        }

        public void OnDestroy()
        {
            _button.onClick.RemoveAllListeners();
        }

        private void DisplayCategoryButtons(IEnumerable<BuildingButtonPresenter> buttons)
        {
            foreach (var button in buttons)
            {
                button.gameObject.SetActive(true);    
            }
        }

        private void HideNonCategoryButtons(IEnumerable<BuildingButtonPresenter> buttons)
        {
            foreach (var button in buttons)
            {
                button.gameObject.SetActive(false);
            }
        }

        private void ActivateTab(IEnumerable<BuildingCategoryPresenter> otherCategories)
        {
            ActivateTab();

            foreach (var category in otherCategories)
            {
                category.DisableTab();
            }
        }

        public void ActivateTab() => _categoryTabImage.sprite = _tabActiveSprite;
        public void DisableTab() => _categoryTabImage.sprite = _tabNonActiveSprite;
    }
}
