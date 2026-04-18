using UnityEngine;
using UnityEngine.UI;

namespace Signal.Core.Buildings.Presentation
{
    internal class BuildingButtonPresenter : MonoBehaviour
    {
        [SerializeField] private Image _image;

        public void Initialize(Sprite buildingSprite)
        {
            _image.sprite = buildingSprite;
        }
    }
}
