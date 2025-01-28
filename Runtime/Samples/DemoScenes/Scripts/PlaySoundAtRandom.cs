using UnityEngine;
#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#else
using DaftAppleGames.Attributes;
#endif

namespace DaftAppleGames.Samples
{
    public class PlaySoundAtRandom : MonoBehaviour
    {
        #region Class Variables

        [BoxGroup("Settings")] [SerializeField] private AudioClip clip;
        [BoxGroup("Settings")] [SerializeField] private float minSecondsBetweenPlay = 5.0f;
        [BoxGroup("Settings")] [SerializeField] private float maxSecondsBetweenPlay = 5.0f;
        [BoxGroup("Settings")] [SerializeField] private int checkFrames = 5;

        private AudioSource _audioSource;
        private float _nextSoundPlays;
        #endregion

        #region Startup
        private void Start()
        {
            _audioSource = GetComponent<AudioSource>();
            _nextSoundPlays = Time.time + Random.Range(minSecondsBetweenPlay, maxSecondsBetweenPlay);
        }
        #endregion

        #region Update
        private void Update()
        {
            if (Time.frameCount % checkFrames != 0 || Time.time < _nextSoundPlays)
            {
                return;
            }

            _audioSource.PlayOneShot(clip);
            _nextSoundPlays = Time.time + Random.Range(minSecondsBetweenPlay, maxSecondsBetweenPlay);

        }
        #endregion
    }
}