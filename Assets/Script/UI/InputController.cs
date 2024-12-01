using System;
using Script.Core;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Script.UI
{
    public class InputController : MonoBehaviour
    {
        [SerializeField] UIController uiController;
        [SerializeField] Button pauseButton;
        [SerializeField] Button resumeButton;
        [SerializeField] Button settingsButton;
        [SerializeField] Button exitFromPauseMenuButton;
        [SerializeField] Button restartButton;
        [SerializeField] Button exitFromDeathMenuButton;
        [SerializeField] Button exitFromSettingsMenuButton;

        private Health _health;

        [Inject]
        public void Construct(Health health)
        {
            _health = health;
        }

        private void Start()
        {
            pauseButton.onClick.AddListener(uiController.OpenPauseMenu);
            resumeButton.onClick.AddListener(uiController.OpenHudMenu);
            settingsButton.onClick.AddListener(uiController.OpenSettingsMenu);
            exitFromPauseMenuButton.onClick.AddListener(uiController.LoadMainMenu);
            restartButton.onClick.AddListener(uiController.RestartGame);
            exitFromDeathMenuButton.onClick.AddListener(uiController.LoadMainMenu);
            exitFromSettingsMenuButton.onClick.AddListener(uiController.OpenPauseMenu);
            
            _health.OnDeath += OpenDeathMenu;
        }

        private void OpenDeathMenu()
        {
            uiController.OpenDeathMenu();
        }

        private void OnDisable()
        {
            _health.OnDeath -= OpenDeathMenu;
        }
    }
}
