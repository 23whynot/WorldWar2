using System;
using Script.Core;
using UnityEngine;
using UnityEngine.UI;

namespace Script.UI
{
    public class InputController : MonoBehaviour
    {
        [SerializeField] private Health health;
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
            
            health.OnDeath += OpenDeathMenu;
        }

        private void OpenDeathMenu()
        {
            uiController.OpenDeathMenu();
        }

        private void OnDisable()
        {
            health.OnDeath -= OpenDeathMenu;
        }
    }
}
