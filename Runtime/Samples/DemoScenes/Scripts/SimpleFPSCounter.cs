using TMPro;
using UnityEngine;
#if ODIN_INSPECTOR
using Sirenix.OdinInspector;
#else
using DaftAppleGames.Attributes;
#endif

namespace DaftAppleGames.Samples
{
    public class SimpleFPSCounter : MonoBehaviour
    {
        [BoxGroup("Settings")] [SerializeField] private int goodFrameRate = 60;
        [BoxGroup("Settings")] [SerializeField] private int warningFrameRate = 30;
        [BoxGroup("Settings")] [SerializeField] private int sampleFrames = 1;
        [BoxGroup("UI Settings")] [SerializeField] private TMP_Text averageCounterText;
        [BoxGroup("UI Settings")] [SerializeField] private TMP_Text currentCounterText;

        private int averageFrameRate;
        private int currentFrameRate;

        private void Update()
        {
            if (Time.frameCount % sampleFrames != 0)
            {
                return;
            }

            float currentFps = 1.0f / Time.deltaTime;
            float averageFps = Time.frameCount / Time.time;
            averageFrameRate = (int)averageFps;
            currentFrameRate = (int)currentFps;
            averageCounterText.SetText($"Average: {averageFrameRate.ToString()} FPS");
            currentCounterText.SetText($"Current: {currentFrameRate.ToString()} FPS");

            averageCounterText.color = GetTextColour(averageFrameRate);
            currentCounterText.color = GetTextColour(currentFrameRate);
        }

        private Color GetTextColour(int value)
        {
            if (value >= goodFrameRate)
            {
                return Color.green;
            }
            else if (value >= warningFrameRate)
            {
                return Color.yellow;
            }
            else
            {
                return Color.red;
            }
        }
    }
}