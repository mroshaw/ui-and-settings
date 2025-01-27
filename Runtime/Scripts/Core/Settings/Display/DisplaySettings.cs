#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#else
using DaftAppleGames.Attributes;
#endif
using System;
using System.Threading;

namespace DaftAppleGames.Settings.Display
{
    [Serializable]
    public class DisplaySettings: Settings
    {
        protected override string GetStorageName()
        {
            return "Display";
        }

        protected override string GetDisplayName()
        {
            return "Display";
        }

        public FullScreenSetting fullScreen;
        public ScreenResolutionSetting screenResolution;
        public FrameRateSetting frameRate;
        public MonitorSetting monitor;
        public VsyncSetting vsync;
        public TextureResolutionSetting textureResolution;

        internal void LoadSettings()
        {
            fullScreen.LoadAndApply();

        }
    }
}