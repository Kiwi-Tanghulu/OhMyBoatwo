using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour, IDamageable
{
    [SerializeField] private float maxHealth;
    private float currentHealth;
    public float CurrentHealth => currentHealth;

    public UnityEvent<float> onDamaged;
    public UnityEvent<float> onHealed;
    public UnityEvent onDied;

    protected virtual void Start()
    {
        currentHealth = maxHealth;
    }

    // private void Update()
    // {
    //     if(Input.GetKeyDown(KeyCode.Space))
    //         OnDamaged(100, null);
    // }

    public void OnDamaged(float damage, Transform attacker)
    {
        currentHealth = Mathf.Max(currentHealth - damage, 0f);
        onDamaged?.Invoke(damage);

        if(currentHealth <= 0f)
        {
            Die();
        }
    }

    public void Heal(float healAmount)
    {
        currentHealth += healAmount;

        onHealed?.Invoke(healAmount);
    }

    private void Die()
    {
        Debug.Log("die");
        onDied?.Invoke();
    }
}
