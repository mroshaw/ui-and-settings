using System;
using UnityEngine.Rendering.HighDefinition;

namespace DaftAppleGames.Settings
{
    [Serializable]
    public class FSRSettingUI : OptionSettingUI
    {
        protected override bool Show()
        {
            return HDDynamicResolutionPlatformCapabilities.FSR2Detected;
        }
    }
}