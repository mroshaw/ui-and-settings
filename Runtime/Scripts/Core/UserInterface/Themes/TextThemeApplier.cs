using TMPro;

namespace DaftAppleGames.UserInterface.Themes
{
    public class TextThemeApplier : ThemeApplier
    {
        protected override void ApplyTheme(ElementTheme elementTheme)
        {
            if (elementTheme is not TextTheme textTheme)
            {
                return;
            }
            TMP_Text text = GetComponent<TMP_Text>();
            textTheme.Apply(text);
        }
    }
}