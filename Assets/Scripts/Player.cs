using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    private int _minHealth;

    public event UnityAction<int, int> HealthChanged;

    public int MaxHealth {  get; private set; }
    public int CurrentHealth { get; private set; }

    private void Awake()
    {
        _minHealth = 0;
        MaxHealth = 100;
        CurrentHealth = MaxHealth;
    }

    public void TakeDamage(int amountOfHealth)
    {
        CurrentHealth += amountOfHealth;
        CurrentHealth = Mathf.Clamp(CurrentHealth, _minHealth, MaxHealth);
        HealthChanged.Invoke(CurrentHealth, MaxHealth);
    }

    public void IncreaseHealth(int amountOfHealth)
    {
        CurrentHealth += amountOfHealth;
        CurrentHealth = Mathf.Clamp(CurrentHealth, _minHealth, MaxHealth);
        HealthChanged.Invoke(CurrentHealth, MaxHealth);
    }
}
