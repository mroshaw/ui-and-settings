using System;
using System.Collections.Generic;
using UnityEngine;

namespace DaftAppleGames.Settings.Display
{
    [CreateAssetMenu(fileName = "WindowModeSettingSO", menuName = "Daft Apple Games/Settings/Display/Window Mode Setting", order = 1)]
    [Serializable]
    public class WindowModeSetting : OptionSetting
    {
        protected override string GetStorageName()
        {
            return "WindowMode";
        }

        public override string GetDisplayName()
        {
            return "Window Mode";
        }

        public override void Apply()
        {

        }

        protected override int GetDefault()
        {
            return 1;
        }

        public override List<string> GetOptions()
        {
            List<string> options = new() { "Window", "Fullscreen", "Fullscreen (Exclusive)" };
            return options;
        }
    }
}