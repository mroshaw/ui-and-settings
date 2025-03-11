using TMPro;
using UnityEditor.Events;
using UnityEngine;
using UnityEngine.UI;

namespace DaftAppleGames.UserInterface.Themes
{
    public abstract class SelectableThemeApplier : ThemeApplier
    {
        protected virtual void ApplyAudioTheme(Selectable selectable, ElementTheme elementTheme)
        {
#if UNITY_EDITOR
            // UnityEventTools.RemovePersistentListener(selectable.o, PlayClick);
            // UnityEventTools.AddPersistentListener(selectable.onClick, PlayClick);
#else
            button.onClick.RemoveListener(PlayClick);
            button.onClick.AddListener(PlayClick);
#endif
        }
    }
}