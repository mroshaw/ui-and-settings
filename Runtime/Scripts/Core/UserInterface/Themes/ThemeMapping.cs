#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#else
using DaftAppleGames.Attributes;
#endif
using System;
using UnityEngine;

namespace DaftAppleGames.UserInterface.Themes
{
    [Serializable]
    public class ThemeMapping
    {
        public ThemeControlSubType themeControlSubType;
        public ElementTheme elementTheme;

        public ThemeMapping(ThemeControlSubType subType)
        {
            themeControlSubType = subType;
            elementTheme = null;
        }
    }
}