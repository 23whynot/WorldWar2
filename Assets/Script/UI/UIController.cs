using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Script.UI
{
    public class UIController : MonoBehaviour
    {
        [SerializeField] GameObject hudMenu;
        [SerializeField] GameObject pauseMenu;
        [SerializeField] GameObject deathMenu;
        [SerializeField] GameObject settingsMenu;

        private void Start()
        {
            deathMenu.SetActive(false);
            pauseMenu.SetActive(false);
            settingsMenu.SetActive(false);
            hudMenu.SetActive(true);
        
            Time.timeScale = 1f;
        }

        public void OpenHudMenu()
        {
            settingsMenu.SetActive(false);
            deathMenu.SetActive(false);
            pauseMenu.SetActive(false);
            hudMenu.SetActive(true);
        
            Time.timeScale = 1f;
        }

        public void OpenPauseMenu()
        {
            settingsMenu.SetActive(false);
            hudMenu.SetActive(false);
            deathMenu.SetActive(false);
            pauseMenu.SetActive(true);
        
            Time.timeScale = 0f;
        }

        public void OpenDeathMenu()
        {
            settingsMenu.SetActive(false);
            hudMenu.SetActive(false);
            pauseMenu.SetActive(false);
            deathMenu.SetActive(true);
        
            Time.timeScale = 1f;
        }

        public void OpenSettingsMenu()
        {
            hudMenu.SetActive(false);
            pauseMenu.SetActive(false);
            deathMenu.SetActive(false);
            settingsMenu.SetActive(true);
        }

        public void LoadMainMenu()
        {
            DOTween.KillAll();
            SceneManager.LoadScene(0);
        }

        public void ExitGame()
        {
            Application.Quit();
        }

        public void RestartGame()
        {
            DOTween.KillAll();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
