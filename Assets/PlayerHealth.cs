using System;
using System.Collections;
using Unity.Hierarchy;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float MaxHealth = 100;
    private float health;
    private bool canRecieveDamage = true;
    public float invincibilityTimer = 2;

    public delegate void HealthChangedHandler(float health, float amountChanged);
    public event HealthChangedHandler OnHealthChanged;

    void Start()
    {
        health = MaxHealth;
    }
    void Update()
    {
        
    }

    public void AddDamage(float damage)
    {
        if (canRecieveDamage)
        {
            health -= damage;
            OnHealthChanged?.Invoke(health, -damage);
            canRecieveDamage = false;
            StartCoroutine(InvincibilityTimer(invincibilityTimer, ResetInvincibility));
        }
        Debug.Log(health);
    }
    IEnumerator InvincibilityTimer(float time, Action callback)
    {
        yield return new WaitForSeconds(time);
        callback.Invoke();
    }

    private void ResetInvincibility()
    {
        canRecieveDamage = true;
        Debug.Log("reset");
    }
    public void AddHealth(float heal)
    {
        health += heal;
        OnHealthChanged?.Invoke(health, heal);
        Debug.Log(health);
    }
}
