using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    private int _maxHealth = 100;
    private int _currentHealth;
    private int _damage = 10;
    private int _heal = 10;

    public event UnityAction<int, int> HealthChanged;

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    public void ApplyDamage()
    {
        if(_currentHealth > 0)
        {
            _currentHealth -= _damage;
            HealthChanged.Invoke(_currentHealth, _maxHealth);
        }
    }

    public void RestoreHealth()
    {
        if (_currentHealth < _maxHealth)
        {
            _currentHealth += _heal;
            HealthChanged.Invoke(_currentHealth, _maxHealth);
        }
    }
}
