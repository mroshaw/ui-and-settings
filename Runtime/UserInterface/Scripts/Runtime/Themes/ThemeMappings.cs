#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#else
using DaftAppleGames.Attributes;
#endif
using System;
using System.Collections.Generic;
using UnityEngine;

namespace DaftAppleGames.UserInterface.Themes
{
    /// <summary>
    /// Brings together all ThemeMapping scriptable object instances into a single "Theme"
    /// </summary>
    [CreateAssetMenu(fileName = "UserInterfaceThemeMapping", menuName = "Daft Apple Games/User Interface/Theme Control Mappings")]
    public class ThemeMappings : ScriptableObject
    {
        [SerializeField] private List<ThemeMapping> themeMappings;

        /// <summary>
        /// Creates an "empty" instance with placeholders for each known Theme Control Subtype
        /// </summary>
        [Button("Initialize")]
        private void Init()
        {
            foreach(ThemeControlSubType subType in Enum.GetValues(typeof(ThemeControlSubType)))
            {
                if(!FindMapping(subType, out ThemeMapping foundMapping))
                {
                    themeMappings.Add(new ThemeMapping(subType));
                }
            }
        }

        /// <summary>
        /// Attempts to find a mapping for the given ThemeControlSubType
        /// </summary>
        public bool FindMapping(ThemeControlSubType subType, out ThemeMapping foundMapping)
        {
            foreach (ThemeMapping mapping in themeMappings)
            {
                if (mapping.themeControlSubType == subType)
                {
                    foundMapping = mapping;
                    return true;
                }
            }
            foundMapping = null;
            return false;
        }
    }
}