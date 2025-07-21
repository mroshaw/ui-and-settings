using System;

using UnityEngine;
using UnityEngine.Events;

namespace DaftAppleGames.Settings
{
    [Serializable]
    public abstract class FloatSetting : Setting
    {
        [SerializeField] private float value;
        public UnityEvent<float> valueChangedEvent;
        protected float Value => value;

        public void SetValue(float newValue)
        {
            value = newValue;
            valueChangedEvent.Invoke(value);
        }

        public void SetValueAndApply(float newValue)
        {
            SetValue(newValue);
            Apply();
        }

        public void SetValueNoEvent(float newValue)
        {
            value = newValue;
            Apply();
        }

        public void SetValueAndApplyNoEvent(float newValue)
        {
            SetValueNoEvent(newValue);
            Apply();
        }

        public override void Save()
        {
            PlayerPrefs.SetFloat(GetStorageName(), Value);
        }

        public override void Load()
        {
            SetValue(PlayerPrefs.HasKey(GetStorageName()) ? PlayerPrefs.GetFloat(GetStorageName()) : GetDefault());
        }

        protected abstract float GetDefault();

        public abstract float GetMinValue();

        public abstract float GetMaxValue();
    }
}