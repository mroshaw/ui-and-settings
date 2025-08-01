using System;
using UnityEngine;

namespace DaftAppleGames.Settings.Audio
{
    [CreateAssetMenu(fileName = "AmbientFXVolumeSettingSO", menuName = "Daft Apple Games/Settings/Audio/Ambient FX Volume Setting", order = 1)]
    [Serializable]
    public class AmbientFXVolumeSetting : MixerGroupVolumeSetting
    {
        protected override string GetStorageName()
        {
            return "AmbientFXVolume";
        }

        public override string GetDisplayName()
        {
            return "Ambient FX Volume";
        }
    }
}