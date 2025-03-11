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
        [BoxGroup("Settings")] [SerializeField] private bool notifyListenersOnStart = true;
        #endregion

        #region Startup

        private void Awake()
        {
            settings.Initialise();
        }

        private void Start()
        {
            if (notifyListenersOnStart)
            {
                Debug.Log("Settings Manager - Notifying Listeners");
                settings.NotifyListeners();
            }
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