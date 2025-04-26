using DaftAppleGames.Editor;
using UnityEditor;
using UnityEngine;

namespace DaftAppleGames.Settings.Editor
{
    public class SettingsAndUiPackageInitializerEditorWindow : PackageInitializerEditorWindow
    {
        protected override string ToolTitle => "Settings and UI Installer";

        protected override string WelcomeLogText =>
            "Welcome to the Settings and UI Installer!";

        protected override void CreateCustomGUI()
        {
        }

        [MenuItem("Daft Apple Games/Packages/Settings and UI")]
        public static void ShowWindow()
        {
            SettingsAndUiPackageInitializerEditorWindow packageInitWindow = GetWindow<SettingsAndUiPackageInitializerEditorWindow>();
            packageInitWindow.titleContent = new GUIContent("Settings and UI");
        }
    }
}