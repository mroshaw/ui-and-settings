using System;
using System.Collections.Generic;
using UnityEngine;

namespace DaftAppleGames.Settings.Display
{
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