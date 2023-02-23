using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
namespace Managers
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance;
        [SerializeField]
        private GameObject gameOverCanvas;
        [SerializeField]
        private GameObject levelCompletedCanvas;
        public static event Action gameOverEvent;
        public static event Action levelCompletedEvent;
        // Start is called before the first frame update
        void Awake()
        {
            if (instance == null)
                instance = this;
            else if (instance != this)
                Destroy(instance);
        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.R))
                SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
        }
        private void OnEnable() 
        {
            WaveManager.wavesFinishedEvent += LevelCompleted;
        }
        private void OnDisable() 
        {
            WaveManager.wavesFinishedEvent -= LevelCompleted;
        }
        public void GameOver()
        {
            gameOverCanvas.SetActive(true);
            gameOverEvent?.Invoke();
        }
        public void LevelCompleted()
        {
            levelCompletedCanvas.SetActive(true);
            levelCompletedEvent?.Invoke();
        }
        public void RestartLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

}
