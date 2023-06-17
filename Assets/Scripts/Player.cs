using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    private int _maxHealth = 100;
    private int _minHealth = 0;
    private int _currentHealth;

    public event UnityAction<int, int> HealthChanged;

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    public void ChangeHealth(int amountOfHealth)
    {
        _currentHealth += amountOfHealth;
        _currentHealth = Mathf.Clamp(_currentHealth, _minHealth, _maxHealth);
        HealthChanged.Invoke(_currentHealth, _maxHealth);
    }
}
