#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#else
using DaftAppleGames.Attributes;
#endif
using System;

namespace DaftAppleGames.Settings.Audio
{
    [Serializable]
    public class AudioSettingsUI: SettingsUI
    {
        public FloatSettingUI masterVolumeUI;
        public FloatSettingUI musicVolumeUI;
        public FloatSettingUI soundFXVolumeUI;
        public FloatSettingUI ambientFXVolumeUI;

#if UNITY_EDITOR
        [Button("Set UI Labels")]
        internal void SetUILabels()
        {
            masterVolumeUI.SetLabel(settingsManager.AudioSettings.masterVolume.GetDisplayName());
            musicVolumeUI.SetLabel(settingsManager.AudioSettings.musicVolume.GetDisplayName());
            soundFXVolumeUI.SetLabel(settingsManager.AudioSettings.soundFXVolume.GetDisplayName());
            ambientFXVolumeUI.SetLabel(settingsManager.AudioSettings.ambientFXVolume.GetDisplayName());
        }
#endif

        public override void Enable()
        {
            SetUILabels();

            // Master Volume
            settingsManager.AudioSettings.masterVolume.valueChangedEvent.AddListener(masterVolumeUI.SetSliderValue);
            masterVolumeUI.sliderValueChangedEvent.AddListener(settingsManager.AudioSettings.masterVolume.SetValueNoEvent);

            // Music Volume
            settingsManager.AudioSettings.musicVolume.valueChangedEvent.AddListener(musicVolumeUI.SetSliderValue);
            musicVolumeUI.sliderValueChangedEvent.AddListener(settingsManager.AudioSettings.musicVolume.SetValueNoEvent);

            // Sounds FX Volume
            settingsManager.AudioSettings.soundFXVolume.valueChangedEvent.AddListener(soundFXVolumeUI.SetSliderValue);
            soundFXVolumeUI.sliderValueChangedEvent.AddListener(settingsManager.AudioSettings.soundFXVolume.SetValueNoEvent);

            // Ambient FX Volume
            settingsManager.AudioSettings.ambientFXVolume.valueChangedEvent.AddListener(ambientFXVolumeUI.SetSliderValue);
            ambientFXVolumeUI.sliderValueChangedEvent.AddListener(settingsManager.AudioSettings.ambientFXVolume.SetValueNoEvent);
        }

        public override void Disable()
        {
            // Master Volume
            settingsManager.AudioSettings.masterVolume.valueChangedEvent.RemoveListener(masterVolumeUI.SetSliderValue);
            masterVolumeUI.sliderValueChangedEvent.RemoveListener(settingsManager.AudioSettings.masterVolume.SetValueNoEvent);

            // Music Volume
            settingsManager.AudioSettings.musicVolume.valueChangedEvent.RemoveListener(musicVolumeUI.SetSliderValue);
            musicVolumeUI.sliderValueChangedEvent.RemoveListener(settingsManager.AudioSettings.musicVolume.SetValueNoEvent);

            // Sounds FX Volume
            settingsManager.AudioSettings.soundFXVolume.valueChangedEvent.AddListener(soundFXVolumeUI.SetSliderValue);
            soundFXVolumeUI.sliderValueChangedEvent.RemoveListener(settingsManager.AudioSettings.soundFXVolume.SetValueNoEvent);

            // Ambient FX Volume
            settingsManager.AudioSettings.ambientFXVolume.valueChangedEvent.AddListener(ambientFXVolumeUI.SetSliderValue);
            ambientFXVolumeUI.sliderValueChangedEvent.RemoveListener(settingsManager.AudioSettings.ambientFXVolume.SetValueNoEvent);
        }

        public override void ApplySettings()
        {
            throw new NotImplementedException();
        }
    }
}