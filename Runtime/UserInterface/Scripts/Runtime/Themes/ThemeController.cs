using UnityEditor;
#if UNITY_EDITOR
using UnityEditor.Events;
#endif
using UnityEngine;
using UnityEngine.UI;
#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#else
using DaftAppleGames.Attributes;
#endif

namespace DaftAppleGames.UserInterface.Themes
{
    /// <summary>
    /// Applies selected theme to all ThemeAppliers in the Game Object hierarchy
    /// </summary>
    public class ThemeController : MonoBehaviour
    {
        [InlineEditor] [BoxGroup("Theme Settings")] [SerializeField] private Theme theme;
        [BoxGroup("Theme Settings")] [SerializeField] private bool applyThemeAtStart;
        [BoxGroup("Controls")] [SerializeField] private ThemeApplier[] themeAppliers;

        private void Start()
        {
            if (applyThemeAtStart)
            {
                ApplyTheme();
            }
        }

        [Button("Apply Theme Now")]
        private void ApplyTheme()
        {
            foreach (ThemeApplier applier in themeAppliers)
            {
                if (!applier)
                {
                    Debug.LogError($"Theme Applier is null on {applier.transform.parent.name}");
                    continue;
                }

                applier.SetTheme(theme, this);
            }

            Debug.Log($"Applied Theme: {theme.name} to {themeAppliers.Length} UI controls");
        }

        [Button("Refresh Theme Appliers")]
        private void RefreshThemeAppliers()
        {
            themeAppliers = GetComponentsInChildren<ThemeApplier>(true);
            InitThemeAppliers();
        }

        private void InitThemeAppliers()
        {
            foreach (ThemeApplier applier in themeAppliers)
            {
                applier.SetThemeController(this);
            }
        }

#if UNITY_EDITOR
        [Button("Remove All Persistent Listeners")]
        private void ClearHandlers()
        {
            Button[] allButtons = GetComponentsInChildren<Button>(true);

            foreach (Button button in allButtons)
            {
                SerializedObject serializedButton = new SerializedObject(button);
                SerializedProperty onClickProperty = serializedButton.FindProperty("m_OnClick");

                Debug.Log($"Removing listeners from: {button.name}");

                int count = onClickProperty.FindPropertyRelative("m_PersistentCalls.m_Calls").arraySize;
                for (int i = count - 1; i >= 0; i--)
                {
                    UnityEventTools.RemovePersistentListener(button.onClick, i);
                }

                Debug.Log($"Removed {count} listeners");
            }
        }
#endif
    }
}