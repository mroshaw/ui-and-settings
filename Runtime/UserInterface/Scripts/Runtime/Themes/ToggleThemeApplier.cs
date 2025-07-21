#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.Events;
#endif
using UnityEngine;
using UnityEngine.UI;

namespace DaftAppleGames.UserInterface.Themes
{
    public class ToggleThemeApplier : SelectableThemeApplier
    {
        [HideInInspector] [SerializeField] private ToggleTheme toggleTheme;
        [HideInInspector] [SerializeField] private Toggle toggle;

        protected override void ApplyTheme(ElementTheme elementTheme)
        {
            base.ApplyTheme(elementTheme);

            if (elementTheme is not ToggleTheme newToggleTheme)
            {
                return;
            }

            toggleTheme = newToggleTheme;
            toggle = GetComponent<Toggle>();
            toggleTheme.Apply(toggle);

            AddAudioListeners();
        }

        private void AddAudioListeners()
        {
#if UNITY_EDITOR
            RemoveNamedPersistentListener(toggle.onValueChanged, nameof(ClickHandler));
            UnityEventTools.AddPersistentListener(toggle.onValueChanged, ClickHandler);
            EditorUtility.SetDirty(toggle);
            PrefabUtility.RecordPrefabInstancePropertyModifications(toggle);
#else
            _toggle.onValueChanged.RemoveListener(ClickHandler);
            _toggle.onValueChanged.AddListener(ClickHandler);
#endif
        }

        private void ClickHandler(bool arg0)
        {
            PlayClip(toggleTheme.BaseAudioTheme.ClickedClip);
        }
    }
}