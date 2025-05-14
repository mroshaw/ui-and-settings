#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#else
using DaftAppleGames.Attributes;
#endif
using TMPro;
using UnityEngine;
using UnityEngine.Audio;

namespace DaftAppleGames.UserInterface.Themes
{
    public enum ThemeControlSubType { MenuButton, MenuFooterCancelButton, MenuFooterBackButton, MenuFooterConfirmButton, ControlLabel,
        MenuHeadingLabel, MenuSubHeadingLabel, Toggle, Dropdown, Slider, WindowPanel, MenuPanel }

    /// <summary>
    /// Main Scriptable Object class that defines a "Theme"
    /// </summary>
    [CreateAssetMenu(fileName = "Theme", menuName = "Daft Apple Games/User Interface/Theme")]
    public class Theme : ScriptableObject
    {
        [BoxGroup("Settings")] [SerializeField] private string themeName;
        [BoxGroup("Settings")] [InlineEditor] [SerializeField] private ThemeMappings themeMappings;

        public ElementTheme GetElementTheme(ThemeControlSubType subType)
        {
            if (themeMappings.FindMapping(subType, out ThemeMapping theme))
            {
                return theme.elementTheme;
            }
            return null;
        }
    }
}