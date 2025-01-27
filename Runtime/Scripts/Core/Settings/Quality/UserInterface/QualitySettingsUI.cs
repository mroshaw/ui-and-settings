#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#else
using DaftAppleGames.Attributes;
#endif
using System;

namespace DaftAppleGames.Settings.Quality
{
    [Serializable]
    public class QualitySettingsUI: SettingsUI
    {
        public OptionSettingUI qualityPresetUI;

#if UNITY_EDITOR
        [Button("Set UI Labels")]
        internal void SetUILabels()
        {
            qualityPresetUI.SetLabel(settingsManager.QualitySettings.qualityPreset.GetDisplayName());
        }
#endif

        public override void Enable()
        {
            QualitySettings qualitySettings = settingsManager.QualitySettings;
            SetUILabels();

            // Quality Preset
            qualityPresetUI.PopulateOptions(qualitySettings.qualityPreset.GetOptions());
            qualitySettings.qualityPreset.valueChangedEvent.AddListener(qualityPresetUI.SetDropdownValue);
            qualityPresetUI.dropdownValueChangedEvent.AddListener(qualitySettings.qualityPreset.SetValueNoEvent);

        }

        public override void Disable()
        {
        }

        public override void ApplySettings()
        {
            throw new NotImplementedException();
        }
    }
}