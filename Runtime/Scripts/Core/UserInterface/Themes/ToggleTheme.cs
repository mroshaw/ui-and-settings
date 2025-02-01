#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#else
using DaftAppleGames.Attributes;
#endif
using System;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;

namespace DaftAppleGames.UserInterface.Themes
{
    [Serializable]
    [CreateAssetMenu(fileName = "ToggleTheme", menuName = "Daft Apple Games/User Interface/Toggle Theme")]
    public class ToggleTheme : SelectableTheme
    {
        [BoxGroup("Image")] public Texture highlightedFrameTexture;
        [BoxGroup("Image")] public Texture uncheckedTexture;
        [BoxGroup("Image")] public Texture checkedTexture;
        [BoxGroup("Image")] public Texture disabledTexture;
        [BoxGroup("Text")] public TextTheme labelTextTheme;
    }
}