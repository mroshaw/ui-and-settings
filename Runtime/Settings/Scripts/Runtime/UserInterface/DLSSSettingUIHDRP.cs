#if DAG_HDRP
using System;
using UnityEngine.Rendering.HighDefinition;

namespace DaftAppleGames.Settings.UserInterface
{
    [Serializable]
    public class DLSSSettingUIHDRP : OptionSettingUI
    {
        protected override bool Show()
        {
            return HDDynamicResolutionPlatformCapabilities.DLSSDetected;
        }
    }
}
#endif