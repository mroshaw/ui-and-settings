using System;
using UnityEngine;

namespace DaftAppleGames.Settings.Audio
{
    [CreateAssetMenu(fileName = "SoundFXVolumeSettingSO", menuName = "Daft Apple Games/Settings/Audio/Sound FX Volume Setting", order = 1)]
    [Serializable]
    public class SoundFXVolumeSetting : MixerGroupVolumeSetting
    {
        protected override string GetStorageName()
        {
            return "SoundFXVolume";
        }

        public override string GetDisplayName()
        {
            return "Sound FX Volume";
        }
    }
}