using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.UI;

namespace DaftAppleGames.Settings.Display
{
    [CreateAssetMenu(fileName = "ScreenResolutionVolumeSettingSO", menuName = "Daft Apple Games/Settings/Display/Screen Resolution Setting", order = 1)]
    [Serializable]
    public class ScreenResolutionSetting : OptionSetting
    {
        protected override string GetStorageName()
        {
            return "ScreenResolution";
        }

        public override string GetDisplayName()
        {
            return "Resolution";
        }

        public override void Apply()
        {
            Resolution[] resolutions = Screen.resolutions;
            Debug.Log($"Setting screen resolution to index {Value}: {resolutions[Value].width}, {resolutions[Value].height}");
            Screen.SetResolution(resolutions[Value].width, resolutions[Value].height, Screen.fullScreen);
        }

        protected override int GetDefault()
        {
            Resolution[] resolutions = Screen.resolutions;
            for(int resIndex=0; resIndex < resolutions.Length; ++resIndex)
            {
                if (resolutions[resIndex].width == Screen.width && resolutions[resIndex].height == Screen.height)
                {
                    return resIndex;
                }
            }

            return 0;
        }

        public override List<string> GetOptions()
        {
            List<string> options = new();

            foreach (Resolution resolution in Screen.resolutions)
            {
                options.Add(resolution.ToString());
            }

            return options;
        }
    }
}