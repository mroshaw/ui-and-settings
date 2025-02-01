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
    [CreateAssetMenu(fileName = "DropdownTheme", menuName = "Daft Apple Games/User Interface/Dropdown Theme")]
    public class DropdownTheme : SelectableTheme
    {
        [BoxGroup("Image")] public Sprite dropdownArrowSprite;
        [BoxGroup("Image")] public Sprite dropdownBackgroundSprite;
        [BoxGroup("Image")] public Sprite dropdownViewportSprite;
        [BoxGroup("Image")] public Sprite itemBackgroundSprite;
        [BoxGroup("Image")] public Color itemBackgroundColor;
        [BoxGroup("Image")] public Sprite checkmarkSprite;
        [BoxGroup("Text")] public TextTheme captionTextTheme;
        [BoxGroup("Text")] public TextTheme itemTextTheme;
        [BoxGroup("Text")] public TextTheme itemLabelTextTheme;

        public override void Apply(Selectable selectable)
        {
            base.Apply(selectable);
            if (selectable is not TMP_Dropdown dropdown)
            {
                return;
            }

            Debug.Log($"Applying theme element {this} to button {dropdown.name}");

            // Apply Dropdown styling
            captionTextTheme.Apply(dropdown.captionText);
            itemTextTheme.Apply(dropdown.itemText);

            // Background
            dropdown.image.sprite = dropdownBackgroundSprite;

            // Get the drop down arrow gameobject
            GameObject arrowGameObject = dropdown.transform.Find("Arrow").gameObject;
            Image arrowImage = arrowGameObject.GetComponent<Image>();
            arrowImage.overrideSprite = dropdownArrowSprite;

            // Template checked sprite
            GameObject templateGameObject = dropdown.template.gameObject;
            Toggle templateItemToggle = dropdown.GetComponentInChildren<Toggle>(true);
            GameObject templateItemGameObject = templateItemToggle.gameObject;
            GameObject checkmarkGameObject = templateItemToggle.graphic.gameObject;
            Image checkmarkImage = checkmarkGameObject.GetComponent<Image>();
            checkmarkImage.sprite = checkmarkSprite;

            // Viewport background
            Image viewportImage = templateGameObject.GetComponent<Image>();
            viewportImage.sprite = dropdownViewportSprite;

            // Item background
            GameObject itemBackgroundGameObject = templateItemToggle.targetGraphic.gameObject;
            Image itemBackgroundImage = itemBackgroundGameObject.GetComponent<Image>();
            itemBackgroundImage.sprite = itemBackgroundSprite;
            itemBackgroundImage.color = itemBackgroundColor;

            // Get the label gameobject
            GameObject labelGameObject = dropdown.transform.Find("Label").gameObject;
            TMP_Text itemLabelText = labelGameObject.GetComponent<TMP_Text>();
            itemLabelTextTheme.Apply(itemLabelText);

#if UNITY_EDITOR
            if (UnityEditor.PrefabUtility.IsPartOfNonAssetPrefabInstance(dropdown))
            {
                UnityEditor.PrefabUtility.RecordPrefabInstancePropertyModifications(dropdown);
                UnityEditor.PrefabUtility.RecordPrefabInstancePropertyModifications(arrowImage);
                UnityEditor.PrefabUtility.RecordPrefabInstancePropertyModifications(itemLabelText);
                UnityEditor.PrefabUtility.RecordPrefabInstancePropertyModifications(itemBackgroundImage);
                UnityEditor.PrefabUtility.RecordPrefabInstancePropertyModifications(viewportImage);
                UnityEditor.PrefabUtility.RecordPrefabInstancePropertyModifications(checkmarkImage);
            }
            else
            {
                UnityEditor.EditorUtility.SetDirty(dropdown.gameObject);
            }
#endif

        }
    }
}