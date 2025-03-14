using TMPro;
using UnityEditor;
#if UNITY_EDITOR
using UnityEditor.Events;
#endif
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace DaftAppleGames.UserInterface.Themes
{
    public class ButtonThemeApplier : ThemeApplier, ISelectHandler
    {
        private Button _button;
        [HideInInspector] [SerializeField] private ButtonTheme buttonTheme;
        protected override void ApplyTheme(ElementTheme elementTheme)
        {
            if (elementTheme is not ButtonTheme newButtonTheme)
            {
                return;
            }

            this.buttonTheme = newButtonTheme;
            Button button = GetComponent<Button>();
            _button = button;

#if UNITY_EDITOR
            EditorUtility.SetDirty(this);
            PrefabUtility.RecordPrefabInstancePropertyModifications(this);
#endif

            newButtonTheme.Apply(button);
            ApplyAudioTheme();
        }

        protected virtual void ApplyAudioTheme()
        {
#if UNITY_EDITOR
            UnityEventTools.RemovePersistentListener(_button.onClick, PlayClick);
            UnityEventTools.AddPersistentListener(_button.onClick, PlayClick);
            EditorUtility.SetDirty(_button);
            PrefabUtility.RecordPrefabInstancePropertyModifications(_button);
#else
            _button.onClick.RemoveListener(PlayClick);
            _button.onClick.AddListener(PlayClick);
#endif
        }

        private void PlayClick()
        {
            PlayClip(buttonTheme.baseAudioTheme.clickedClip);
        }

        public void OnSelect(BaseEventData eventData)
        {
            // PlayClip(_buttonTheme.baseAudioTheme.selectedClip);
        }
    }
}