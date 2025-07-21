using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#else
using DaftAppleGames.Attributes;
#endif
using TMPro;

namespace DaftAppleGames.UserInterface
{
    /// <summary>
    /// Component used to provide a "Notification" that fades in and out
    /// </summary>
    public class NotificationPanel : MonoBehaviour
    {
        [BoxGroup("UI Settings")] [SerializeField] private TMP_Text notificationText;
        [BoxGroup("Fade Settings")] [SerializeField] private float notificationVisibleTime = 2.0f;
        [BoxGroup("Fade Settings")] [SerializeField] private float notificationFadeTime = 2.0f;
        private Color _visibleColor;
        private Color _hiddenColor;

        private readonly Queue<string> _notificationQueue = new();
        private bool _isShowingNotification;

        private void Awake()
        {
            Color textColor = notificationText.color;
            _visibleColor = new Color(textColor.r, textColor.g, textColor.b, 1);
            _hiddenColor = new Color(textColor.r, textColor.g, textColor.b, 0);
        }


        /// <summary>
        /// Adds a notification into the queue
        /// </summary>
        public void Notify(string message)
        {
            _notificationQueue.Enqueue(message);
        }

        /// <summary>
        /// Check to see if there are notifications in the queue and show them.
        /// </summary>
        private void Update()
        {
            if (_notificationQueue.Count == 0 || _isShowingNotification)
            {
                return;
            }

            StartCoroutine(NotifyFade(_notificationQueue.Dequeue()));
        }

        /// <summary>
        /// Show the current notification queue, fade in and out
        /// </summary>
        private IEnumerator NotifyFade(string message)
        {
            _isShowingNotification = true;
            notificationText.color = _hiddenColor;
            notificationText.text = message;

            // Fade text in
            float time = 0;
            while (time < notificationFadeTime)
            {
                notificationText.color = Color.Lerp(_hiddenColor, _visibleColor, time / notificationFadeTime);
                time += Time.deltaTime;
                yield return null;
            }
            notificationText.color = _visibleColor;

            // Wait
            yield return new WaitForSecondsRealtime(notificationVisibleTime);

            // Fade out
            time = 0;
            while (time < notificationFadeTime)
            {
                notificationText.color = Color.Lerp(_visibleColor, _hiddenColor, time / notificationFadeTime);
                time += Time.deltaTime;
                yield return null;
            }
            notificationText.color = _hiddenColor;
            notificationText.text = "";

            _isShowingNotification = false;
        }
    }
}