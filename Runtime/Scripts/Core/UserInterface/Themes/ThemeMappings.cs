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
    [CreateAssetMenu(fileName = "UserInterfaceThemeMapping", menuName = "Daft Apple Games/User Interface/Theme Control Mappings")]
    public class ThemeMappings : ScriptableObject
    {
        public List<ThemeMapping> themeMappings;

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