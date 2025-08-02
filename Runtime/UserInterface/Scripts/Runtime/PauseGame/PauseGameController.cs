#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#else
using DaftAppleGames.Attributes;
#endif
using System.Collections.Generic;
using System.Linq;
using DaftAppleGames.Gameplay;
using DaftAppleGames.Scenes;
using UnityEngine;
using UnityEngine.Events;

namespace DaftAppleGames.UserInterface.PauseGame
{
    /// <summary>
    /// Implementation of the Pause Game functionality.
    /// Classes that implement IPausable receive notification when the game is paused/unpaused
    /// </summary>
    public class PauseGameController : MonoBehaviour
    {
        [BoxGroup("Events")] public UnityEvent pausedEvent;
        [BoxGroup("Events")] public UnityEvent unPausedEvent;

        private List<IPausable> _allPausables;

        public bool IsPaused { get; private set; }

        private void Start()
        {
            RefreshPausables();
        }

        protected virtual void TogglePauseGame()
        {
            if (IsPaused)
            {
                UnPauseGame();
            }
            else
            {
                PauseGame();
            }
        }

        protected virtual void PauseGame()
        {
            IsPaused = true;
            Time.timeScale = 0.0f;
            PauseAllPausables();
            pausedEvent.Invoke();
        }

        protected virtual void UnPauseGame()
        {
            IsPaused = false;
            Time.timeScale = 1.0f;
            ResumeAllPausables();
            unPausedEvent.Invoke();
        }

        protected virtual void ReturnToMainMenu()
        {
            UnPauseGame();
            SceneLoaderManager.Instance.LoadMainMenuLoaderScene();
        }

        protected virtual void ExitToDesktop()
        {
            Application.Quit();
        }

        private void RefreshPausables()
        {
            _allPausables = FindObjectsByType<MonoBehaviour>(FindObjectsSortMode.None).OfType<IPausable>().ToList();
        }

        private void PauseAllPausables()
        {
            RefreshPausables();
            foreach (IPausable pausable in _allPausables)
            {
                pausable.Pause();
            }
        }

        private void ResumeAllPausables()
        {
            foreach (IPausable pausable in _allPausables)
            {
                pausable.Resume();
            }
        }
    }
}