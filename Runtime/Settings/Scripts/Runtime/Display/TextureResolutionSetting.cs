using System;
using System.Collections.Generic;
using UnityEngine;

namespace DaftAppleGames.Settings.Display
{
    [CreateAssetMenu(fileName = "TextureResolutionSettingSO", menuName = "Daft Apple Games/Settings/Display/Texture Resolution Setting", order = 1)]
    [Serializable]
    public class TextureResolutionSetting : OptionSetting
    {
        protected override string GetStorageName()
        {
            return "TextureRes";
        }

        public override string GetDisplayName()
        {
            return "Texture Resolution";
        }

        public override void Apply()
        {
            QualitySettings.globalTextureMipmapLimit = Value;
        }

        protected override int GetDefault()
        {
            return 0;
        }

        public override List<string> GetOptions()
        {
            List<string> options = new() { "Full", "Half", "Quarter", "Eighth" };
            return options;
        }
    }
}