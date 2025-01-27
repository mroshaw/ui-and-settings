using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace DaftAppleGames.Settings.Audio
{
    [CreateAssetMenu(fileName = "MusicVolumeSettingSO", menuName = "Daft Apple Games/Settings/Audio/Music Volume Setting", order = 1)]
    [Serializable]
    public class MusicVolumeSetting : MixerGroupVolumeSetting
    {
        [SerializeField] private AudioMixer audioMixer;

        protected override string GetStorageName()
        {
            return "MusicVolume";
        }

        public override string GetDisplayName()
        {
            return "Music Volume";
        }

        protected override AudioMixer GetAudioMixer()
        {
            return audioMixer;
        }

        protected override string GetAudioMixerGroupParameter()
        {
            return "MusicVolume";
        }
    }
}