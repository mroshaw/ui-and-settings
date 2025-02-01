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
    [CreateAssetMenu(fileName = "SliderTheme", menuName = "Daft Apple Games/User Interface/Slider Theme")]
    public class SliderTheme : SelectableTheme
    {
        [BoxGroup("Image")] public Texture highlightedFrameTexture;
        [BoxGroup("Image")] public Texture disabledTexture;
        [BoxGroup("Image")] public Texture sliderHandleTexture;
        [BoxGroup("Image")] public Texture sliderBackgroundTexture;
        [BoxGroup("Text")] public TextTheme labelTextTheme;
    }
}