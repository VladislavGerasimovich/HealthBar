using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;
    [SerializeField] private Player _player;

    private Coroutine _changeValueJob;
    private float _nextValue;
    private float _duration = 1.5f;

    private void OnEnable()
    {
        _player.HealthChanged += OnValueChanged;
        _slider.value = 1;
    }

    private void OnDisable()
    {
        _player.HealthChanged -= OnValueChanged;
    }

    private void OnValueChanged(int value, int maxValue)
    {
        _nextValue = (float)value / maxValue;
        _changeValueJob = StartCoroutine(ChangeValue());
    }

    private IEnumerator ChangeValue()
    {
        float elapsedTime = 0;
        float currentValue = _slider.value;

        while(elapsedTime < _duration)
        {
            elapsedTime += Time.deltaTime;
            _slider.value = Mathf.Lerp(currentValue, _nextValue, elapsedTime/_duration);
            yield return null;
        }

        StopCoroutine(_changeValueJob);
    }
}
