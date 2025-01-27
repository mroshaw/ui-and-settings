using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace DaftAppleGames.Settings.Audio
{
    [Serializable]
    public class AmbientFXVolumeSetting : MixerGroupVolumeSetting
    {
        [SerializeField] private AudioMixer audioMixer;

        protected override string GetStorageName()
        {
            return "AmbientFXVolume";
        }

        public override string GetDisplayName()
        {
            return "Ambient FX Volume";
        }

        protected override AudioMixer GetAudioMixer()
        {
            return audioMixer;
        }

        protected override string GetAudioMixerGroupParameter()
        {
            return "AmbientFXVolume";
        }
    }
}