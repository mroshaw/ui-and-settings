using System;
using UnityEngine;

namespace DaftAppleGames.Settings.Display
{
    [CreateAssetMenu(fileName = "VSyncSettingSO", menuName = "Daft Apple Games/Settings/Display/V Sync Setting", order = 1)]
    [Serializable]
    public class VsyncSetting : BoolSetting
    {
        protected override string GetStorageName()
        {
            return "VSync";
        }

        public override string GetDisplayName()
        {
            return "V Sync";
        }

        public override void Apply()
        {
            QualitySettings.vSyncCount = Value ? 1 : 0;
        }

        protected override bool GetDefault()
        {
            return QualitySettings.vSyncCount == 1;
        }
    }
}