#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#else
using DaftAppleGames.Attributes;
#endif
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace DaftAppleGames.UserInterface
{
    public class InfoPanel : UiWindow
    {
        // Public serializable properties
        [BoxGroup("UI Settings")] public TMP_Text headingText;
        [BoxGroup("UI Settings")] public TMP_Text contentText;
        [BoxGroup("UI Settings")] public Image image;

        [BoxGroup("UI Settings")] [SerializeField] private Button continueButton;

        [BoxGroup("UI Settings")] public Image[] inlineImages;

        [Header("UI Proxy Events")]
        public UnityEvent onContinueButtonClickedEvent;

        protected override void InitHandlers()
        {
            continueButton.onClick.AddListener(ContinueButtonClick);
        }

        protected override void DeInitHandlers()
        {
            continueButton.onClick.RemoveListener(ContinueButtonClick);
        }

        /// <summary>
        /// Proxy for the Continue button click event
        /// </summary>
        private void ContinueButtonClick()
        {
            onContinueButtonClickedEvent.Invoke();
        }

        /// <summary>
        /// Sets the heading text
        /// </summary>
        /// <param name="text"></param>
        public void SetHeadingText(string text)
        {
            headingText.text = text;
        }

        /// <summary>
        /// Sets the content text
        /// </summary>
        /// <param name="text"></param>
        public void SetContentText(string text)
        {
            contentText.text = text;
        }

        /// <summary>
        /// Set the content image
        /// </summary>
        /// <param name="sprite"></param>
        public void SetImage(Sprite sprite)
        {
            image.sprite = sprite;
        }
    }
}