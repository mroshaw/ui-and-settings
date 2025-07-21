using System;
using UnityEngine;

namespace DaftAppleGames.Settings.Display
{
    [CreateAssetMenu(fileName = "FullScreenSettingSO", menuName = "Daft Apple Games/Settings/Display/Full Screen Setting", order = 1)]
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

        public override void Apply()
        {
            Screen.fullScreen = Value;
        }

        protected override bool GetDefault()
        {
            return true;
        }
    }
}