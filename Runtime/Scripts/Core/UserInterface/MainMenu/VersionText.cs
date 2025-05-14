using UnityEngine;
#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#else
using DaftAppleGames.Attributes;
#endif
using TMPro;

namespace DaftAppleGames.UserInterface.MainMenu
{
    /// <summary>
    /// Simple Component to display the application version text
    /// in a TMP Text UI control
    /// </summary>
    [RequireComponent(typeof(TMP_Text))]
    public class VersionText : MonoBehaviour
    {
        private void Start()
        {
            TMP_Text versionText = GetComponent<TMP_Text>();
            versionText.text = Application.version.ToString();
            if (Debug.isDebugBuild)
            {
                versionText.text += "\nDEV BUILD";
            }
        }
    }
}