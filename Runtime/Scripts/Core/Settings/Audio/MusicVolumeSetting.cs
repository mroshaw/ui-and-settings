using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace DaftAppleGames.Settings.Audio
{
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