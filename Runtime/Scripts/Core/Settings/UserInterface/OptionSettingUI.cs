using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace DaftAppleGames.Settings
{
    [Serializable]
    public class OptionSettingUI : SettingUI
    {
        [SerializeField] private TMP_Dropdown dropdown;
        public UnityEvent<int> dropdownValueChangedEvent;
        private void OnEnable()
        {
            dropdown.onValueChanged.AddListener(DropdownValueChangedHandler);
        }

        private void OnDisable()
        {
            dropdown.onValueChanged.RemoveListener(DropdownValueChangedHandler);
        }

        private void DropdownValueChangedHandler(int newValue)
        {
            dropdownValueChangedEvent?.Invoke(newValue);
        }

        public void SetDropdownValue(int value)
        {
            dropdown.SetValueWithoutNotify(value);
        }

        public void PopulateOptions(List<string> options)
        {
            dropdown.ClearOptions();
            dropdown.AddOptions(options);
        }
    }
}