using System.Collections.Generic;
using System.Linq;
using DaftAppleGames.Utilities;
using UnityEngine;
#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#else
using DaftAppleGames.Attributes;
#endif

namespace DaftAppleGames.Settings
{
    [CreateAssetMenu(fileName = "SettingsList", menuName = "Daft Apple Games/Settings/Settings List", order = 1)]
    public class SettingsList : EnhancedScriptableObject
    {
        [BoxGroup("Settings")] [SerializeField] private List<BoolSetting> boolSettings;
        [BoxGroup("Settings")] [SerializeField] private List<FloatSetting> floatSettings;
        [BoxGroup("Settings")] [SerializeField] private List<IntSetting> intSettings;
        [BoxGroup("Settings")] [SerializeField] private List<OptionSetting> optionSettings;

        private bool _isInitialized = false;
        private List<Setting> _allSettings = new();

        internal void Initialise(bool forceReinitialise = false)
        {
            if (_isInitialized)
            {
                return;
            }

            _allSettings = GetAllSettings();
            _isInitialized = true;
        }

        private List<Setting> GetAllSettings()
        {
            List<Setting> allSettings = new();
            allSettings.AddRange(boolSettings);
            allSettings.AddRange(floatSettings);
            allSettings.AddRange(intSettings);
            allSettings.AddRange(optionSettings);
            allSettings.Sort((a, b) => a.order.CompareTo(b.order));
            return allSettings;
        }

        internal BoolSetting GetBoolSetting(string settingId)
        {
            List<Setting> settings = boolSettings.Cast<Setting>().ToList();
            return GetSetting(settings, settingId) as BoolSetting;
        }

        internal FloatSetting GetFloatSetting(string settingId)
        {
            List<Setting> settings = floatSettings.Cast<Setting>().ToList();
            return GetSetting(settings, settingId) as FloatSetting;
        }

        internal IntSetting GetIntSetting(string settingId)
        {
            List<Setting> settings = intSettings.Cast<Setting>().ToList();
            return GetSetting(settings, settingId) as IntSetting;
        }

        internal OptionSetting GetOptionSetting(string settingId)
        {
            List<Setting> settings = optionSettings.Cast<Setting>().ToList();
            return GetSetting(settings, settingId) as OptionSetting;
        }

        internal Setting GetAnySetting(string settingId)
        {
            Initialise();
            foreach (Setting setting in _allSettings)
            {
                if (setting.settingId == settingId)
                {
                    return setting;
                }
            }

            return null;
        }

        /// <summary>
        /// Notifies all listeners of current value state
        /// </summary>
        public void NotifyListeners()
        {
            if (_allSettings == null || _allSettings.Count == 0)
            {
                Debug.Log("Notify Listeners is refreshing the settings...");
                Initialise();
            }

            foreach (Setting setting in _allSettings)
            {
                if (setting is BoolSetting boolSetting)
                {
                    boolSetting.valueChangedEvent.Invoke(boolSetting.Value);
                }

                if (setting is BoolSetting floatSetting)
                {
                    floatSetting.valueChangedEvent.Invoke(floatSetting.Value);
                }

                if (setting is OptionSetting optionSetting)
                {
                    optionSetting.valueChangedEvent.Invoke(optionSetting.Value);
                }

                if (setting is IntSetting intSetting)
                {
                    intSetting.valueChangedEvent.Invoke(intSetting.Value);
                }
            }
        }

        private Setting GetSetting(List<Setting> settingsList, string settingId)
        {
            foreach (Setting setting in settingsList)
            {
                if (setting.settingId == settingId)
                {
                    return setting;
                }
            }

            return null;
        }

        internal void LoadAndApplySettings()
        {
            foreach (Setting setting in _allSettings)
            {
                setting.LoadAndApply();
            }
        }

        internal void LoadSettings()
        {
            foreach (Setting setting in _allSettings)
            {
                setting.Load();
            }
        }

        internal void ApplySettings()
        {
            foreach (Setting setting in _allSettings)
            {
                setting.Apply();
            }
        }

        internal void SaveSettings()
        {
            foreach (Setting setting in _allSettings)
            {
                setting.Save();
            }
        }
    }
}