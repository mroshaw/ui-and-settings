using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DaftAppleGames.UserInterface.Themes
{
    public class ButtonThemeApplier : ThemeApplier
    {
        protected override void ApplyTheme(ElementTheme elementTheme)
        {
            if (elementTheme is not ButtonTheme buttonTheme)
            {
                return;
            }
            Button button = GetComponent<Button>();
            buttonTheme.Apply(button);
        }
    }
}