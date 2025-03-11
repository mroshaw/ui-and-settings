using DaftAppleGames.Attributes;
using DaftAppleGames.Extensions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DaftAppleGames.UserInterface.Themes
{
    public abstract class ThemeApplier : MonoBehaviour
    {
        [BoxGroup("Settings")] [SerializeField] ThemeControlSubType controlSubType;
        private ElementTheme _elementTheme;

        private ThemeManager _themeManager;
        private AudioSource _audioSource;

        protected Selectable Selectable { get; set;  }
        protected TMP_Text Text { get; set;  }
        protected bool IsSelectable { get; private set; }
        protected bool IsText { get; private set; }

        private void Awake()
        {
            Selectable = GetComponent<Selectable>();
            IsSelectable = Selectable != null;

            Text = GetComponent<TMP_Text>();
            IsText = Text != null;
        }

        public void SetTheme(Theme theme, ThemeManager themeManager)
        {
            _themeManager = themeManager;
            _audioSource = _themeManager.GetComponent<AudioSource>();

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