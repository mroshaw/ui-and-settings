using TMPro;
using UnityEngine.UI;

namespace DaftAppleGames.UserInterface.Themes
{
    public class SliderThemeApplier : ThemeApplier
    {
        protected override void ApplyTheme(ElementTheme elementTheme)
        {
            if (elementTheme is not SliderTheme sliderTheme)
            {
                return;
            }
            Slider slider = GetComponent<Slider>();
            sliderTheme.Apply(slider);
        }
    }
}