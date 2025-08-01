using System;
using UnityEngine;
using UnityEngine.Audio;
#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#else
using DaftAppleGames.Attributes;
#endif

namespace DaftAppleGames.Settings.Audio
{
    [Serializable]
    public abstract class MixerGroupVolumeSetting : FloatSetting
    {
		[BoxGroup("Settings")] [SerializeField] private string audioMixerGroupParameter;
        [BoxGroup("Settings")] [SerializeField] private AudioMixer audioMixer;
        public override void Apply()
        {
            AudioMixer mixer = GetAudioMixer();
            mixer.SetFloat(audioMixerGroupParameter, ValueToVolume(Value));
        }

        private float ValueToVolume(float value)
        {
            return Mathf.Log10(value) * 20;
        }

        private float VolumeToValue(float volume)
        {
            return Mathf.Pow(10f, volume / 20f);
        }

        private AudioMixer GetAudioMixer()
        {
            return audioMixer;
        }
        
        protected override float GetDefault()
        {
            return 1.0f;
        }

        public override float GetMinValue()
        {
            return 0.01f;
        }

        public override float GetMaxValue()
        {
            return 1.0f;
        }
    }
}