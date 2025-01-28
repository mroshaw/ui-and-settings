using System;
using System.Collections.Generic;
using System.Linq;
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
            QualitySettings.SetQualityLevel(Value);
        }

        protected override int GetDefault()
        {
            return QualitySettings.names.ToList().IndexOf("High Fidelity");;
        }

        public override List<string> GetOptions()
        {
            List<string> options = new();

            foreach (string qualitySetting in QualitySettings.names)
            {
                options.Add(qualitySetting);
            }
            return options;
        }
    }
}