using DaftAppleGames.Attributes;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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
            _audioSource = themeController.GetComponent<AudioSource>();
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
    }
}