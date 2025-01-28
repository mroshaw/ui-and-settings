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
        protected int Value => value;

        public void SetValue(int newValue)
        {
            value = newValue;
            valueChangedEvent.Invoke(value);
            Apply();
        }

        public void SetValueNoEvent(int newValue)
        {
            value = newValue;
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