using DaftAppleGames.Scenes;
using UnityEngine;
namespace DaftAppleGames.UserInterface.MainMenu
{
    /// <summary>
    /// Implementation of the Pause Game functionality
    /// </summary>
    public class MainMenuManager : MonoBehaviour
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