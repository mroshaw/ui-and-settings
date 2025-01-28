using System;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;

namespace DaftAppleGames.Settings.Display
{
    [CreateAssetMenu(fileName = "CameraSSGIToggleSettingSO", menuName = "Daft Apple Games/Settings/Quality/Camera SSGI Toggle Setting", order = 1)]
    [Serializable]
    public class CameraSSGIToggleSetting : CameraVolumeToggleSetting
    {
        protected override string GetStorageName()
        {
            return "CameraSSGI";
        }

        public override string GetDisplayName()
        {
            return "SSGI";
        }

        protected override FrameSettingsField[] GetVolumeFrameSettingsFields()
        {
            return new[] { FrameSettingsField.SSGI };
        }

        protected override bool GetDefault()
        {
            return true;
        }
    }
}