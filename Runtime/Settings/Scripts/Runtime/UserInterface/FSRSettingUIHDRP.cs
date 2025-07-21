#if DAG_HDRP
using System;
using UnityEngine.Rendering.HighDefinition;

namespace DaftAppleGames.Settings
{
    [Serializable]
    public class FSRSettingUIHDRP : OptionSettingUI
    {
        protected override bool Show()
        {
            return HDDynamicResolutionPlatformCapabilities.FSR2Detected;
        }
    }
}
#endif