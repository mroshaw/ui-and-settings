using TMPro;

namespace DaftAppleGames.UserInterface.Themes
{
    public class DropdownThemeApplier : ThemeApplier
    {
        private DropdownTheme _dropDownTheme;
        private TMP_Dropdown _dropDown;

        protected override void ApplyTheme(ElementTheme elementTheme)
        {
            if (elementTheme is not DropdownTheme dropdownTheme)
            {
                return;
            }

            _dropDownTheme = dropdownTheme;

            _dropDown = GetComponent<TMP_Dropdown>();
            dropdownTheme.Apply(_dropDown);
        }
    }
}