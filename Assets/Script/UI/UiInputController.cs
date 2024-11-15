using UnityEngine;
using UnityEngine.UI;

namespace Script.UI
{
    public class UiInputController : MonoBehaviour
    {
        [SerializeField] UIController uiController;
        [SerializeField] Button pauseButton;
        [SerializeField] Button resumeButton;
        [SerializeField] Button settingsButton;
        [SerializeField] Button exitFromPauseMenuButton;
        [SerializeField] Button restartButton;
        [SerializeField] Button exitFromDeathMenuButton;
        [SerializeField] Button exitFromSettingsMenuButton;

        private void Start()
        {
            pauseButton.onClick.AddListener(uiController.OpenPauseMenu);
            resumeButton.onClick.AddListener(uiController.OpenHudMenu);
            settingsButton.onClick.AddListener(uiController.OpenSettingsMenu);
            exitFromPauseMenuButton.onClick.AddListener(uiController.LoadMainMenu);
            restartButton.onClick.AddListener(uiController.RestartGame);
            exitFromDeathMenuButton.onClick.AddListener(uiController.LoadMainMenu);
            exitFromSettingsMenuButton.onClick.AddListener(uiController.OpenPauseMenu);
        }
    }
}
