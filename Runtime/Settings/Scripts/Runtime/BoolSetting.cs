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
        public bool Value => value;

        public void SetValue(bool newValue)
        {
            value = newValue;
            valueChangedEvent.Invoke(value);
        }

        public void SetValueAndApply(bool newValue)
        {
            SetValue(newValue);
            Apply();
        }

        public void SetValueNoEvent(bool newValue)
        {
            value = newValue;
        }

        public void SetValueAndApplyNoEvent(bool newValue)
        {
            SetValueNoEvent(newValue);
            Apply();
        }


        public override void Save()
        {
            PlayerPrefs.SetInt(GetStorageName(), Value ? 1 : 0);
        }

        public override void Load()
        {
            SetValue(PlayerPrefs.HasKey(GetStorageName()) ? PlayerPrefs.GetInt(GetStorageName()) != 0 : GetDefault());
        }

        protected abstract bool GetDefault();
    }
}