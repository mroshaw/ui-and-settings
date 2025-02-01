#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#else
using DaftAppleGames.Attributes;
#endif
using UnityEngine;

namespace DaftAppleGames.UserInterface.Themes
{
    [CreateAssetMenu(fileName = "UserInterfaceColorTheme", menuName = "Daft Apple Games/User Interface/Color Theme")]
    public class TransitionColorTheme : ScriptableObject
    {
        [BoxGroup("Standard Colors")] public Color normalColor;
        [BoxGroup("Standard Colors")] public Color highlightedColor;
        [BoxGroup("Standard Colors")] public Color pressedColor;
        [BoxGroup("Standard Colors")] public Color selectedColor;
        [BoxGroup("Standard Colors")] public Color disabledColor;
        [BoxGroup("Standard Colors")] public float colorMultiplier = 1.0f;
        [BoxGroup("Standard Colors")] public float fadeDuration = 0.5f;
    }
}