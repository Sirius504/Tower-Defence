using UnityEngine;
using UnityEngine.SceneManagement;

namespace TowerDefence.Common
{
    public class SceneLoader : MonoBehaviour
    {
        [SerializeField] int sceneIndex;

        public void LoadScene()
        {
            SceneManager.LoadScene(sceneIndex);
        }
    } 
}
