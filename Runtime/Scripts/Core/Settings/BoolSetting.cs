using System;
using UnityEngine;
using UnityEngine.Events;

namespace DaftAppleGames.Settings
{
    [Serializable]
    public abstract class BoolSetting : Setting
    {
        [SerializeField] private bool value;
        public UnityEvent<bool> valueChangedEvent;
        public bool Value
        {
            get => value;
            set
            {
                if (this.value == value) return;
                this.value = value;
                valueChangedEvent.Invoke(value);
            }
        }

        public void SetValueNoEvent(bool newValue)
        {
            value = newValue;
            Apply();
        }

        protected virtual void Save()
        {
            PlayerPrefs.SetInt(GetStorageName(), Value ? 1 : 0);
        }

        protected override void Load()
        {
            Value = PlayerPrefs.HasKey(GetStorageName()) ? PlayerPrefs.GetInt(GetStorageName()) != 0 : GetDefault();
        }

        protected abstract bool GetDefault();
    }
}