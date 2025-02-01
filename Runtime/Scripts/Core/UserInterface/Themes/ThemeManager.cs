using DaftAppleGames.UserInterface;
using UnityEngine;
#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#else
using DaftAppleGames.Attributes;
#endif

namespace DaftAppleGames.UserInterface.Themes
{
    public class ThemeManager : MonoBehaviour
    {
        #region Class Variables
        [BoxGroup("Theme Settings")] [SerializeField] private Theme theme;
        [BoxGroup("Theme Settings")] [SerializeField] private bool applyThemeAtStart;
        [BoxGroup("Controls")] [SerializeField] private ThemeApplier[] themeAppliers;
        #endregion

        #region Startup

        private void Start()
        {
            if (applyThemeAtStart)
            {
                ApplyTheme();
            }
        }
        #endregion

        #region Class methods

        [Button("Apply Theme Now")]
        private void ApplyTheme()
        {
            foreach (ThemeApplier applier in themeAppliers)
            {
                applier.SetTheme(theme);
            }
        }

        [Button("Refresh Theme Appliers")]
        private void RefreshThemeAppliers()
        {
            themeAppliers = GetComponentsInChildren<ThemeApplier>(true);
        }
        #endregion
    }
}