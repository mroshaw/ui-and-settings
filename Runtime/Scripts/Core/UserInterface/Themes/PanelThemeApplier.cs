using UnityEngine;

namespace DaftAppleGames.UserInterface.Themes
{
    public class PanelThemeApplier : ThemeApplier
    {
        protected override void ApplyTheme(ElementTheme elementTheme)
        {
            if (elementTheme is not PanelTheme panelTheme)
            {
                return;
            }
            CanvasRenderer canvasRenderer = GetComponent<CanvasRenderer>();
            panelTheme.Apply(canvasRenderer);
        }
    }
}