using Reflex.Attributes;
using Signal.Core.Gameplay.Application;
using UnityEngine;

namespace Signal.Core.Gameplay.Presentation
{
    internal class EnemyAiPresenter : MonoBehaviour
    {
        private EnemyAi _enemyAi;

        [Inject]
        public void Inject(EnemyAi ai)
        {
            _enemyAi = ai;
        }

        public void Update()
        {
            _enemyAi.Tick(Time.deltaTime);
        }
    }
}
