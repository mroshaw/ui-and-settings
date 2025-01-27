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
    public class MainMenuUiWindow : BaseUiWindow
    {
        [BoxGroup("UI Settings")] [SerializeField] private Button startButton;
        [BoxGroup("UI Settings")] [SerializeField] private Button optionsButton;
        [BoxGroup("UI Settings")] [SerializeField] private Button loadButton;
        [BoxGroup("UI Settings")] [SerializeField] private Button exitDesktopButton;
        [BoxGroup("UI Settings")] [SerializeField] private Button debugButton;
        
        [BoxGroup("Proxy UI Events")] [SerializeField] private UnityEvent onStartButtonClickEvent;
        [BoxGroup("Proxy UI Events")] [SerializeField] private UnityEvent onOptionsButtonClickEvent;
        [BoxGroup("Proxy UI Events")] [SerializeField] private UnityEvent onLoadButtonClickEvent;
        [BoxGroup("Proxy UI Events")] [SerializeField] private UnityEvent onExitToDesktopButtonClickEvent;
        [BoxGroup("Proxy UI Events")] [SerializeField] private UnityEvent onDebugButtonClickEvent;

        public override void Start()
        {
            base.Start();
        }

        public void StartButtonProxy()
        {
            onStartButtonClickEvent.Invoke();
        }

        public void OptionsButtonProxy()
        {
            onOptionsButtonClickEvent.Invoke();
        }

        public void LoadButtonProxy()
        {
            onLoadButtonClickEvent.Invoke();
        }

        public void ExitButtonProxy()
        {
            onExitToDesktopButtonClickEvent.Invoke();
        }

        public void DebugButtonProxy()
        {
            onDebugButtonClickEvent.Invoke();
        }

        public void SetToggleButtonState(bool state)
        {
            debugButton.gameObject.SetActive(state);
        }
    }
}