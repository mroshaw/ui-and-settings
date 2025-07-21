using System;
using UnityEngine.Rendering.HighDefinition;

namespace DaftAppleGames.Settings
{
    [Serializable]
    public class DLSSSettingUI : OptionSettingUI
    {
        protected override bool Show()
        {
            return HDDynamicResolutionPlatformCapabilities.DLSSDetected;
        }
    }
}