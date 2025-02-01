using TMPro;
namespace DaftAppleGames.UserInterface.Themes
{
    public class DropdownThemeApplier : ThemeApplier
    {
        protected override void ApplyTheme(ElementTheme elementTheme)
        {
            if (elementTheme is not DropdownTheme dropdownTheme)
            {
                return;
            }
            TMP_Dropdown dropdown = GetComponent<TMP_Dropdown>();
            dropdownTheme.Apply(dropdown);
        }
    }
}