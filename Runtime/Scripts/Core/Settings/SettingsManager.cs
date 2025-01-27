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

        [BoxGroup("Behaviour")] [SerializeField] private bool loadOnStart = true;
        [BoxGroup("Settings")] [SerializeField] private List<BoolSetting> boolSettings;
        [BoxGroup("Settings")] [SerializeField] private List<FloatSetting> floatSettings;
        [BoxGroup("Settings")] [SerializeField] private List<IntSetting> intSettings;
        [BoxGroup("Settings")] [SerializeField] private List<OptionSetting> optionSettings;

        private List<Setting> allSettings;

        #endregion

        #region Startup
        private void OnEnable()
        {
            
        }

        private void OnDisable()
        {
            
        }

        private void Awake()
        {
            allSettings = new List<Setting>();
            allSettings.AddRange(boolSettings);
            allSettings.AddRange(floatSettings);
            allSettings.AddRange(intSettings);
        }

        private void Start()
        {
            if (loadOnStart)
            {
                LoadAndApplySettings();
            }
        }
        #endregion

        #region Class methods

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

        public BoolSetting GetBoolSetting(string settingId)
        {
            List<Setting> settings = boolSettings.Cast<Setting>().ToList();
            return GetSetting(settings, settingId) as BoolSetting;
        }

        public FloatSetting GetFloatSetting(string settingId)
        {
            List<Setting> settings = floatSettings.Cast<Setting>().ToList();
            return GetSetting(settings, settingId) as FloatSetting;
        }

        public IntSetting GetIntSetting(string settingId)
        {
            List<Setting> settings = intSettings.Cast<Setting>().ToList();
            return GetSetting(settings, settingId) as IntSetting;
        }

        public OptionSetting GetOptionSetting(string settingId)
        {
            List<Setting> settings = optionSettings.Cast<Setting>().ToList();
            return GetSetting(settings, settingId) as OptionSetting;
        }


        public void LoadAndApplySettings()
        {
            foreach(Setting setting in allSettings)
            {
                setting.LoadAndApply();
            }
        }

        public void LoadSettings()
        {
            foreach(Setting setting in allSettings)
            {
                setting.Load();
            }
        }

        public void ApplySettings()
        {
            foreach(Setting setting in allSettings)
            {
                setting.Apply();
            }
        }

        public void SaveSettings()
        {
            foreach(Setting setting in allSettings)
            {
                setting.Save();
            }
        }

        #endregion
    }
}