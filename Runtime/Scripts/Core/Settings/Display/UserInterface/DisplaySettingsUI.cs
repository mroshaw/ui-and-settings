#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#else
using DaftAppleGames.Attributes;
#endif
using System;
using System.Threading;
using UnityEngine.UI;

namespace DaftAppleGames.Settings.Display
{
    [Serializable]
    public class DisplaySettingsUI: SettingsUI
    {
        public BoolSettingUI fullScreenUI;
        public OptionSettingUI monitorUI;
        public OptionSettingUI resolutionUI;

#if UNITY_EDITOR
        [Button("Set UI Labels")]
        internal void SetUILabels()
        {
            fullScreenUI.SetLabel(settingsManager.DisplaySettings.fullScreen.GetDisplayName());
            monitorUI.SetLabel(settingsManager.DisplaySettings.monitor.GetDisplayName());
            resolutionUI.SetLabel(settingsManager.DisplaySettings.screenResolution.GetDisplayName());
        }
#endif
        public override void Enable()
        {
            DisplaySettings displaySettings = settingsManager.DisplaySettings;

            SetUILabels();

            // Populate dropdowns
            monitorUI.PopulateOptions(displaySettings.monitor.GetOptions());
            resolutionUI.PopulateOptions(displaySettings.screenResolution.GetOptions());

            // Full Screen
            displaySettings.fullScreen.valueChangedEvent.AddListener(fullScreenUI.SetToggleValue);
            fullScreenUI.toggleChangedEvent.AddListener(displaySettings.fullScreen.SetValueNoEvent);

            // Monitor
            displaySettings.monitor.valueChangedEvent.AddListener(monitorUI.SetDropdownValue);
            monitorUI.dropdownValueChangedEvent.AddListener(displaySettings.monitor.SetValueNoEvent);

            // Resolution
            displaySettings.screenResolution.valueChangedEvent.AddListener(resolutionUI.SetDropdownValue);
            resolutionUI.dropdownValueChangedEvent.AddListener(displaySettings.screenResolution.SetValueNoEvent);
        }

        public override void Disable()
        {
            DisplaySettings displaySettings = settingsManager.DisplaySettings;

            // Full Screen
            displaySettings.fullScreen.valueChangedEvent.RemoveListener(fullScreenUI.SetToggleValue);
            fullScreenUI.toggleChangedEvent.RemoveListener(displaySettings.fullScreen.SetValueNoEvent);

            // Monitor
            displaySettings.monitor.valueChangedEvent.RemoveListener(monitorUI.SetDropdownValue);
            monitorUI.dropdownValueChangedEvent.RemoveListener(displaySettings.monitor.SetValueNoEvent);

            // Resolution
            displaySettings.screenResolution.valueChangedEvent.RemoveListener(resolutionUI.SetDropdownValue);
            resolutionUI.dropdownValueChangedEvent.RemoveListener(displaySettings.screenResolution.SetValueNoEvent);
        }

        public override void ApplySettings()
        {

        }
    }
}