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

namespace DaftAppleGames.UserInterface.Themes
{
    [Serializable]
    [CreateAssetMenu(fileName = "PanelTheme", menuName = "Daft Apple Games/User Interface/Panel Theme")]
    public class PanelTheme : ElementTheme
    {
        [BoxGroup("Background")] [SerializeField] private Sprite backgroundSprite;
        [BoxGroup("Background")] [SerializeField] private Color backgroundColor;

        public void Apply(CanvasRenderer canvasRenderer)
        {
            // Debug.Log($"Applying theme element {this} to panel {canvasRenderer.name}");

            // Apply window theme
            Image windowImage = canvasRenderer.GetComponent<Image>();
            if (windowImage)
            {
                windowImage.color = backgroundColor;
                if (backgroundSprite)
                {
                    windowImage.sprite = backgroundSprite;
                }
            }

#if UNITY_EDITOR
            if (UnityEditor.PrefabUtility.IsPartOfNonAssetPrefabInstance(canvasRenderer))
            {
                UnityEditor.PrefabUtility.RecordPrefabInstancePropertyModifications(canvasRenderer);
                UnityEditor.PrefabUtility.RecordPrefabInstancePropertyModifications(windowImage);
            }
            else
            {
                UnityEditor.EditorUtility.SetDirty(canvasRenderer.gameObject);
            }
#endif
        }
    }
}