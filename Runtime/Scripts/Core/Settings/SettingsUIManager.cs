using DaftAppleGames.Settings.Audio;
using DaftAppleGames.Settings.Display;
using DaftAppleGames.Settings.Quality;
using UnityEditor.SceneManagement;
using UnityEngine;
using AudioSettings = DaftAppleGames.Settings.Audio.AudioSettings;
#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#else
using DaftAppleGames.Attributes;
#endif

namespace DaftAppleGames.Settings
{
    public class SettingsUIManager : MonoBehaviour
    {
        #region Class Variables
        [BoxGroup("Display")] [SerializeField] private DisplaySettingsUI displaySettingsUI;
        [BoxGroup("Audio")] [SerializeField] private AudioSettingsUI audioSettingsUI;
        [BoxGroup("Quality")] [SerializeField] private QualitySettingsUI qualitySettingsUI;
        #endregion

        #region Startup
        private void OnEnable()
        {
            displaySettingsUI.Enable();
            audioSettingsUI.Enable();
            qualitySettingsUI.Enable();
        }

        private void OnDisable()
        {
            displaySettingsUI.Disable();
            audioSettingsUI.Disable();
            qualitySettingsUI.Disable();
        }

        private void Awake()
        {
            
        }

        private void Start()
        {
            
        }
        #endregion

        #region Update
        private void Update()
        {
            
        }

        private void LateUpdate()
        {
            
        }
        #endregion

        #region Class methods

#if UNITY_EDITOR
        [Button("Set UI Labels")]
        private void SetUILabels()
        {
            displaySettingsUI.SetUILabels();
            audioSettingsUI.SetUILabels();
            qualitySettingsUI.SetUILabels();
            EditorSceneManager.MarkSceneDirty(EditorSceneManager.GetActiveScene());
        }
#endif

        public void LoadSettings()
        {

        }

        public void ApplySettings()
        {
            displaySettingsUI.ApplySettings();
            audioSettingsUI.ApplySettings();
            qualitySettingsUI.ApplySettings();
        }

        public void SaveSettings()
        {

        }

        #endregion
    }
}