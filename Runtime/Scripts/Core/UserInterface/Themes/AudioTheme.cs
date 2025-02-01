#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#else
using DaftAppleGames.Attributes;
#endif
using UnityEngine;
using UnityEngine.Audio;

namespace DaftAppleGames.UserInterface.Themes
{
    [CreateAssetMenu(fileName = "UserInterfaceAudioTheme", menuName = "Daft Apple Games/User Interface/Audio Theme")]
    public class AudioTheme : ElementTheme
    {
        [BoxGroup("Standard Audio")] public AudioMixerGroup mixerGroup;
        [BoxGroup("Standard Audio")] public AudioClip selectedClip;
        [BoxGroup("Standard Audio")] public AudioClip clickedClip;
    }
}