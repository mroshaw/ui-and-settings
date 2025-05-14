#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#else
using DaftAppleGames.Attributes;
#endif
using System;
using UnityEngine;

namespace DaftAppleGames.UserInterface.Themes
{
    /// <summary>
    /// Simple class that allows mapping of a ControlSubType to an Element Theme
    /// </summary>
    [Serializable]
    public class ThemeMapping
    {
        public ThemeControlSubType themeControlSubType;
        [InlineEditor] public ElementTheme elementTheme;

        public ThemeMapping(ThemeControlSubType subType)
        {
            themeControlSubType = subType;
            elementTheme = null;
        }
    }
}