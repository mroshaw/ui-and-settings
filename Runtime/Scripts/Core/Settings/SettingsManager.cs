using System.Collections.Generic;
using System.Linq;
using UnityEngine;
#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#else
using DaftAppleGames.Attributes;
#endif

namespace DaftAppleGames.Settings
{
    public class SettingsManager : MonoBehaviour
    {
        #region Class Variables

        [BoxGroup("Settings")] [SerializeField] private SettingsSO settings;
        #endregion

        #region Startup
        private void Start()
        {
            settings.LoadAndApplySettings();
        }

        #endregion

        #region Class methods

        public void LoadSettings()
        {
            settings.LoadSettings();
        }

        public void ApplySettings()
        {
            settings.ApplySettings();
        }

        public void LoadAndApplySettings()
        {
            settings.LoadAndApplySettings();
        }

        public void SaveSettings()
        {
            settings.SaveSettings();
        }

        public BoolSetting GetBoolSetting(string settingId)
        {
            return settings.GetBoolSetting(settingId);
        }

        public FloatSetting GetFloatSetting(string settingId)
        {
            return settings.GetFloatSetting(settingId);
        }

        public OptionSetting GetOptionSetting(string settingId)
        {
            return settings.GetOptionSetting(settingId);
        }

        public Setting GetAnySetting(string settingId)
        {
            return settings.GetAnySetting(settingId);
        }
        #endregion
    }
}