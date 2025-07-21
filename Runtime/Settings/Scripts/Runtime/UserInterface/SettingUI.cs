using System;
using TMPro;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace DaftAppleGames.Settings
{
    [ExecuteInEditMode]
    [Serializable]
    public abstract class SettingUI : MonoBehaviour
    {
        [SerializeField] public string settingId;
        [SerializeField] private TMP_Text label;

        private void Awake()
        {
            gameObject.SetActive(Show());
        }

        public void SetLabel(string labelText)
        {
            #if UNITY_EDITOR
            label.text = labelText;
            label.SetText(labelText);
            UnityEditor.PrefabUtility.RecordPrefabInstancePropertyModifications(label);
            UnityEditor.EditorUtility.SetDirty(label.gameObject);
            #endif
            label.SetText(labelText);
        }

        protected virtual bool Show()
        {
            return true;
        }
    }
}