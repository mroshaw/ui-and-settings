using System;
using UnityEngine.Audio;

namespace DaftAppleGames.Settings.Audio
{
    [Serializable]
    public abstract class MixerGroupVolumeSetting : FloatSetting
    {
        protected override void Apply()
        {
            AudioMixer mixer = GetAudioMixer();
            string mixerGroupParameter = GetAudioMixerGroupParameter();
            mixer.SetFloat(mixerGroupParameter, Value);
        }

        protected abstract AudioMixer GetAudioMixer();
        protected abstract string GetAudioMixerGroupParameter();

        protected override float GetDefault()
        {
            return 1.0f;
        }

        protected override float GetMinValue()
        {
            return 0.0f;
        }

        protected override float GetMaxValue()
        {
            return 1.0f;
        }
    }
}