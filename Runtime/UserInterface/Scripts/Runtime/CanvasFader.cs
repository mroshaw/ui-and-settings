using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
#if ODIN_INSPECTOR
using Sirenix.OdinInspector;

#else
using DaftAppleGames.Attributes;
#endif

namespace DaftAppleGames.UserInterface
{
    /// <summary>
    /// Simple component to fade in and out a canvas
    /// </summary>
    public class CanvasFader : MonoBehaviour
    {
        [BoxGroup("Settings")] [SerializeField] private bool fadeInOnStart;
        [BoxGroup("Settings")] [SerializeField] private float fadeDuration = 5.0f;
        [BoxGroup("UI Settings")] [SerializeField] private CanvasGroup canvasGroup;

        [BoxGroup("Events")] public UnityEvent onFadeComplete;
        [BoxGroup("Events")] public UnityEvent onFadeInComplete;
        [BoxGroup("Events")] public UnityEvent onFadeOutComplete;

        private Coroutine _fadeCoroutine;
        private bool _isFading;

        private void OnEnable()
        {
            canvasGroup.alpha = 1.0f;
            canvasGroup.gameObject.SetActive(true);
            StopAllCoroutines();
        }

        private void OnDisable()
        {
        }

        private void Start()
        {
            if (fadeInOnStart)
            {
                FadeIn();
            }
        }

        [Button("Fade In")]
        public void FadeIn()
        {
            if (_isFading)
            {
                StopCoroutine(_fadeCoroutine);
            }
            _fadeCoroutine = StartCoroutine(FadeCanvas(false));
        }

        [Button("Fade Out")]
        public void FadeOut()
        {
            if (_isFading)
            {
                StopCoroutine(_fadeCoroutine);
            }
            StartCoroutine(FadeCanvas(true));
        }

        public void FadeIn(Action onComplete)
        {
            if (_isFading)
            {
                StopCoroutine(_fadeCoroutine);
            }

            StartCoroutine(FadeCanvas(false, onComplete));
        }
    
        public void FadeOut(Action onComplete)
        {
            if (_isFading)
            {
                StopCoroutine(_fadeCoroutine);
            }

            StartCoroutine(FadeCanvas(true, onComplete));
        }
        
        private IEnumerator FadeCanvas(bool isFadeOut, Action onComplete = null)
        {
            if (_isFading)
            {
                yield break;
            }

            _isFading = true;

            float time = 0;

            float startAlpha = isFadeOut ? 0 : 1;
            float endAlpha = isFadeOut ? 1 : 0;
            canvasGroup.alpha = startAlpha;
            canvasGroup.interactable = false;

            canvasGroup.gameObject.SetActive(true);

            while (time < fadeDuration)
            {
                canvasGroup.alpha = Mathf.Lerp(startAlpha, endAlpha, time / fadeDuration);
                // time += Time.deltaTime;
                time += Time.unscaledDeltaTime;
                yield return null;
            }

            canvasGroup.alpha = endAlpha;
            onFadeComplete?.Invoke();
            onComplete?.Invoke();
            
            if (!isFadeOut)
            {
                onFadeInComplete?.Invoke();
            }
            else
            {
                onFadeOutComplete?.Invoke();
            }

            _isFading = false;
        }
    }
}