using System;
using DaftAppleGames.Attributes;

namespace DaftAppleGames.Settings
{
    [Serializable]
    public abstract class SettingsUI
    {
        [BoxGroup("References")] public SettingsManager settingsManager;

        public abstract void Enable();

        public abstract void Disable();

        public abstract void ApplySettings();
    }
}