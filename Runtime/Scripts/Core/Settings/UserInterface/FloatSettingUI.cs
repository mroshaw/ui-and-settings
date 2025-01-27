using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace DaftAppleGames.Settings
{
    [Serializable]
    public class FloatSettingUI : SettingUI
    {
        [SerializeField] private Slider slider;
        public UnityEvent<float> sliderValueChangedEvent;
        private void OnEnable()
        {
            slider.onValueChanged.AddListener(SliderValueChangedHandler);
        }

        private void OnDisable()
        {
            slider.onValueChanged.RemoveListener(SliderValueChangedHandler);
        }

        private void SliderValueChangedHandler(float newValue)
        {
            sliderValueChangedEvent?.Invoke(newValue);
        }

        public void SetSliderValue(float value)
        {
            slider.SetValueWithoutNotify(value);
        }

        public void SetSliderMinMax(float min, float max)
        {
            slider.minValue = min;
            slider.maxValue = max;
        }
    }
}