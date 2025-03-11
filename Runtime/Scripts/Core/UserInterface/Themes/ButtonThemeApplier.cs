using TMPro;
using UnityEditor.Events;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace DaftAppleGames.UserInterface.Themes
{
    public class ButtonThemeApplier : ThemeApplier, ISelectHandler
    {
        private Button _button;
        private ButtonTheme _buttonTheme;
        protected override void ApplyTheme(ElementTheme elementTheme)
        {
            if (elementTheme is not ButtonTheme buttonTheme)
            {
                return;
            }

            _buttonTheme = buttonTheme;
            Button button = GetComponent<Button>();
            _button = button;
            buttonTheme.Apply(button);
            ApplyAudioTheme();
        }

        protected virtual void ApplyAudioTheme()
        {
#if UNITY_EDITOR
            UnityEventTools.RemovePersistentListener(_button.onClick, PlayClick);

            UnityEventTools.AddPersistentListener(_button.onClick, PlayClick);
#else
            button.onClick.RemoveListener(PlayClick);
            button.onClick.AddListener(PlayClick);
#endif
        }

        private void PlayClick()
        {
            PlayClip(_buttonTheme.baseAudioTheme.clickedClip);
        }

        public void OnSelect(BaseEventData eventData)
        {
            // PlayClip(_buttonTheme.baseAudioTheme.selectedClip);
        }
    }
}