using System.Collections;
#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#else
using DaftAppleGames.Attributes;
#endif
using UnityEngine;
using UnityEngine.Events;

namespace DaftAppleGames.UserInterface
{
    /// <summary>
    /// MonoBehaviour class to manage display and tracking of tutorials
    /// </summary>
    public class Tutorial : MonoBehaviour
    {
        // Public serializable properties
        [BoxGroup("General Settings")] [SerializeField] private InfoPanelContent infoPanelContent;
        [BoxGroup("General Settings")] [SerializeField] private float delay;

        [BoxGroup("Debug")] [SerializeField] private bool isDone = false;

        [BoxGroup("Events")] public UnityEvent onTutorialOpenEvent;
        [BoxGroup("Events")] public UnityEvent onTutorialCloseEvent;

        private InfoPanel _infoPanel;

        private void Start()
        {
            _infoPanel = GetComponentInChildren<InfoPanel>();
        }

        public void ShowTutorial(bool force)
        {
            StartCoroutine(ShowTutorialAsync(force));
            onTutorialOpenEvent.Invoke();
        }

        /// <summary>
        /// Public method to show tutorial is complete
        /// </summary>
        public void CloseTutorial()
        {
            onTutorialCloseEvent.Invoke();
        }
        
        /// <summary>
        /// Async coroutine wrapper for ShowTutorialAfterDelay
        /// </summary>
        private IEnumerator ShowTutorialAsync(bool force)
        {
            yield return new WaitForSeconds(delay);
            // Only show tutorial if it's not been done, or if we choose to force it
            if (isDone && !force)
            {
                yield break;
            }

            // Populate and show the InfoPanel
            _infoPanel.SetHeadingText(infoPanelContent.heading);
            _infoPanel.SetContentText(infoPanelContent.content);
            if (infoPanelContent.image != null)
            {
                _infoPanel.SetImage(infoPanelContent.image);
            }
            _infoPanel.Open();
            isDone = true;
        }
    }
}