#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#else
using DaftAppleGames.Attributes;
#endif
using System;
using UnityEngine;
using UnityEngine.UI;

namespace DaftAppleGames.UserInterface.Themes
{
    [Serializable]
    [CreateAssetMenu(fileName = "ToggleTheme", menuName = "Daft Apple Games/User Interface/Toggle Theme")]
    public class ToggleTheme : SelectableTheme
    {
        [BoxGroup("Image")] [SerializeField] private Sprite checkMarkSprite;
        [BoxGroup("Image")] [SerializeField] private Sprite checkMarkBackgroundSprite;

        public override void Apply(Selectable selectable)
        {
            base.Apply(selectable);

            if (selectable is not Toggle toggle)
            {
                return;
            }

            GameObject checkmarkGameObject = toggle.graphic.gameObject;
            Image checkMarkImage = checkmarkGameObject.GetComponent<Image>();
            checkMarkImage.sprite = checkMarkSprite;
            GameObject checkMarkBackgroundGameObject = checkmarkGameObject.transform.parent.gameObject;
            Image checkMarkBackgroundImage = checkMarkBackgroundGameObject.GetComponent<Image>();
            checkMarkBackgroundImage.sprite = checkMarkBackgroundSprite;

#if UNITY_EDITOR
            if (UnityEditor.PrefabUtility.IsPartOfNonAssetPrefabInstance(toggle))
            {
                UnityEditor.PrefabUtility.RecordPrefabInstancePropertyModifications(toggle);
                UnityEditor.PrefabUtility.RecordPrefabInstancePropertyModifications(checkMarkImage);
                UnityEditor.PrefabUtility.RecordPrefabInstancePropertyModifications(checkMarkBackgroundImage);
            }
            else
            {
                UnityEditor.EditorUtility.SetDirty(toggle.gameObject);
            }
#endif

        }
    }
}