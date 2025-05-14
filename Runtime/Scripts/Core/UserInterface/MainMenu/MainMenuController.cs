using DaftAppleGames.Scenes;
using UnityEngine;
namespace DaftAppleGames.UserInterface.MainMenu
{
    /// <summary>
    /// A simple controller to provide functions to a "Main Menu" UI window
    /// Methods intended to be hooked into UI UnityEvents
    /// </summary>
    public class MainMenuController : MonoBehaviour
    {
        private bool _isCursorVisible;
        private CursorLockMode _cursorLockMode;

        public void StartNewGame()
        {
            SceneLoaderManager.Instance.LoadGameLoaderScene();
        }

        public void ExitToDesktop()
        {
            Application.Quit();
        }
    }
}