#if DAG_HDRP
using System;
using DaftAppleGames.Settings.Display;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;

namespace DaftAppleGames.Settings.Quality.HDRP
{
    [CreateAssetMenu(fileName = "CameraMotionBlurToggleSettingSO", menuName = "Daft Apple Games/Settings/Quality/Camera Motion Blur Toggle Setting", order = 1)]
    [Serializable]
    public class CameraMotionBlurToggleSettingHDRP : CameraVolumeToggleSettingHDRP
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
#endif