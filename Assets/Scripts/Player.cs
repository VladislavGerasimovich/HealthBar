using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] private Buttons _buttons;

    private int _health = 100;
    private int _currentHealth;

    public event UnityAction<int, int> HealthChanged;

    private void Start()
    {
        _currentHealth = _health;
    }

    private void OnEnable()
    {
        _buttons.DamageReceived += ApplyDamage;
        _buttons.HealReceived += RestoreHealth;
    }

    private void OnDisable()
    {
        _buttons.DamageReceived -= ApplyDamage;
        _buttons.HealReceived -= RestoreHealth;
    }

    private void ApplyDamage(int damage)
    {
        if(_currentHealth > 0)
        {
            _currentHealth -= damage;
            HealthChanged.Invoke(_currentHealth, _health);
        }
    }

    private void RestoreHealth(int healing)
    {
        if (_currentHealth < _health)
        {
            _currentHealth += healing;
            HealthChanged.Invoke(_currentHealth, _health);
        }
    }
}
