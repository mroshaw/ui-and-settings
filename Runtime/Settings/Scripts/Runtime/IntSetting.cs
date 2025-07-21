using System;
using UnityEngine;
using UnityEngine.Events;

namespace DaftAppleGames.Settings
{
    [Serializable]
    public abstract class IntSetting : Setting
    {
        [SerializeField] private int value;
        public UnityEvent<int> valueChangedEvent;
        public int Value => value;

        public void SetValue(int newValue)
        {
            value = newValue;
            valueChangedEvent.Invoke(value);
        }

        public void SetValueAndApply(int newValue)
        {
            SetValue(newValue);
            Apply();
        }

        public void SetValueNoEvent(int newValue)
        {
            value = newValue;
        }

        public void SetValueAndApplyNoEvent(int newValue)
        {
            SetValueNoEvent(newValue);
            Apply();
        }


        public override void Save()
        {
            PlayerPrefs.SetInt(GetStorageName(), Value);
        }

        public override void Load()
        {
            SetValue(PlayerPrefs.HasKey(GetStorageName()) ? PlayerPrefs.GetInt(GetStorageName()) : GetDefault());
        }

        protected abstract int GetDefault();
    }
}