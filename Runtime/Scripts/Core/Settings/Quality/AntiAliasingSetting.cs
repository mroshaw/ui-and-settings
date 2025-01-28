using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.HighDefinition;

namespace DaftAppleGames.Settings.Quality
{
    [CreateAssetMenu(fileName = "AntiAliasingSettingSO", menuName = "Daft Apple Games/Settings/Quality/Anti Aliasing Setting", order = 1)]
    [Serializable]
    public class AntiAliasingSetting : OptionSetting
    {
        protected override string GetStorageName()
        {
            return "AntiAliasing";
        }

        public override string GetDisplayName()
        {
            return "Anti Aliasing";
        }

        public override void Apply()
        {
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

            hdAdditionalData.antialiasing = (HDAdditionalCameraData.AntialiasingMode)Value;
        }

        protected override int GetDefault()
        {
            Camera mainCamera = Camera.main;

            if (!mainCamera)
            {
                Debug.LogWarning("No MainCamera found.");
                return 0;
            }

            HDAdditionalCameraData hdAdditionalData = mainCamera.GetComponent<HDAdditionalCameraData>();
            if (hdAdditionalData == null)
            {
                Debug.LogWarning("No HDAdditionalCameraData found on MainCamera.");
                return 0;
            }

            return (int)hdAdditionalData.antialiasing;
        }

        public override List<string> GetOptions()
        {
            List<string> options = new();

            Array values = Enum.GetValues(typeof(HDAdditionalCameraData.AntialiasingMode));
            foreach (HDAdditionalCameraData.AntialiasingMode value in values)
            {
                options.Add(value.ToString());
            }
            return options;
        }
    }
}