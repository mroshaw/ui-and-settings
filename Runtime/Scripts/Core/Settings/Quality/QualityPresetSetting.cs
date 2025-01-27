using System;
using System.Collections.Generic;
using UnityEngine;

namespace DaftAppleGames.Settings.Quality
{
    [Serializable]
    public class QualityPresetSetting : OptionSetting
    {
        protected override string GetStorageName()
        {
            return "QualityPreset";
        }

        public override string GetDisplayName()
        {
            return "Quality Preset";
        }

        protected override void Apply()
        {

        }

        protected override int GetDefault()
        {
            return 0;
        }

        public override List<string> GetOptions()
        {
            List<string> options = new();
            return options;
        }
    }
}