using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#else
using DaftAppleGames.Attributes;
#endif

namespace DaftAppleGames.Settings
{
    public class SettingsUIManager : MonoBehaviour
    {
        #region Class Variables

        [BoxGroup("References")] [SerializeField] private SettingsManager settingsManager;
        [BoxGroup("UI Settings")] [SerializeField] private List<SettingUI> settingUis;
        [BoxGroup("UI")] [SerializeField] private Button saveButton;
        [BoxGroup("UI")] [SerializeField] private Button cancelButton;
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
            InitUiMapping();
            InitButtons();
        }

        private void Start()
        {
            
        }
        #endregion

        #region Class methods

#if UNITY_EDITOR

        [Button("Refresh UI Settings")]
        private void RefreshUISettings()
        {
            settingUis = GetComponentsInChildren<SettingUI>().ToList();
        }

        [Button("Set UI Labels")]
        private void SetUILabels()
        {

        }
#endif

        private void InitButtons()
        {

            saveButton.onClick.AddListener(settingsManager.SaveSettings);
            cancelButton.onClick.AddListener(settingsManager.LoadSettings);

        }

        private void DeInitButtons()
        {
            saveButton.onClick.RemoveListener(settingsManager.SaveSettings);
        }

        private void InitUiMapping()
        {
            foreach (SettingUI settingUi in settingUis)
            {
                if(settingUi is FloatSettingUI floatSettingUi)
                {
                    ConfigureSlider(floatSettingUi);
                }

                if(settingUi is IntSettingUI intSettingUi)
                {
                    ConfigureSlider(intSettingUi);
                }

                if (settingUi is OptionSettingUI optionSettingUi)
                {
                    ConfigureDropdown(optionSettingUi);
                }

                if (settingUi is BoolSettingUI boolSettingUi)
                {
                    ConfigureCheckbox(boolSettingUi);
                }
            }
        }

        private void ConfigureSlider(FloatSettingUI floatSettingUI)
        {
            string settingId = floatSettingUI.settingId;
            FloatSetting floatSetting = settingsManager.GetFloatSetting(settingId);

            if (!floatSetting)
            {
                Debug.LogError($"Couldn't not find a setting with ID: {settingId}");
                return;
            }

            floatSettingUI.SetLabel(floatSetting.GetDisplayName());

            // Configure slider
            floatSettingUI.SetSliderMinMax(floatSetting.GetMinValue(), floatSetting.GetMaxValue());

            // When UI changes, update the settings
            floatSettingUI.sliderValueChangedEvent.RemoveListener(floatSetting.SetValueNoEvent);
            floatSettingUI.sliderValueChangedEvent.AddListener(floatSetting.SetValueNoEvent);

            // When settings are updated, change the UI
            floatSetting.valueChangedEvent.RemoveListener(floatSettingUI.SetSliderValue);
            floatSetting.valueChangedEvent.AddListener(floatSettingUI.SetSliderValue);

        }

        private void ConfigureDropdown(OptionSettingUI optionSettingUI)
        {
            string settingId = optionSettingUI.settingId;
            OptionSetting optionSetting = settingsManager.GetOptionSetting(settingId);

            if (!optionSetting)
            {
                Debug.LogError($"Couldn't not find a setting with ID: {settingId}");
                return;
            }

            optionSettingUI.SetLabel(optionSetting.GetDisplayName());

            // Populate the drop down options
            optionSettingUI.PopulateOptions(optionSetting.GetOptions());

            // When UI changes, update the settings
            optionSettingUI.dropdownValueChangedEvent.RemoveListener(optionSetting.SetValueNoEvent);
            optionSettingUI.dropdownValueChangedEvent.AddListener(optionSetting.SetValueNoEvent);

            // When settings are updated, change the UI
            optionSetting.valueChangedEvent.RemoveListener(optionSettingUI.SetDropdownValue);
            optionSetting.valueChangedEvent.AddListener(optionSettingUI.SetDropdownValue);
        }

        private void ConfigureCheckbox(BoolSettingUI boolSettingUI)
        {
            string settingId = boolSettingUI.settingId;
            BoolSetting boolSetting = settingsManager.GetBoolSetting(settingId);

            if (!boolSetting)
            {
                Debug.LogError($"Couldn't not find a setting with ID: {settingId}");
                return;
            }

            boolSettingUI.SetLabel(boolSetting.GetDisplayName());

            // When UI changes, update the settings
            boolSettingUI.toggleChangedEvent.RemoveListener(boolSetting.SetValueNoEvent);
            boolSettingUI.toggleChangedEvent.AddListener(boolSetting.SetValueNoEvent);

            // When settings are updated, change the UI
            boolSetting.valueChangedEvent.RemoveListener(boolSettingUI.SetToggleValue);
            boolSetting.valueChangedEvent.AddListener(boolSettingUI.SetToggleValue);
        }
        #endregion
    }
}