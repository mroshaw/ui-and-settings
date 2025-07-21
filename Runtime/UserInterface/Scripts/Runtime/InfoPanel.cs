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
    /// <summary>
    /// A type of Window for displaying text, and image, and a "Continue" button
    /// </summary>
    public class InfoPanel : Window
    {
        [BoxGroup("Text Settings")] [SerializeField] private TMP_Text headingText;
        [BoxGroup("Text Settings")] [SerializeField] private TMP_Text contentText;
        [BoxGroup("Image Settings")] [SerializeField] private Image image;
        [BoxGroup("Image Settings")] [SerializeField] private Image[] inlineImages;
        [BoxGroup("Button Settings")] [SerializeField] private Button continueButton;

        [BoxGroup("UI Proxy Events")]
        public UnityEvent onContinueButtonClickedEvent;

        protected override void OnEnable()
        {
            continueButton.onClick.AddListener(ContinueButtonClick);
        }

        protected override void OnDisable()
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
        public void SetHeadingText(string text)
        {
            headingText.text = text;
        }

        /// <summary>
        /// Sets the content text
        /// </summary>
        public void SetContentText(string text)
        {
            contentText.text = text;
        }

        /// <summary>
        /// Set the content image
        /// </summary>
        public void SetImage(Sprite sprite)
        {
            image.sprite = sprite;
        }
    }
}