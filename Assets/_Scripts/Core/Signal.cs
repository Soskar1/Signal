using UnityEngine;
using UnityEngine.SceneManagement;

namespace Signal.Core
{
    public class Signal
    {
        private readonly int _mainMenuSceneBuildIndex;
        private readonly int _gameSceneBuildIndex;

        public Signal(int mainMenuSceneBuildIndex, int gameSceneBuildIndex)
        {
            _mainMenuSceneBuildIndex = mainMenuSceneBuildIndex;
            _gameSceneBuildIndex = gameSceneBuildIndex;
        }

        public void TransitionToMainMenu()
        {
            SceneManager.LoadScene(_mainMenuSceneBuildIndex);
        }

        public void TransitionToGameScene()
        {
            SceneManager.LoadScene(_gameSceneBuildIndex);
        }

        public void Exit() => Application.Quit();
    }
}