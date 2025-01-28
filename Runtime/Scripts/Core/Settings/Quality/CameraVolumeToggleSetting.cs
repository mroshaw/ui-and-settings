using System;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;

namespace DaftAppleGames.Settings.Display
{
    [Serializable]
    public abstract class CameraVolumeToggleSetting : BoolSetting
    {
        protected abstract FrameSettingsField[] GetVolumeFrameSettingsFields();

        public override void Apply()
        {
            Camera mainCamera = Camera.main;

            if (!mainCamera)
            {
                Debug.LogWarning("No MainCamera found.");
                return;
            }

            foreach (FrameSettingsField frameSettingsField in GetVolumeFrameSettingsFields())
            {
                HDRenderPipelineCameraUtils.SetCameraCustomFramePropertyState(frameSettingsField, Value);
            }
        }

    }
}