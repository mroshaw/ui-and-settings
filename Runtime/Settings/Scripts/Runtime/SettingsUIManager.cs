using System.Collections.Generic;
using System.Linq;
using DaftAppleGames.UserInterface;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#else
using DaftAppleGames.Attributes;
#endif

namespace DaftAppleGames.Settings
{
    public class SettingsUIManager : Window
    {
        #region Class Variables

        [BoxGroup("References")] [SerializeField] private SettingsManager settingsManager;
        [BoxGroup("UI Settings")] [SerializeField] private List<SettingUI> settingUis;
        [BoxGroup("UI")] [SerializeField] private Button saveButton;
        [BoxGroup("UI")] [SerializeField] private Button cancelButton;

        [BoxGroup("UI Events")] public UnityEvent onSaveButtonClickedEvent;
        [BoxGroup("UI Events")] public UnityEvent onCancelButtonClickedEvent;

        #endregion

        #region Startup

        public override void Awake()
        {
            base.Awake();
            Debug.Log("Settings UI - Init UI Mappings and Buttons");
            InitUiMapping();
            InitButtons();
        }
        #endregion

        #region Class methods

#if UNITY_EDITOR

        [Button("Refresh UI Settings")]
        private void RefreshUISettings()
        {
            settingUis = GetComponentsInChildren<SettingUI>(true).ToList();
        }


        [Button("Set UI Labels")]
        private void SetUILabels()
        {
            settingsManager.RefreshSettings();
            foreach (SettingUI settingUI in settingUis)
            {
                Setting setting = settingsManager.GetAnySetting(settingUI.settingId);
                if (setting)
                {
                    settingUI.SetLabel(setting.GetDisplayName());
                }
            }
        }
#endif
        private void InitButtons()
        {
            saveButton.onClick.AddListener(SaveButtonClicked);
            cancelButton.onClick.AddListener(CancelButtonClicked);
        }

        private void DeInitButtons()
        {
            saveButton.onClick.RemoveListener(SaveButtonClicked);
            cancelButton.onClick.RemoveListener(CancelButtonClicked);
        }

        private void SaveButtonClicked()
        {
            settingsManager.SaveSettings();
            onSaveButtonClickedEvent?.Invoke();
            Close();
        }

        private void CancelButtonClicked()
        {
            settingsManager.LoadSettings();
            onCancelButtonClickedEvent?.Invoke();
            Close();
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
            floatSettingUI.sliderValueChangedEvent.RemoveListener(floatSetting.SetValueAndApplyNoEvent);
            floatSettingUI.sliderValueChangedEvent.AddListener(floatSetting.SetValueAndApplyNoEvent);

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
            optionSettingUI.dropdownValueChangedEvent.RemoveListener(optionSetting.SetValueAndApplyNoEvent);
            optionSettingUI.dropdownValueChangedEvent.AddListener(optionSetting.SetValueAndApplyNoEvent);

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
            boolSettingUI.toggleChangedEvent.RemoveListener(boolSetting.SetValueAndApplyNoEvent);
            boolSettingUI.toggleChangedEvent.AddListener(boolSetting.SetValueAndApplyNoEvent);

            // When settings are updated, change the UI
            boolSetting.valueChangedEvent.RemoveListener(boolSettingUI.SetToggleValue);
            boolSetting.valueChangedEvent.AddListener(boolSettingUI.SetToggleValue);
        }
        #endregion
    }
}