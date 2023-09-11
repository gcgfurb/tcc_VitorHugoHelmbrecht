using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class LoadLevel : MonoBehaviour
    {
        public string nextLevel;

        void OnEnable() {
            SceneManager.LoadScene(nextLevel, LoadSceneMode.Single);
        }
    }
}