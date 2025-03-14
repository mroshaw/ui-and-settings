using System;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;

namespace DaftAppleGames.Settings.Display
{
    [CreateAssetMenu(fileName = "CameraBloomToggleSettingSO", menuName = "Daft Apple Games/Settings/Quality/Camera Bloom Toggle Setting", order = 1)]
    [Serializable]
    public class CameraBloomToggleSetting : CameraVolumeToggleSetting
    {
        protected override string GetStorageName()
        {
            return "CameraBloom";
        }

        public override string GetDisplayName()
        {
            return "Bloom";
        }

        protected override FrameSettingsField[] GetVolumeFrameSettingsFields()
        {
            return new[] { FrameSettingsField.Bloom };
        }

        protected override bool GetDefault()
        {
            return true;
        }
    }
}