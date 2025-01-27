#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#else
using DaftAppleGames.Attributes;
#endif
using System;

namespace DaftAppleGames.Settings.Audio
{
    [Serializable]
    public class AudioSettings: Settings
    {
        protected override string GetStorageName()
        {
            return "Audio";
        }

        protected override string GetDisplayName()
        {
            return "Audio";
        }

        public MasterVolumeSetting masterVolume;
        public MusicVolumeSetting musicVolume;
        public SoundFXVolumeSetting soundFXVolume;
        public AmbientFXVolumeSetting ambientFXVolume;
        
    }
}