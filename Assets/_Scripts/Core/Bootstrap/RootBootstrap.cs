using UnityEngine;
using UnityEngine.SceneManagement;

namespace Signal.Core.Bootstrap
{
    internal class RootBootstrap : MonoBehaviour
    {
        public void Start() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
