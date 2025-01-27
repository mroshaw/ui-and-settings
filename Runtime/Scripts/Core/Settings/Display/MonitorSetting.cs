using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DaftAppleGames.Settings.Display
{
    [CreateAssetMenu(fileName = "MonitorSettingSO", menuName = "Daft Apple Games/Settings/Display/Monitor Setting", order = 1)]
    [Serializable]
    public class MonitorSetting : OptionSetting
    {
        protected override string GetStorageName()
        {
            return "Monitor";
        }

        public override string GetDisplayName()
        {
            return "Monitor";
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
            UnityEngine.Display[] displays = UnityEngine.Display.displays;
            foreach (UnityEngine.Display display in displays)
            {
                options.Add(display.ToString());
            }
            return options;
        }
    }
}