using UnityEngine;
using UnityEngine.SceneManagement;

namespace ryathom.RunTheNet
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance {get; private set;}

        private string currentScene;


        // Main Unity methods
        //---------------------------------------------------------------------------------------------------------
        private void Awake() 
        {
            if (Instance == null) {
                Instance = this;
            } else
            {
                Destroy(gameObject);
            }

            DontDestroyOnLoad(gameObject);
        }

        public void Start()
        {
        }

        public void Update()
        {
        }

        // Scene management
        //---------------------------------------------------------------------------------------------------------
        public void LoadScene(string sceneName)
        {
            SceneManager.LoadScene(sceneName);
        }
        
        // public void LoadScene(string sceneName)
        // {
        //     SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
        //     currentScene = sceneName;
        // }

        // public void LoadNewScene(string sceneName)
        // {
        //     SceneManager.UnloadSceneAsync(currentScene);
        //     LoadScene(sceneName);
        // }
    }
}