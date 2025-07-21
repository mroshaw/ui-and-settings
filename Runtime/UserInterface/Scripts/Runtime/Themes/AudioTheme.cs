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
        [BoxGroup("Standard Audio")] [SerializeField] private AudioMixerGroup mixerGroup;
        [BoxGroup("Standard Audio")] [SerializeField] private AudioClip selectedClip;
        [BoxGroup("Standard Audio")] [SerializeField] private AudioClip clickedClip;

        internal AudioMixerGroup MixerGroup =>  mixerGroup;
        internal  AudioClip SelectedClip => selectedClip;
        internal AudioClip ClickedClip => clickedClip;
    }
}