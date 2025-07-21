#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#else
using DaftAppleGames.Attributes;
#endif
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace DaftAppleGames.UserInterface.MainMenu
{
    /// <summary>
    /// Window class implementation of a simple "Main Menu"
    /// Hook UI events into methods of the MainMenuController class.
    /// </summary>
    public class MainMenuUiController : Window
    {
        [BoxGroup("UI Settings")] [SerializeField] private Button startButton;
        [BoxGroup("UI Settings")] [SerializeField] private Button settingsButton;
        [BoxGroup("UI Settings")] [SerializeField] private Button loadButton;
        [BoxGroup("UI Settings")] [SerializeField] private Button exitDesktopButton;

        [BoxGroup("UI Events")] [SerializeField] private UnityEvent onStartButtonClickEvent;
        [BoxGroup("UI Events")] [SerializeField] private UnityEvent onSettingsButtonClickEvent;
        [BoxGroup("UI Events")] [SerializeField] private UnityEvent onLoadButtonClickEvent;
        [BoxGroup("UI Events")] [SerializeField] private UnityEvent onExitToDesktopButtonClickEvent;

        protected override void OnEnable()
        {
            base.OnEnable();
            startButton?.onClick.AddListener(StartButtonClick);
            settingsButton?.onClick.AddListener(SettingsButtonClick);
            loadButton?.onClick.AddListener(LoadButtonClick);
            exitDesktopButton?.onClick.AddListener(ExitButtonClick);
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            startButton?.onClick.RemoveListener(StartButtonClick);
            settingsButton?.onClick.RemoveListener(SettingsButtonClick);
            loadButton?.onClick.RemoveListener(LoadButtonClick);
            exitDesktopButton?.onClick.RemoveListener(ExitButtonClick);
        }
        
        private void StartButtonClick()
        {
            onStartButtonClickEvent?.Invoke();
        }

        private void SettingsButtonClick()
        {
            Close();
            onSettingsButtonClickEvent?.Invoke();
        }

        private void LoadButtonClick()
        {
            onLoadButtonClickEvent?.Invoke();
        }

        private void ExitButtonClick()
        {
            onExitToDesktopButtonClickEvent?.Invoke();
        }
    }
}