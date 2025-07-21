using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace DaftAppleGames.Settings.Audio
{
    [CreateAssetMenu(fileName = "SoundFXVolumeSettingSO", menuName = "Daft Apple Games/Settings/Audio/Sound FX Volume Setting", order = 1)]
    [Serializable]
    public class SoundFXVolumeSetting : MixerGroupVolumeSetting
    {
        [SerializeField] private AudioMixer audioMixer;

        protected override string GetStorageName()
        {
            return "SoundFXVolume";
        }

        public override string GetDisplayName()
        {
            return "Sound FX Volume";
        }

        protected override AudioMixer GetAudioMixer()
        {
            return audioMixer;
        }

        protected override string GetAudioMixerGroupParameter()
        {
            return "SoundFXVolume";
        }
    }
}