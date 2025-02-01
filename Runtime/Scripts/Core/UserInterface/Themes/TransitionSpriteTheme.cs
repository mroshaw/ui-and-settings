#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#else
using DaftAppleGames.Attributes;
#endif
using UnityEngine;

namespace DaftAppleGames.UserInterface.Themes
{
    [CreateAssetMenu(fileName = "SpriteTheme", menuName = "Daft Apple Games/User Interface/Sprite Theme")]
    public class TransitionSpriteTheme : ScriptableObject
    {
        [BoxGroup("Image")] public Sprite highlightedSprite;
        [BoxGroup("Image")] public Sprite pressedSprite;
        [BoxGroup("Image")] public Sprite selectedSprite;
        [BoxGroup("Image")] public Sprite disabledSprite;
    }
}