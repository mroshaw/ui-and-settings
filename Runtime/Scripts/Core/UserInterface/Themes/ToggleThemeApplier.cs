using TMPro;
using UnityEngine.UI;

namespace DaftAppleGames.UserInterface.Themes
{
    public class ToggleThemeApplier : ThemeApplier
    {
        protected override void ApplyTheme(ElementTheme elementTheme)
        {
            if (elementTheme is not ToggleTheme toggleTheme)
            {
                return;
            }
            Toggle toggle = GetComponent<Toggle>();
            toggleTheme.Apply(toggle);
        }
    }
}