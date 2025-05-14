using DaftAppleGames.Gameplay;
using UnityEngine;
#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#else
using DaftAppleGames.Attributes;
#endif

namespace DaftAppleGames.UserInterface
{
    public enum TutorialTriggerAction {Enter, Exit}
    public class TutorialTrigger : ActionTrigger
    {
        [BoxGroup(" Trigger Settings")] [SerializeField] private TutorialTriggerAction triggerAction;
        [BoxGroup("Tutorial Settings")] [SerializeField] private bool force = false;
        
        private Tutorial _tutorial;

        private void Start()
        {
            _tutorial = GetComponent<Tutorial>();
        }

        protected override void TriggerEnter(Collider other)
        {
            if (triggerAction == TutorialTriggerAction.Enter)
            {
                StartTutorial();
            }
        }

        protected override void TriggerExit(Collider other)
        {
            if (triggerAction == TutorialTriggerAction.Exit)
            {
                StartTutorial();
            }
        }

        /// <summary>
        /// Starts the tutorial
        /// </summary>
        private void StartTutorial()
        {
            _tutorial.ShowTutorial(force);
        }
    }
}