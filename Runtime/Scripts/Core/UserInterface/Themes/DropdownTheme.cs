#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#else
using DaftAppleGames.Attributes;
#endif
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DaftAppleGames.UserInterface.Themes
{
    [Serializable]
    [CreateAssetMenu(fileName = "DropdownTheme", menuName = "Daft Apple Games/User Interface/Dropdown Theme")]
    public class DropdownTheme : SelectableTheme
    {
        [BoxGroup("Image")] [SerializeField] private Sprite dropdownArrowSprite;
        [BoxGroup("Image")] [SerializeField] private Sprite dropdownBackgroundSprite;
        [BoxGroup("Image")] [SerializeField] private Sprite dropdownViewportSprite;
        [BoxGroup("Image")] [SerializeField] private Sprite itemBackgroundSprite;
        [BoxGroup("Image")] [SerializeField] private Color itemBackgroundColor;
        [BoxGroup("Image")] [SerializeField] private Sprite checkmarkSprite;
        [BoxGroup("Text")] [SerializeField] private TextTheme captionTextTheme;
        [BoxGroup("Text")] [SerializeField] private TextTheme itemTextTheme;
        [BoxGroup("Text")] [SerializeField] private TextTheme itemLabelTextTheme;

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
            Image backgroundImage = dropdown.GetComponent<Image>();
            backgroundImage.sprite = dropdownBackgroundSprite;

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
                UnityEditor.PrefabUtility.RecordPrefabInstancePropertyModifications(backgroundImage);
                UnityEditor.PrefabUtility.RecordPrefabInstancePropertyModifications(dropdown.image);
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