#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#else
using DaftAppleGames.Attributes;
#endif
using System;
using DaftAppleGames.Extensions;
using UnityEngine;
using UnityEngine.UI;

namespace DaftAppleGames.UserInterface.Themes
{
    [Serializable]
    public class SelectableTheme : ElementTheme
    {
        [BoxGroup("Image")] public bool useSpritesForTransition = true;
        [BoxGroup("Settings")] public TransitionColorTheme transitionColorTheme;
        [BoxGroup("Settings")] public TransitionSpriteTheme transitionSpriteTheme;
        [BoxGroup("Settings")] public AudioTheme baseAudioTheme;

        private AudioSource _audioSource;

        public virtual void Apply(Selectable selectable)
        {
            _audioSource = selectable.EnsureComponent<AudioSource>();
            _audioSource.outputAudioMixerGroup = baseAudioTheme.mixerGroup;

            ApplyTransitions(selectable);
#if UNITY_EDITOR
            if (UnityEditor.PrefabUtility.IsPartOfNonAssetPrefabInstance(selectable))
            {
                UnityEditor.PrefabUtility.RecordPrefabInstancePropertyModifications(selectable);
            }
            else
            {
                UnityEditor.EditorUtility.SetDirty(selectable);
            }
#endif
        }



        protected void ApplyTransitions(Selectable selectable)
        {
            if (useSpritesForTransition)
            {
                selectable.transition = Selectable.Transition.SpriteSwap;
                SpriteState newSpriteState = new SpriteState
                {
                    highlightedSprite = transitionSpriteTheme.highlightedSprite,
                    pressedSprite = transitionSpriteTheme.pressedSprite,
                    disabledSprite = transitionSpriteTheme.disabledSprite,
                    selectedSprite = transitionSpriteTheme.selectedSprite
                };
                selectable.spriteState = newSpriteState;
            }
            else
            {
                selectable.transition = Selectable.Transition.ColorTint;
                ColorBlock newColorBlock = new()
                {
                    normalColor = transitionColorTheme.normalColor,
                    highlightedColor = transitionColorTheme.highlightedColor,
                    selectedColor = transitionColorTheme.selectedColor,
                    pressedColor = transitionColorTheme.pressedColor,
                    disabledColor = transitionColorTheme.disabledColor,
                    colorMultiplier = transitionColorTheme.colorMultiplier,
                    fadeDuration = transitionColorTheme.fadeDuration
                };
                selectable.colors = newColorBlock;

            }
        }
    }
}