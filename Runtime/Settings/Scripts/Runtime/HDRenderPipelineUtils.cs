#if DAG_HDRP
using System.Reflection;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;

namespace DaftAppleGames.Settings
{
    public static class HDRenderPipelineCameraUtils
    {
        private static FieldInfo RenderPipelineSettings_FieldInfo;

        public static void SetCameraCustomFramePropertyState(FrameSettingsField frameSettingField, bool enabled)
        {
            Camera mainCamera = Camera.main;
            if (mainCamera == null)
            {
                Debug.Log("Can't find MainCamera in Scene!");
                return;
            }

            HDAdditionalCameraData hdCameraData = mainCamera.GetComponent<HDAdditionalCameraData>();
            if (!hdCameraData)
            {
                Debug.Log("Can't find HDAdditionalCameraData in Camera");
                return;
            }

            // Make sure Camera overrides are enabled
            hdCameraData.customRenderingSettings = true;

            FrameSettingsOverrideMask frameSettingsMask = hdCameraData.renderingPathCustomFrameSettingsOverrideMask;
            FrameSettings frameSettings = hdCameraData.renderingPathCustomFrameSettings;

            // Set the override mask and override value
            frameSettingsMask.mask[(uint)frameSettingField] = true;
            frameSettings.SetEnabled(frameSettingField, enabled);

            // Update the camera
            hdCameraData.renderingPathCustomFrameSettingsOverrideMask = frameSettingsMask;
            hdCameraData.renderingPathCustomFrameSettings = frameSettings;
        }

        public static void EnableCustomFrameProperty(FrameSettingsField frameSettingField)
        {
            Camera[] cameras = Camera.allCameras;
            foreach (Camera cam in cameras)
            {
                if (cam.gameObject.activeInHierarchy && cam.isActiveAndEnabled)
                {
                    HDAdditionalCameraData settings = cam.GetComponent<HDAdditionalCameraData>();
                    settings.customRenderingSettings = true;
                    settings.renderingPathCustomFrameSettingsOverrideMask.mask[(uint)frameSettingField] = true;
                }
            }
        }

        public static bool GetCameraCustomFramePropertyState(FrameSettingsField frameSettingField)
        {
            if (Camera.main == null)
                return false;

            // Fetch from current camera
            HDAdditionalCameraData settings = Camera.main.GetComponent<HDAdditionalCameraData>();
            if (settings == null)
            {
                return false;
            }

            return settings.renderingPathCustomFrameSettings.IsEnabled(frameSettingField);
        }
    }
}
#endif