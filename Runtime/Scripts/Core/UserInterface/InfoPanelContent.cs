#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#else
using DaftAppleGames.Attributes;
#endif
using UnityEngine;

namespace DaftAppleGames.UserInterface
{
    /// <summary>
    /// ScriptableObject that contains the definition of InfoPanel content
    /// </summary>
    [CreateAssetMenu(fileName = "InfoPanelContent", menuName = "Game/InfoPanel Content", order = 1)]
    public class InfoPanelContent : ScriptableObject
    {
        [BoxGroup("Text Content")] public string heading;
        [BoxGroup("Text Content")] [Multiline(10)] public string content;
        [BoxGroup("Image Content")] public Sprite image;
    }
}