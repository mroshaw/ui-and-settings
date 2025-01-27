#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#else
using DaftAppleGames.Attributes;
#endif
using UnityEngine;

namespace DaftAppleGames.UserInterface
{
    [CreateAssetMenu(fileName = "InfoPanelContent", menuName = "Game/InfoPanel Content", order = 1)]
    public class InfoPanelContent : ScriptableObject
    {
        // Public serializable properties
        [BoxGroup("Content")] public string heading;
        [BoxGroup("Content")] [Multiline(10)] public string content;
        [BoxGroup("Content")] public Sprite image;
    }
}