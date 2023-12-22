using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private TMP_Text _currentHealthValue;
    [SerializeField] private TMP_Text _maxHealthValue;
    [SerializeField] private Slider _slider;
    [SerializeField] private Slider _smoothSlider;
    [SerializeField] private Player _player;

    private float _nextValue;
    private float _duration;

    private void OnEnable()
    {
        _player.HealthChanged += OnValueChanged;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= OnValueChanged;
    }

    private void Awake()
    {
        _currentHealthValue.text = "100";
        _maxHealthValue.text = $"/ {100}";
        _slider.value = 1;
        _smoothSlider.value = 1;
        _duration = 1.5f;
    }

    private void OnValueChanged(int value, int maxValue)
    {
        _nextValue = (float)value / maxValue;
        _slider.value = _nextValue;
        _currentHealthValue.text = value.ToString();
        _maxHealthValue.text = $"/ {maxValue.ToString()}";
        StartCoroutine(ChangeValue());
    }

    private IEnumerator ChangeValue()
    {
        float elapsedTime = 0;
        float currentValue = _smoothSlider.value;

        while(elapsedTime < _duration)
        {
            elapsedTime += Time.deltaTime;
            _smoothSlider.value = Mathf.Lerp(currentValue, _nextValue, elapsedTime/_duration);

            yield return null;
        }
    }
}
