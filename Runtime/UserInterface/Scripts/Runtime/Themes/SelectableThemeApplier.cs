#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace DaftAppleGames.UserInterface.Themes
{
    public class SelectableThemeApplier : ThemeApplier, ISelectHandler
    {
        [HideInInspector] [SerializeField] private SelectableTheme selectableTheme;
        [HideInInspector] [SerializeField] private Selectable selectable;

        protected override void ApplyTheme(ElementTheme elementTheme)
        {
            if (elementTheme is not SelectableTheme newSelectableTheme)
            {
                Debug.Log($"{elementTheme} is not a SelectableTheme!");
                return;
            }

            selectableTheme = newSelectableTheme;

            selectable = GetComponent<Selectable>();

#if UNITY_EDITOR
            EditorUtility.SetDirty(this);
            PrefabUtility.RecordPrefabInstancePropertyModifications(this);
#endif

            newSelectableTheme.Apply(selectable);
        }

        /// <summary>
        /// Implement OnSelect to play the Select audio clip
        /// </summary>
        public void OnSelect(BaseEventData eventData)
        {
            if (!selectableTheme.BaseAudioTheme.SelectedClip)
            {
                return;
            }

            PlayClip(selectableTheme.BaseAudioTheme.SelectedClip);
        }
    }
}