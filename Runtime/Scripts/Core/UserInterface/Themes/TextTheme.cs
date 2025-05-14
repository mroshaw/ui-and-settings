#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#else
using DaftAppleGames.Attributes;
#endif
using System;
using TMPro;
using UnityEngine;

namespace DaftAppleGames.UserInterface.Themes
{
    [Serializable]
    [CreateAssetMenu(fileName = "TextTheme", menuName = "Daft Apple Games/User Interface/Text Theme")]
    public class TextTheme : ElementTheme
    {
        [BoxGroup("Text")] [SerializeField] private TMP_FontAsset font;
        [BoxGroup("Text")] [SerializeField] private Color textColor = Color.white;
        [BoxGroup("Text")] [SerializeField] private int size;
        [BoxGroup("Text")] [SerializeField] private bool isBold;

        public void Apply(TMP_Text text)
        {
            Debug.Log($"Applying theme element {this} to text {text.name}");
            text.font = font;
            text.color = textColor;
            text.fontSize = size;
            text.fontStyle = isBold ? FontStyles.Bold : FontStyles.Normal;

#if UNITY_EDITOR
            if (UnityEditor.PrefabUtility.IsPartOfNonAssetPrefabInstance(text))
            {
                UnityEditor.PrefabUtility.RecordPrefabInstancePropertyModifications(text);
            }
            else
            {
                UnityEditor.EditorUtility.SetDirty(text.gameObject);
            }
#endif
        }
    }
}