using System;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;

namespace DaftAppleGames.Settings.Display
{
    [CreateAssetMenu(fileName = "CameraShadowsToggleSettingSO", menuName = "Daft Apple Games/Settings/Quality/Camera Shadows Toggle Setting", order = 1)]
    [Serializable]
    public class CameraShadowsToggleSetting : CameraVolumeToggleSetting
    {
        protected override string GetStorageName()
        {
            return "CameraShadows";
        }

        public override string GetDisplayName()
        {
            return "Shadows";
        }

        protected override FrameSettingsField[] GetVolumeFrameSettingsFields()
        {
            return new[] { FrameSettingsField.ShadowMaps, FrameSettingsField.ContactShadows, FrameSettingsField.ScreenSpaceShadows, FrameSettingsField.Shadowmask };
        }

        protected override bool GetDefault()
        {
            return true;
        }
    }
}