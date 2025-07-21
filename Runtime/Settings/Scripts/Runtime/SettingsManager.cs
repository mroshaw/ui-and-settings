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
        [BoxGroup("Settings")] [SerializeField] private SettingsList settings;
        [BoxGroup("Settings")] [SerializeField] private bool notifyListenersOnStart = true;

        private void Awake()
        {
            settings.Initialise();
        }

        private void Start()
        {
            if (notifyListenersOnStart)
            {
                settings.NotifyListeners();
            }
        }

        internal void RefreshSettings()
        {
            settings.Initialise(true);
        }

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
    }
}