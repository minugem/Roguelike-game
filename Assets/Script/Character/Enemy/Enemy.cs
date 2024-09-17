using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngineInternal;

public class Enemy : Character
{
    public UnityEvent<Vector2> OnMovementInput;

    public UnityEvent OnAttack;

    [SerializeField] private Transform player;

    [SerializeField] private float chaseDistance = 3f;

    [SerializeField] private float attackDistance = 0.8f;

    [Header("Attack")]
    public float meleeAttackDamage;
    public LayerMask playerLayer;
    public float AttackCooldownDuration = 2f;

    private bool isAttack = true;

    private SpriteRenderer sr;

    private void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (player == null)
            return;

        float distance = Vector2.Distance(player.position, transform.position);

        if (distance < chaseDistance) // less than chase distance
        {
            if (distance <= attackDistance) //if the player is in the chase distance
            {
                //attack player
                OnMovementInput?.Invoke(Vector2.zero);
                Debug.Log("Attacked");
                OnAttack?.Invoke();
                //check if player rotate
                float x=player.position.x - transform.position.x;
                if (x > 0)
                {
                    sr.flipX = true;
                }
                else
                {
                    sr.flipX = false;
                }

            }
            else
            {
                //chase player
                Vector2 direction = player.position - transform.position;
                OnMovementInput?.Invoke(direction.normalized); //transport move directions to enemy controller script
            }
        }
        else {
            //giveup chasing
            OnMovementInput?.Invoke(Vector2.zero);
        }
    }

    public void MeleeAttackAnimEvent()
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, attackDistance,playerLayer);

        foreach (Collider2D hitCollider in hitColliders)
        {
            hitCollider.GetComponent<Character>().TakeDamage(meleeAttackDamage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position,attackDistance);
    }
}
