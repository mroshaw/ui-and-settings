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
        protected float Value
        {
            get => value;
            set
            {
                this.value = value;
                valueChangedEvent.Invoke(value);
                Apply();
            }
        }

        public void SetValueNoEvent(float newValue)
        {
            value = newValue;
            Apply();
        }

        public override void Save()
        {
            PlayerPrefs.SetFloat(GetStorageName(), Value);
        }

        public override void Load()
        {
            Value = PlayerPrefs.HasKey(GetStorageName()) ? PlayerPrefs.GetFloat(GetStorageName()) : GetDefault();
        }

        protected abstract float GetDefault();

        public abstract float GetMinValue();

        public abstract float GetMaxValue();
    }
}