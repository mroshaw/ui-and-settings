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
    [CreateAssetMenu(fileName = "SettingsSO", menuName = "Daft Apple Games/Settings/Settings SO", order = 1)]
    public class SettingsSO : ScriptableObject
    {
        #region Public/serializable properties
        [BoxGroup("Behaviour")] [SerializeField] private bool loadOnStart = true;
        [BoxGroup("Settings")] [SerializeField] private List<BoolSetting> boolSettings;
        [BoxGroup("Settings")] [SerializeField] private List<FloatSetting> floatSettings;
        [BoxGroup("Settings")] [SerializeField] private List<IntSetting> intSettings;
        [BoxGroup("Settings")] [SerializeField] private List<OptionSetting> optionSettings;

        private List<Setting> _allSettings;

        #endregion
        #region Unity events
        private void OnEnable()
        {
            RefreshAllSettings();
        }

        #endregion

        #region Class methods
        internal void RefreshAllSettings()
        {
            _allSettings = new List<Setting>();
            _allSettings.AddRange(boolSettings);
            _allSettings.AddRange(floatSettings);
            _allSettings.AddRange(intSettings);
            _allSettings.AddRange(optionSettings);

            _allSettings.Sort((a, b) => a.order.CompareTo(b.order));
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
            RefreshAllSettings();
            foreach (Setting setting in _allSettings)
            {
                if (setting.settingId == settingId)
                {
                    return setting;
                }
            }
            return null;
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
            foreach(Setting setting in _allSettings)
            {
                setting.LoadAndApply();
            }
        }

        internal void LoadSettings()
        {
            foreach(Setting setting in _allSettings)
            {
                setting.Load();
            }
        }

        internal void ApplySettings()
        {
            foreach(Setting setting in _allSettings)
            {
                setting.Apply();
            }
        }

        internal void SaveSettings()
        {
            foreach(Setting setting in _allSettings)
            {
                setting.Save();
            }
        }

        #endregion
    }
}