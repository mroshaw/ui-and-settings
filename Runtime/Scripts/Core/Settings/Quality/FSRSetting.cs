using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;

namespace DaftAppleGames.Settings.Quality
{
    [CreateAssetMenu(fileName = "FSRSettingSO", menuName = "Daft Apple Games/Settings/Quality/FSR Setting", order = 1)]
    [Serializable]
    public class FSRSetting : OptionSetting
    {
        protected override string GetStorageName()
        {
            return "FSR";
        }

        public override string GetDisplayName()
        {
            return "FSR";
        }

        public override void Apply()
        {
            if (!HDDynamicResolutionPlatformCapabilities.FSR2Detected)
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

            if (Value == 0)
            {
                hdAdditionalData.allowFidelityFX2SuperResolution = false;
                return;
            }

            hdAdditionalData.allowFidelityFX2SuperResolution = true;
            hdAdditionalData.fidelityFX2SuperResolutionUseOptimalSettings = true;

            switch(Value)
            {
                case 1:
                    hdAdditionalData.fidelityFX2SuperResolutionQuality = 0;
                    break;
                case 2:
                    hdAdditionalData.fidelityFX2SuperResolutionQuality = 1;
                    break;

                case 3:
                    hdAdditionalData.fidelityFX2SuperResolutionQuality = 2;
                    break;
                case 4:
                    hdAdditionalData.fidelityFX2SuperResolutionQuality = 3;
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
                "Quality",
                "Balanced",
                "Performance",
                "Ultra Performance"
            };
            return options;
        }
    }
}