#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#else
using DaftAppleGames.Attributes;
#endif
using System;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

#if UNITY_EDITOR
using UnityEditor.Events;
#endif

namespace DaftAppleGames.UserInterface.Themes
{
    [Serializable]
    [CreateAssetMenu(fileName = "ButtonTheme", menuName = "Daft Apple Games/User Interface/Button Theme")]
    public class ButtonTheme : SelectableTheme
    {
        [BoxGroup("Image")] public Sprite imageSprite;
        [BoxGroup("Text")] public TextTheme buttonTextTheme;

        public override void Apply(Selectable selectable)
        {
            base.Apply(selectable);
            if (selectable is not Button button)
            {
                return;
            }
            Debug.Log($"Applying theme element {this} to button {button.name}");

            // Apply text
            TMP_Text buttonText = button.GetComponentInChildren<TMP_Text>(true);
            buttonTextTheme.Apply(buttonText);

            // Apply button theme
            Image buttonImage = button.GetComponent<Image>();
            if (buttonImage)
            {
                buttonImage.sprite = imageSprite;
            }



#if UNITY_EDITOR
            if (UnityEditor.PrefabUtility.IsPartOfNonAssetPrefabInstance(button))
            {
                UnityEditor.PrefabUtility.RecordPrefabInstancePropertyModifications(button);
                UnityEditor.PrefabUtility.RecordPrefabInstancePropertyModifications(buttonImage);
            }
            else
            {
                UnityEditor.EditorUtility.SetDirty(button.gameObject);
            }
#endif

        }
    }
}