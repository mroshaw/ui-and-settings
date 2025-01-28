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
        private List<DisplayInfo> _displayInfos;

        private void OnEnable()
        {
            _displayInfos = new();
            Screen.GetDisplayLayout(_displayInfos);
        }

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
            /*
            if (!UnityEngine.Display.displays[Value].active)
            {
                UnityEngine.Display.displays[Value].Activate();
            }
            */
            Screen.MoveMainWindowTo(_displayInfos[Value], Vector2Int.zero);
        }

        protected override int GetDefault()
        {
            return 0;
        }

        public override List<string> GetOptions()
        {
            List<string> options = new();

            foreach (DisplayInfo display in _displayInfos)
            {
                options.Add($"{display.name} ({display.width}x{display.height})");
            }

            return options;
        }
    }
}