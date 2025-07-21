using UnityEditor;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor.Events;
#endif
using UnityEngine.UI;

namespace DaftAppleGames.UserInterface.Themes
{
    public class ButtonThemeApplier : SelectableThemeApplier
    {
        [HideInInspector] [SerializeField] private Button button;
        [HideInInspector] [SerializeField] private ButtonTheme buttonTheme;

        protected override void ApplyTheme(ElementTheme elementTheme)
        {
            base.ApplyTheme(elementTheme);

            if (elementTheme is not ButtonTheme newButtonTheme)
            {
                return;
            }

            buttonTheme = newButtonTheme;
            button = GetComponent<Button>();

            AddAudioListeners();
        }

        private void AddAudioListeners()
        {
#if UNITY_EDITOR
            UnityEventTools.RemovePersistentListener(button.onClick, PlayClick);
            UnityEventTools.AddPersistentListener(button.onClick, PlayClick);
            EditorUtility.SetDirty(button);
            PrefabUtility.RecordPrefabInstancePropertyModifications(button);
#else
            _button.onClick.RemoveListener(PlayClick);
            _button.onClick.AddListener(PlayClick);
#endif
        }

        private void PlayClick()
        {
            PlayClip(buttonTheme.BaseAudioTheme.ClickedClip);
        }
    }
}