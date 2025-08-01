using System;
using UnityEngine;

namespace DaftAppleGames.Settings.Audio
{
    [CreateAssetMenu(fileName = "MasterVolumeSettingSO", menuName = "Daft Apple Games/Settings/Audio/Master Volume Setting", order = 1)]
    [Serializable]
    public class MasterVolumeSetting : MixerGroupVolumeSetting
    {
        protected override string GetStorageName()
        {
            return "MasterVolume";
        }

        public override string GetDisplayName()
        {
            return "Master Volume";
        }
    }
}