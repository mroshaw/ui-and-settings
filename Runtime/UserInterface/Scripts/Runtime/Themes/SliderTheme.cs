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
    [CreateAssetMenu(fileName = "SliderTheme", menuName = "Daft Apple Games/User Interface/Slider Theme")]
    public class SliderTheme : SelectableTheme
    {
        [BoxGroup("Image")] [SerializeField] private Sprite sliderBackgroundSprite;
        [BoxGroup("Image")] [SerializeField] private Sprite sliderPopulatedBackgroundSprite;
        [BoxGroup("Image")] [SerializeField] private Sprite sliderHandleSprite;

        public override void Apply(Selectable selectable)
        {
            base.Apply(selectable);

            if (selectable is not Slider slider)
            {
                return;
            }

            GameObject handleGameObject = slider.targetGraphic.gameObject;
            Image handleImage = handleGameObject.GetComponent<Image>();
            handleImage.sprite = sliderHandleSprite;

            GameObject backgroundPopulatedGameObject = slider.fillRect.gameObject;
            Image backgroundPopulatedImage = backgroundPopulatedGameObject.GetComponent<Image>();
            backgroundPopulatedImage.sprite = sliderPopulatedBackgroundSprite;

            GameObject backgroundGameObject = slider.transform.Find("Background").gameObject;
            Image backgroundImage = backgroundGameObject.GetComponent<Image>();
            backgroundImage.sprite = sliderBackgroundSprite;

#if UNITY_EDITOR
            if (UnityEditor.PrefabUtility.IsPartOfNonAssetPrefabInstance(slider))
            {
                UnityEditor.PrefabUtility.RecordPrefabInstancePropertyModifications(slider);
                UnityEditor.PrefabUtility.RecordPrefabInstancePropertyModifications(handleImage);
                UnityEditor.PrefabUtility.RecordPrefabInstancePropertyModifications(backgroundPopulatedImage);
                UnityEditor.PrefabUtility.RecordPrefabInstancePropertyModifications(backgroundImage);
            }
            else
            {
                UnityEditor.EditorUtility.SetDirty(slider.gameObject);
            }
#endif

        }
    }
}