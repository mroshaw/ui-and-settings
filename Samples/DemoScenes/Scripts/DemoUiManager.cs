using DaftAppleGames.UserInterface;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#else
using DaftAppleGames.Attributes;
#endif

namespace DaftAppleGames.Settings.Samples
{
    public class DemoUiManager : Window
    {
        [BoxGroup("UI Elements")] [SerializeField] private Button menuButton;
        [BoxGroup("UI Elements")] [SerializeField] private Button pauseButton;
        [BoxGroup("UI Elements")] [SerializeField] private Button settingsButton;

        [BoxGroup("UI Events")] public UnityEvent onMenuButtonClick;
        [BoxGroup("UI Events")] public UnityEvent onPauseButtonClick;
        [BoxGroup("UI Events")] public UnityEvent onSettingsButtonClick;

        protected override void InitHandlers()
        {
            menuButton.onClick.AddListener(MenuButtonClick);
            pauseButton.onClick.AddListener(PauseButtonClick);
            settingsButton.onClick.AddListener(SettingsButtonClick);
        }

        protected override void DeInitHandlers()
        {
            menuButton.onClick.RemoveListener(MenuButtonClick);
            pauseButton.onClick.RemoveListener(PauseButtonClick);
            settingsButton.onClick.RemoveListener(SettingsButtonClick);
        }

        private void MenuButtonClick()
        {
            Close();
            onMenuButtonClick.Invoke();
        }

        private void PauseButtonClick()
        {
            Close();
            onPauseButtonClick.Invoke();
        }

        private void SettingsButtonClick()
        {
            Close();
            onSettingsButtonClick.Invoke();
        }
    }
}