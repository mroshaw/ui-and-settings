using UnityEngine;
#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#else
using DaftAppleGames.Attributes;
#endif

namespace DaftAppleGames.UserInterface
{
    /// <summary>
    /// Simple behaviour to spin an object 360 degrees over time
    /// </summary>
    public class SmoothSpinUiObject : MonoBehaviour
    {
        [BoxGroup("General Settings")] [SerializeField] private bool spinOnStart;
        [BoxGroup("General Settings")] [SerializeField] private bool continuous = true;

        [BoxGroup("Spin Settings")] [SerializeField] private float fullSpinInSeconds;

        // Controls the spinning state
        private bool _isSpinning = false;
        
        // Internal spinning variables
        private float _currentRotation;
        private float _spinTime;
        private float _startTime;

        private const float StartRotation = 0.0f;
        private const float EndRotation = 360.0f;

        /// <summary>
        /// Start spinning, if set to do so
        /// </summary>
        private void Start()
        {
            if (spinOnStart)
            {
                StartSpinning();
            }
        }

        private void Update()
        {
            if (!_isSpinning)
            {
                return;
            }
            Spin();
        }

        /// <summary>
        /// Spin the Game Object
        /// </summary>
        private void Spin()
        {
            float timeDelta = (Time.time - _startTime) / fullSpinInSeconds;
            _currentRotation = Mathf.Lerp(StartRotation, EndRotation, timeDelta);

            transform.eulerAngles = new Vector3(transform.eulerAngles.x, _currentRotation, transform.eulerAngles.z);

            // If spin is complete, reset
            if (!(timeDelta > 1.0f))
            {
                return;
            }

            if (continuous)
            {
                _startTime = Time.time;
            }
            else
            {
                StopSpinning();
            }
        }

        /// <summary>
        /// Start the GameObject spinning
        /// </summary>
        [Button("Start Spin")]
        private void StartSpinning()
        {
            _startTime = Time.time;
            _isSpinning = true;
        }

        /// <summary>
        /// Stop the GameObject spinning
        /// </summary>
        [Button("Stop Spin")]
        private void StopSpinning()
        {
            _isSpinning = false;
        }

        [Button("Reset")]
        private void Reset()
        {
            _isSpinning = false;
            transform.eulerAngles = new Vector3(transform.eulerAngles.x, StartRotation, transform.eulerAngles.z);
        }
    }
}