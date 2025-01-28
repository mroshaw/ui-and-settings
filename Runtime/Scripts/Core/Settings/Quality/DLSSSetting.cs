using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;

namespace DaftAppleGames.Settings.Quality
{
    [CreateAssetMenu(fileName = "DLSSSettingSO", menuName = "Daft Apple Games/Settings/Quality/DLSS Setting", order = 1)]
    [Serializable]
    public class DLSSSetting : OptionSetting
    {
        protected override string GetStorageName()
        {
            return "DLSS";
        }

        public override string GetDisplayName()
        {
            return "DLSS";
        }

        public override void Apply()
        {
            if (!HDDynamicResolutionPlatformCapabilities.DLSSDetected)
            {
                return;
            }

            Camera mainCamera = Camera.main;

            if (!mainCamera)
            {
                Debug.LogWarning("No MainCamera found.");
                return;
            }

            HDAdditionalCameraData hdAdditionalData = mainCamera.GetComponent<HDAdditionalCameraData>();
            if (hdAdditionalData == null)
            {
                Debug.LogWarning("No HDAdditionalCameraData found on MainCamera.");
                return;
            }

            // Check we have enabled Dynamic Resolution
            hdAdditionalData.allowDynamicResolution = true;

            if (Value == 0)
            {
                hdAdditionalData.allowDeepLearningSuperSampling = false;
                return;
            }

            hdAdditionalData.allowDeepLearningSuperSampling = true;
            hdAdditionalData.deepLearningSuperSamplingUseCustomQualitySettings = true;

            switch(Value)
            {
                case 1:
                    hdAdditionalData.deepLearningSuperSamplingQuality = 2;
                    break;
                case 2:
                    hdAdditionalData.deepLearningSuperSamplingQuality = 1;
                    break;

                case 3:
                    hdAdditionalData.deepLearningSuperSamplingQuality = 0;
                    break;
                case 4:
                    hdAdditionalData.deepLearningSuperSamplingQuality = 3;
                    break;
            }
        }

        protected override int GetDefault()
        {
            return 0;
        }

        public override List<string> GetOptions()
        {
            List<string> options = new()
            {
                "Disabled",
                "Maximum Quality",
                "Balanced",
                "Maximum Performance",
                "Ultra Performance"
            };
            return options;
        }
    }
}