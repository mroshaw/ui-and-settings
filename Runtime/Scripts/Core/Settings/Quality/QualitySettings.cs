#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#else
using DaftAppleGames.Attributes;
#endif
using System;

namespace DaftAppleGames.Settings.Quality
{
    [Serializable]
    public class QualitySettings: Settings
    {
        protected override string GetStorageName()
        {
            return "Quality";
        }

        protected override string GetDisplayName()
        {
            return "Quality";
        }
        
        public QualityPresetSetting qualityPreset;

    }
}