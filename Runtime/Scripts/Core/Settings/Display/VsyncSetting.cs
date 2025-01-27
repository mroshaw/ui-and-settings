using System;
using UnityEngine;

namespace DaftAppleGames.Settings.Display
{
    [Serializable]
    public class VsyncSetting : BoolSetting
    {
        protected override string GetStorageName()
        {
            return "VSync";
        }

        public override string GetDisplayName()
        {
            return "V Sync";
        }

        public override void Apply()
        {

        }

        protected override bool GetDefault()
        {
            return true;
        }
    }
}