using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace DaftAppleGames.Settings.Audio
{
    [CreateAssetMenu(fileName = "MasterVolumeSettingSO", menuName = "Daft Apple Games/Settings/Audio/Master Volume Setting", order = 1)]
    [Serializable]
    public class MasterVolumeSetting : MixerGroupVolumeSetting
    {
        [SerializeField] private AudioMixer audioMixer;

        protected override string GetStorageName()
        {
            return "MasterVolume";
        }

        public override string GetDisplayName()
        {
            return "Master Volume";
        }

        protected override AudioMixer GetAudioMixer()
        {
            return audioMixer;
        }

        protected override string GetAudioMixerGroupParameter()
        {
            return "UserMasterVolume";
        }
    }
}