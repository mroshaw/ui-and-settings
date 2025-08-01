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
        [BoxGroup("Settings")] [SerializeField] private SettingsList settings;
        [BoxGroup("Behaviour")] [SerializeField] private bool applyOnAwake = true;
        [BoxGroup("Behaviour")] [SerializeField] private bool applyOnStart = false;
        [BoxGroup("Behaviour")] [SerializeField] private bool audioMixerMuteOnAwake = true;
        [BoxGroup("Behaviour")] [SerializeField] private AudioMixer mixer;
        [BoxGroup("Events")] [SerializeField] public UnityEvent allSettingsAppliedEvent;

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

        private void Start()
        {
            if (applyOnStart)
            {
                LoadAndApplySettings();
            }
        }

        public void LoadAndApplySettings()
        {
            settings.LoadAndApplySettings();
            allSettingsAppliedEvent?.Invoke();
        }
    }
}