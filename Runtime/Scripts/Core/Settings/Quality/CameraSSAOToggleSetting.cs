using System;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;

namespace DaftAppleGames.Settings.Display
{
    [CreateAssetMenu(fileName = "CameraSSAOToggleSettingSO", menuName = "Daft Apple Games/Settings/Quality/Camera SSAO Toggle Setting", order = 1)]
    [Serializable]
    public class CameraSSAOToggleSetting : CameraVolumeToggleSetting
    {
        protected override string GetStorageName()
        {
            return "CameraSSAO";
        }

        public override string GetDisplayName()
        {
            return "SSAO";
        }

        protected override FrameSettingsField[] GetVolumeFrameSettingsFields()
        {
            return new[] { FrameSettingsField.SSAO };
        }

        protected override bool GetDefault()
        {
            return true;
        }
    }
}