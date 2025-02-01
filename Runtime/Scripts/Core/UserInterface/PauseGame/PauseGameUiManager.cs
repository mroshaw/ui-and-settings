#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#else
using DaftAppleGames.Attributes;
#endif
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace DaftAppleGames.UserInterface.PauseGame
{
    public class PauseGameUiManager : Window
    {
        [BoxGroup("UI Settings")] [SerializeField] private Button continueButton;
        [BoxGroup("UI Settings")] [SerializeField] private Button settingsButton;
        [BoxGroup("UI Settings")] [SerializeField] private Button loadButton;
        [BoxGroup("UI Settings")] [SerializeField] private Button saveButton;
        [BoxGroup("UI Settings")] [SerializeField] private Button mainMenuButton;
        [BoxGroup("UI Settings")] [SerializeField] private Button exitDesktopButton;

        [BoxGroup("UI Events")] [SerializeField] private UnityEvent onContinueButtonClickEvent;
        [BoxGroup("UI Events")] [SerializeField] private UnityEvent onSettingsButtonClickEvent;
        [BoxGroup("UI Events")] [SerializeField] private UnityEvent onLoadButtonClickEvent;
        [BoxGroup("UI Events")] [SerializeField] private UnityEvent onSaveButtonClickEvent;
        [BoxGroup("UI Events")] [SerializeField] private UnityEvent onMainMenuButtonClickEvent;
        [BoxGroup("UI Events")] [SerializeField] private UnityEvent onExitToDesktopButtonClickEvent;
        [BoxGroup("I Events")] [SerializeField] private UnityEvent onBackButtonClickEvent;

        protected override void InitHandlers()
        {
            continueButton.onClick.AddListener(ContinueButtonClick);
            settingsButton.onClick.AddListener(SettingsButtonClick);
            loadButton.onClick.AddListener(LoadButtonClick);
            saveButton.onClick.AddListener(SaveButtonClick);
            mainMenuButton.onClick.AddListener(MainMenuButtonClick);
            exitDesktopButton.onClick.AddListener(ExitButtonClick);
        }

        protected override void DeInitHandlers()
        {
            continueButton.onClick.RemoveListener(ContinueButtonClick);
            settingsButton.onClick.RemoveListener(SettingsButtonClick);
            loadButton.onClick.RemoveListener(LoadButtonClick);
            saveButton.onClick.RemoveListener(SaveButtonClick);
            mainMenuButton.onClick.RemoveListener(MainMenuButtonClick);
            exitDesktopButton.onClick.RemoveListener(ExitButtonClick);
        }

        private void ContinueButtonClick()
        {
            Close();
            onContinueButtonClickEvent.Invoke();
        }

        private void SettingsButtonClick()
        {
            Close();
            onSettingsButtonClickEvent.Invoke();
        }

        private void LoadButtonClick()
        {
            onLoadButtonClickEvent.Invoke();
        }

        private void SaveButtonClick()
        {
            onSaveButtonClickEvent.Invoke();
        }

        private void MainMenuButtonClick()
        {
            Close();
            onMainMenuButtonClickEvent.Invoke();
        }
        
        private void ExitButtonClick()
        {
            Close();
            onExitToDesktopButtonClickEvent.Invoke();
        }
    }
}