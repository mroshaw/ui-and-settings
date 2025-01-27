using System;
using TMPro;
using UnityEngine;

namespace DaftAppleGames.Settings
{
    [Serializable]
    public abstract class SettingUI : MonoBehaviour
    {
        [SerializeField] public string settingId;
        [SerializeField] private TMP_Text label;

        public void SetLabel(string labelText)
        {
            label.text = labelText;
        }
    }
}