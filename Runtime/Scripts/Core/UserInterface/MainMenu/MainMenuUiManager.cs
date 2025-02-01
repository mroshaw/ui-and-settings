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
    public class MainMenuUiManager : Window
    {
        [BoxGroup("UI Settings")] [SerializeField] private Button startButton;
        [BoxGroup("UI Settings")] [SerializeField] private Button settingsButton;
        [BoxGroup("UI Settings")] [SerializeField] private Button loadButton;
        [BoxGroup("UI Settings")] [SerializeField] private Button exitDesktopButton;

        [BoxGroup("UI Events")] [SerializeField] private UnityEvent onStartButtonClickEvent;
        [BoxGroup("UI Events")] [SerializeField] private UnityEvent onSettingsButtonClickEvent;
        [BoxGroup("UI Events")] [SerializeField] private UnityEvent onLoadButtonClickEvent;
        [BoxGroup("UI Events")] [SerializeField] private UnityEvent onExitToDesktopButtonClickEvent;

        protected override void InitHandlers()
        {
            startButton.onClick.AddListener(StartButtonClick);
            settingsButton.onClick.AddListener(SettingsButtonClick);
            loadButton.onClick.AddListener(LoadButtonClick);
            exitDesktopButton.onClick.AddListener(ExitButtonClick);
        }

        protected override void DeInitHandlers()
        {
            startButton.onClick.RemoveListener(StartButtonClick);
            settingsButton.onClick.RemoveListener(SettingsButtonClick);
            loadButton.onClick.RemoveListener(LoadButtonClick);
            exitDesktopButton.onClick.RemoveListener(ExitButtonClick);
        }

        public override void Start()
        {
            base.Start();
        }

        private void StartButtonClick()
        {
            onStartButtonClickEvent.Invoke();
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

        private void ExitButtonClick()
        {
            onExitToDesktopButtonClickEvent.Invoke();
        }
    }
}