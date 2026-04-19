using Reflex.Attributes;
using Signal.Core.Gameplay.Domain;
using TMPro;
using UnityEngine;

namespace Signal.Core.Gameplay.Presentation
{
    internal class GameOverScreen : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _timeText;
        private GameplayTime _time;

        [Inject]
        public void Inject(GameplayTime time)
        {
            _time = time;
        }

        public void Display()
        {
            _timeText.text = $"Time: {_time.Minutes:00}:{_time.Seconds:00}";
            gameObject.SetActive(true);
        }
    }
}
