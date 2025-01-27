using System;
using System.Collections.Generic;
using UnityEngine;

namespace DaftAppleGames.Settings.Display
{
    [Serializable]
    public class FrameRateSetting : OptionSetting
    {
        protected override string GetStorageName()
        {
            return "FrameRate";
        }

        public override string GetDisplayName()
        {
            return "Frame Rate";
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