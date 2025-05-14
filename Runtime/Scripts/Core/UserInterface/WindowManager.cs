using System.Collections.Generic;
using System.Linq;
using DaftAppleGames.Utilities;

namespace DaftAppleGames.UserInterface
{
    /// <summary>
    /// Singleton class to administer over active UI windows
    /// </summary>
    public class WindowManager : Singleton<WindowManager>
    {
        private static List<Window> _windows = new();

        protected override void Awake()
        {
            base.Awake();
            _windows = new();
        }

        /// <summary>
        /// Public getter to show if any Ui windows are currently open
        /// </summary>
        public bool IsAnyUiOpen => _windows.Any(window => window.IsUiOpen);

        /// <summary>
        /// Debug function to return list of open UI windows 
        /// </summary>
        /// <returns></returns>
        public string GetOpenUiName()
        {
            string result = "";
            
            foreach (Window window in _windows)
            {
                if (window.IsUiOpen)
                {
                    if (window.gameObject)
                    {
                        result += window.gameObject.name + "_";
                    }
                }
            }
            return result;
        }

        /// <summary>
        /// Adds a UI window to be managed
        /// </summary>
        public void RegisterUiWindow(Window window)
        {
            _windows.Add(window);
        }

        /// <summary>
        /// Removes a UI window
        /// </summary>
        public void UnRegisterUiWindow(Window window)
        {
            _windows.Remove(window);
        }
    }
}