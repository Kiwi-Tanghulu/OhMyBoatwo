using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShipHealth : MonoBehaviour, IDamageable
{
    [SerializeField] private float maxHealth;
    private float currentHealth;

    public UnityEvent onDamaged;
    public UnityEvent onSinked;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void OnDamaged(float damage, Transform attacker)
    {
        currentHealth = Mathf.Max(currentHealth - damage, 0f);
        onDamaged?.Invoke();

        if(currentHealth <= 0f)
        {
            Sink();
        }
    }

    private void Sink()
    {
        Debug.Log("sink");
        onSinked?.Invoke();
    }
}
