using UnityEngine;
using UnityEngine.UI;

namespace Signal.Core.Buildings.Presentation
{
    internal class BuildingHealthBar : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private Gradient _gradient;

        public void UpdateHealthBar(int currentHealth, int maxHealth)
        {
            if (!gameObject.activeSelf)
            {
                gameObject.SetActive(true);
            }

            var ratio = currentHealth / (float)maxHealth;

            _image.fillAmount = ratio;
            _image.color = _gradient.Evaluate(1f - ratio);
        }
    }
}
