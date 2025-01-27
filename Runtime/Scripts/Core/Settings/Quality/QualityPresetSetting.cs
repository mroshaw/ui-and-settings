using System;
using System.Collections.Generic;
using UnityEngine;

namespace DaftAppleGames.Settings.Quality
{
    [CreateAssetMenu(fileName = "QualityPresetSettingSO", menuName = "Daft Apple Games/Settings/Quality/Quality Preset Setting", order = 1)]
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

        public override void Apply()
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