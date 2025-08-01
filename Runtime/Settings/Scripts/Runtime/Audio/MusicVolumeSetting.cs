using System;
using UnityEngine;

namespace DaftAppleGames.Settings.Audio
{
    [CreateAssetMenu(fileName = "MusicVolumeSettingSO", menuName = "Daft Apple Games/Settings/Audio/Music Volume Setting", order = 1)]
    [Serializable]
    public class MusicVolumeSetting : MixerGroupVolumeSetting
    {
        protected override string GetStorageName()
        {
            return "MusicVolume";
        }

        public override string GetDisplayName()
        {
            return "Music Volume";
        }


    }
}