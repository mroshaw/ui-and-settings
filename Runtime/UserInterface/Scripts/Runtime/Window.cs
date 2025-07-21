using System.Collections;
using UnityEngine;
#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#else
using DaftAppleGames.Attributes;
#endif
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

namespace DaftAppleGames.UserInterface
{
    /// <summary>
    /// Class to underpin all UI window components
    /// </summary>
    public abstract class Window : MonoBehaviour
    {
        [BoxGroup("Window UI Settings")] [SerializeField] private Canvas uiCanvas;
        [BoxGroup("Window UI Settings")] [SerializeField] private bool defaultUiState;
        [BoxGroup("Window UI Settings")] [SerializeField] private GameObject startSelectedGameObject;
        [BoxGroup("Window UI Settings")] [SerializeField] private float fadeTimeInSeconds=2.0f;
        [BoxGroup("Debug")] [SerializeField] private bool isUiOpen;
        [FoldoutGroup("Show Events")] [SerializeField] public UnityEvent onOpenEvent;
        [FoldoutGroup("Hide Events")] [SerializeField] public UnityEvent onCloseEvent;

        public bool IsUiOpen => isUiOpen;

        private static PlayerInput _playerInput;
        private static string _controlScheme;

        private bool _isCursorVisible;
        private CursorLockMode _cursorLockMode;

        private CanvasGroup _uiCanvasGroup;

        protected virtual void OnEnable()
        {
            // Subscribe to input changed
            StartCoroutine(FindPlayerInputAsync());
        }

        protected virtual void OnDisable()
        {
            if (_playerInput)
            {
                _playerInput.controlsChangedEvent.RemoveListener(ControlSchemeChangedHandler);
            }
        }

        private IEnumerator FindPlayerInputAsync()
        {
            while (!_playerInput)
            {
                _playerInput = FindFirstObjectByType<PlayerInput>();
                yield return null;
            }
            _playerInput.controlsChangedEvent.RemoveListener(ControlSchemeChangedHandler);
            _playerInput.controlsChangedEvent.AddListener(ControlSchemeChangedHandler);
        }

        public virtual void Awake()
        {
            _uiCanvasGroup = GetComponent<CanvasGroup>();
            // Subscribe to input changed
            StartCoroutine(FindPlayerInputAsync());
        }

        public virtual void Start()
        {
            // Register with controller
            if (WindowManager.Instance)
            {
                WindowManager.Instance.RegisterUiWindow(this);
            }

            if (startSelectedGameObject && !EventSystem.current.firstSelectedGameObject)
            {
                EventSystem.current.firstSelectedGameObject = startSelectedGameObject;
            }

            // Start with UI in specified default state
            SetUiState(defaultUiState, false);
        }

        private void OnDestroy()
        {
            if (WindowManager.Instance)
            {
                WindowManager.Instance.UnRegisterUiWindow(this);
            }
        }

        private void ControlSchemeChangedHandler(PlayerInput playerInput)
        {
            Debug.Log($"Control scheme changed to: {playerInput.currentControlScheme}");

            _controlScheme = playerInput.currentControlScheme;

            if (isUiOpen)
            {
                SetCursorState();
            }
        }

        private void SetCursorState()
        {
            if (_controlScheme == "Gamepad")
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
            }
            else
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }

        public void ToggleUiState()
        {
            SetUiState(!isUiOpen, true);
        }

        public virtual void Open()
        {
            if (IsUiOpen)
            {
                return;
            }
            if (_uiCanvasGroup)
            {
                StartCoroutine(FadeCanvas(true));
                return;
            }
            else
            {
                Debug.Log($"Window: No CanvasGroup found on: {gameObject.name}");
            }
            // Enable the UI panel and set Event content
            SetUiState(true, true);
        }

        protected virtual void Close()
        {
            if (_uiCanvasGroup)
            {
                StartCoroutine(FadeCanvas(false));
                return;
            }

            // Disable the UI panel
            SetUiState(false, true);
        }

        private IEnumerator FadeCanvas(bool isFadeIn)
        {
            float time = 0;

            float startAlpha = isFadeIn ? 0 : 1;
            float endAlpha = isFadeIn ? 1 : 0;
            _uiCanvasGroup.alpha = startAlpha;
            _uiCanvasGroup.interactable = false;
            // Fade in, so enable
            if (isFadeIn)
            {
                SetUiState(true, true);
            }

            while (time < fadeTimeInSeconds)
            {
                _uiCanvasGroup.alpha = Mathf.Lerp(startAlpha, endAlpha, time / fadeTimeInSeconds);
                time += Time.unscaledDeltaTime;
                yield return null;
            }

            _uiCanvasGroup.alpha = endAlpha;

            // Fade out, so disable
            if (!isFadeIn)
            {
                SetUiState(false, true);
            }

            _uiCanvasGroup.interactable = true;
        }

        private void SetUiState(bool state, bool triggerEvents)
        {
            uiCanvas.gameObject.SetActive(state);
            isUiOpen = state;

            if (state)
            {
                if (startSelectedGameObject)
                {
                    EventSystem.current.SetSelectedGameObject(startSelectedGameObject);
                }

                SetCursorState();

                if (triggerEvents)
                {
                    onOpenEvent.Invoke();
                }
            }
            else
            {
                // Restore cursor state, if all windows closed
                if (!WindowManager.Instance.IsAnyUiOpen)
                {
                    Cursor.visible = false;
                    Cursor.lockState = CursorLockMode.None;
                }

                if (triggerEvents)
                {
                    onCloseEvent.Invoke();
                }
            }
        }
    }
}