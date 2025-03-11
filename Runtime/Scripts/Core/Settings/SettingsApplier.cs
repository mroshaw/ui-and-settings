using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Events;
#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#else
using DaftAppleGames.Attributes;
#endif

namespace DaftAppleGames.Settings
{
    public class SettingsApplier : MonoBehaviour
    {
        #region Class Variables
        [BoxGroup("Settings")] [SerializeField] private SettingsSO settings;
        [BoxGroup("Behaviour")] [SerializeField] private bool applyOnAwake = true;
        [BoxGroup("Behaviour")] [SerializeField] private bool audioMixerMuteOnAwake = true;
        [BoxGroup("Behaviour")] [SerializeField] private AudioMixer mixer;
        [BoxGroup("Events")] [SerializeField] public UnityEvent allSettingsAppliedEvent;
        #endregion

        #region Startup
        /// <summary>
        /// Configure the component on awake
        /// </summary>   
        private void Awake()
        {
            settings.Initialise();

            if (applyOnAwake)
            {
                LoadAndApplySettings();
            }

            if (audioMixerMuteOnAwake)
            {
                mixer.SetFloat("MasterVolume", -80.0f);
            }
        }

        public void LoadAndApplySettings()
        {
            settings.LoadAndApplySettings();
            allSettingsAppliedEvent?.Invoke();
        }
        #endregion
    }
}