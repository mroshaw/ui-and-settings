using DaftAppleGames.Editor;
using UnityEditor;
using UnityEngine;

namespace DaftAppleGames.Settings.Editor
{
    public class SettingsAndUiPackageInitializerEditorWindow : PackageInitializerEditorWindow
    {
        [MenuItem("Daft Apple Games/Packages/Settings and UI")]
        public static void ShowWindow()
        {
            SettingsAndUiPackageInitializerEditorWindow packageInitWindow = GetWindow<SettingsAndUiPackageInitializerEditorWindow>();
            packageInitWindow.titleContent = new GUIContent("Settings and UI");
        }
        protected override string GetIntroText()
        {
            return "Welcome to Settings and UI!";
        }

        protected override string GetBaseInstallLocation()
        {
            return "Assets/SettingsAndUI";
        }
    }
}