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
    /// Base scriptable object for UI theme elements
    /// </summary>
    [Serializable]
    public class ElementTheme : ScriptableObject
    {
    }
}