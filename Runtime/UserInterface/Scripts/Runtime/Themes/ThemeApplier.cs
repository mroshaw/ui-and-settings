using DaftAppleGames.Attributes;
using DaftAppleGames.Extensions;
#if UNITY_EDITOR
using UnityEditor.Events;
#endif
using UnityEngine;
using UnityEngine.Events;

namespace DaftAppleGames.UserInterface.Themes
{
    /// <summary>
    /// Base class for classes that apply an element of the overall theme
    /// </summary>
    public abstract class ThemeApplier : MonoBehaviour
    {
        [BoxGroup("Settings")] [SerializeField] private ThemeControlSubType controlSubType;
        private ElementTheme _elementTheme;

        [SerializeField] private ThemeController themeController;
        private AudioSource _audioSource;

        private void Awake()
        {
            if (!themeController)
            {
                Debug.Log($"Theme Controller not set on ThemeApplier: {gameObject.name}");
                return;
            }

            _audioSource = themeController.EnsureComponent<AudioSource>();
        }

        internal void SetThemeController(ThemeController newThemeController)
        {
            themeController = newThemeController;
#if UNITY_EDITOR
            UnityEditor.EditorUtility.SetDirty(this);
            UnityEditor.PrefabUtility.RecordPrefabInstancePropertyModifications(this);
#endif
        }

        public void SetTheme(Theme theme, ThemeController newThemeController)
        {
            themeController = newThemeController;
#if UNITY_EDITOR
            UnityEditor.PrefabUtility.RecordPrefabInstancePropertyModifications(this);
            UnityEditor.EditorUtility.SetDirty(this);
#endif

            ElementTheme elementTheme = theme.GetElementTheme(controlSubType);
            ApplyTheme(elementTheme);
        }

        protected abstract void ApplyTheme(ElementTheme theme);


        protected void PlayClip(AudioClip clip)
        {
            _audioSource.PlayOneShot(clip);
        }

#if UNITY_EDITOR
        
        protected void RemoveNamedPersistentListener(UnityEventBase unityEvent, string methodName)
        {
            for (int i = unityEvent.GetPersistentEventCount() - 1; i >= 0; i--)
            {
                if (unityEvent.GetPersistentMethodName(i) == methodName && unityEvent.GetPersistentTarget(i) == this)
                {
                    UnityEventTools.RemovePersistentListener(unityEvent, i);
                }
            }
        }
#endif
    }
}