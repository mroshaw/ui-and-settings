using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace DaftAppleGames.Settings
{
    [Serializable]
    public class BoolSettingUI : SettingUI
    {
        [SerializeField] private Toggle toggle;
        public UnityEvent<bool> toggleChangedEvent;
        private void OnEnable()
        {
            toggle.onValueChanged.AddListener(ToggleChangedHandler);
        }

        private void OnDisable()
        {
            toggle.onValueChanged.RemoveListener(ToggleChangedHandler);
        }

        private void ToggleChangedHandler(bool newValue)
        {
            toggleChangedEvent?.Invoke(newValue);
        }

        public void SetToggleValue(bool value)
        {
            toggle.SetIsOnWithoutNotify(value);
        }
    }
}