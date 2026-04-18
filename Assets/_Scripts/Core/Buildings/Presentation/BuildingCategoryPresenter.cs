using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Signal.Core.Buildings.Presentation
{
    internal class BuildingCategoryPresenter : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private Button _button;

        public void Initialize(Sprite categorySprite, IEnumerable<BuildingButtonPresenter> buttonsToDisplay, IEnumerable<BuildingButtonPresenter> buttonsToHide)
        {
            _image.sprite = categorySprite;

            _button.onClick.AddListener(() => DisplayCategoryButtons(buttonsToDisplay));
            _button.onClick.AddListener(() => HideNonCategoryButtons(buttonsToHide));
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
    }
}
