using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    [SerializeField] private Button _damageButton;
    [SerializeField] private Button _healButton;

    public event UnityAction<int> DamageReceived;
    public event UnityAction<int> HealReceived;
    private int _damage = 10;
    private int _heal = 10;

    private void OnEnable()
    {
        _damageButton.onClick.AddListener(OnDamageButtonClick);
        _healButton.onClick.AddListener(OnHealButtonClick);
    }

    private void OnDamageButtonClick()
    {
        DamageReceived?.Invoke(_damage);
    }

    private void OnHealButtonClick()
    {
        HealReceived?.Invoke(_heal);
    }
}
