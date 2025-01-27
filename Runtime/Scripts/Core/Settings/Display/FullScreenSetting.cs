using System;
using UnityEngine;

namespace DaftAppleGames.Settings.Display
{
    [Serializable]
    public class FullScreenSetting : BoolSetting
    {
        protected override string GetStorageName()
        {
            return "DisplayFullScreen";
        }

        public override string GetDisplayName()
        {
            return "Full Screen";
        }

        protected override void Apply()
        {
            Screen.fullScreen = Value;
        }

        protected override bool GetDefault()
        {
            return true;
        }
    }
}