using Reflex.Attributes;
using Signal.Core.Gameplay.Application;
using Signal.Core.Gameplay.Domain;
using TMPro;
using UnityEngine;

namespace Signal.Core.Gameplay.Presentation
{
    internal class TimePresenter : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _timerText;

        private Timer _timer;
        private GameplayTime _time;

        [Inject]
        public void Inject(GameplayTime time, Timer timer)
        {
            _time = time;
            _timer = timer;
        }

        public void Start()
        {
            _time.GameplayTimeChanged += HandleGameplayTimeChanged;
        }

        public void OnDestroy()
        {
            _time.GameplayTimeChanged -= HandleGameplayTimeChanged;
        }

        public void Update()
        {
            _timer.Tick(Time.deltaTime);
        }

        private void HandleGameplayTimeChanged(object _, GameplayTimeChangedEventArgs args)
        {
            _timerText.text = $"{args.Minutes:00}:{args.Seconds:00}";
        }
    }
}