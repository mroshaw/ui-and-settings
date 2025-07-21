using System;
using UnityEngine;
using UnityEngine.Audio;

namespace DaftAppleGames.Settings.Audio
{
    [Serializable]
    public abstract class MixerGroupVolumeSetting : FloatSetting
    {
        public override void Apply()
        {
            AudioMixer mixer = GetAudioMixer();
            string mixerGroupParameter = GetAudioMixerGroupParameter();
            mixer.SetFloat(mixerGroupParameter, ValueToVolume(Value));
        }

        private float ValueToVolume(float value)
        {
            return Mathf.Log10(value) * 20;
        }

        private float VolumeToValue(float volume)
        {
            return Mathf.Pow(10f, volume / 20f);
        }

        protected abstract AudioMixer GetAudioMixer();
        protected abstract string GetAudioMixerGroupParameter();
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