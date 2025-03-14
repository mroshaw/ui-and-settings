using System;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;

namespace DaftAppleGames.Settings.Display
{
    [CreateAssetMenu(fileName = "CameraMotionBlurToggleSettingSO", menuName = "Daft Apple Games/Settings/Quality/Camera Motion Blur Toggle Setting", order = 1)]
    [Serializable]
    public class CameraMotionBlurToggleSetting : CameraVolumeToggleSetting
    {
        protected override string GetStorageName()
        {
            return "CameraMotionBlur";
        }

        public override string GetDisplayName()
        {
            return "Motion Blur";
        }

        protected override FrameSettingsField[] GetVolumeFrameSettingsFields()
        {
            return new[] { FrameSettingsField.MotionBlur };
        }

        protected override bool GetDefault()
        {
            return true;
        }
    }
}