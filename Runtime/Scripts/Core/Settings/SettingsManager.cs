using DaftAppleGames.Settings.Display;
using DaftAppleGames.Settings.Quality;
using UnityEngine;
using AudioSettings = DaftAppleGames.Settings.Audio.AudioSettings;
using QualitySettings = DaftAppleGames.Settings.Quality.QualitySettings;
#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#else
using DaftAppleGames.Attributes;
#endif

namespace DaftAppleGames.Settings
{
    public class SettingsManager : MonoBehaviour
    {
        #region Class Variables

        [BoxGroup("Settings")] [SerializeField] private bool loadOnStart = true;
        [BoxGroup("Display")] [SerializeField] private DisplaySettings displaySettings;
        [BoxGroup("Audio")] [SerializeField] private AudioSettings audioSettings;
        [BoxGroup("Performance")] [SerializeField] private QualitySettings qualitySettings;

        internal DisplaySettings DisplaySettings => displaySettings;
        internal AudioSettings AudioSettings => audioSettings;
        internal QualitySettings QualitySettings => qualitySettings;

        #endregion

        #region Startup
        private void OnEnable()
        {
            
        }

        private void OnDisable()
        {
            
        }

        private void Awake()
        {
            
        }

        private void Start()
        {
            if (loadOnStart)
            {
                LoadSettings();
            }
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

        private void LoadSettings()
        {
            displaySettings.LoadSettings();
        }

        public void ApplySettings()
        {

        }

        public void SaveSettings()
        {

        }

        #endregion
    }
}