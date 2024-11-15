using System;
using UnityEngine;
using UnityEngine.UI;

namespace Script.UI
{
    public class VolumeSliderUI : MonoBehaviour
    {
        [SerializeField] private Slider slider;

        public Action<float> OnValueChanged;

        private void Start()
        {
            slider.onValueChanged.AddListener(OnSliderValueChanged);
        }

        private void OnSliderValueChanged(float value)
        {
            OnValueChanged?.Invoke(value);
        }
    }
}
