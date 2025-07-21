#if DAG_HDRP
using System;
using DaftAppleGames.Settings.Display;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;

namespace DaftAppleGames.Settings.Quality.HDRP
{
    [CreateAssetMenu(fileName = "CameraSSGIToggleSettingSO", menuName = "Daft Apple Games/Settings/Quality/Camera SSGI Toggle Setting", order = 1)]
    [Serializable]
    public class CameraSsgiToggleSettingHDRP : CameraVolumeToggleSettingHDRP
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
#endif