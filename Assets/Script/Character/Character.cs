using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Character : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] protected float maxHealth;

    [SerializeField] protected float currentHealth;

    [Header("invulnerable")]
    public bool invulnerable;
    public float invlnerableDuration;

    public UnityEvent OnHurt;
    public UnityEvent OnDie;
    protected virtual void OnEnable()
    {
        currentHealth = maxHealth;
    }

    public virtual void TakeDamage(float damage)
    {
        if (invulnerable)  
            return;
        if (currentHealth - damage > 0f)
        {
            currentHealth -= damage;
            StartCoroutine(nameof(InvulnerableCoroutine)); // start invulnerable coroutine
            // execute hurt animation
            OnHurt?.Invoke();
        }
        else
        {
            //Death
            Die();
        }
        
    }

    public virtual void Die()
    {
        currentHealth = 0f;
        // execute dead animation
        OnDie?.Invoke();
    }

    //invurnerable
    protected virtual IEnumerator InvulnerableCoroutine()
    {
        invulnerable = true;

        //waitting for invunverable time
        yield return new WaitForSeconds(invlnerableDuration);

        invulnerable = false;
    }

}
