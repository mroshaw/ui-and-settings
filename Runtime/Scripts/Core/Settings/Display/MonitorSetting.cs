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
            #if !UNITY_EDITOR
            UnityEngine.Display.displays[Value].Activate();
            #endif
        }

        protected override int GetDefault()
        {
            return 0;
        }

        public override List<string> GetOptions()
        {
            List<string> options = new();

            List<DisplayInfo> displayLayout = new List<DisplayInfo>();
            Screen.GetDisplayLayout(displayLayout);

            foreach (DisplayInfo display in displayLayout)
            {
                options.Add(display.name);
            }
            return options;
        }
    }
}