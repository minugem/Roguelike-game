using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class Enemy : Character
{
    public UnityEvent OnAttack;

    [SerializeField] private Transform player;
    [SerializeField] private float chaseDistance = 3f;       // Distance within which the enemy chases the player
    [SerializeField] private float attackDistance = 0.8f;    // Distance within which the enemy attacks the player
    [Header("Attack")]
    public float meleeAttackDamage;
    public LayerMask playerLayer;
    public float AttackCooldownDuration = 2f;

    private bool isAttackCooldown = false;
    private NavMeshAgent agent;
    private SpriteRenderer sr;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        sr = GetComponent<SpriteRenderer>();

        // Disable automatic rotation
        agent.updateRotation = false;
    }

    private void Update()
    {
        if (player == null)
            return;

        float distance = Vector2.Distance(player.position, transform.position);

        if (distance <= chaseDistance)
        {
            if (distance <= attackDistance && !isAttackCooldown)
            {
                // Attack player
                StartCoroutine(Attack());
            }
            else
            {
                // Move towards player
                agent.SetDestination(player.position);
                FacePlayer();
            }
        }
        else
        {
            agent.SetDestination(transform.position); // Stop moving
        }

        // Fix the X rotation while allowing Y and Z rotations to change
        FixXRotation();
    }

    private IEnumerator Attack()
    {
        OnAttack?.Invoke();
        Debug.Log("Attacking player");
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, attackDistance, playerLayer);
        foreach (Collider2D hitCollider in hitColliders)
        {
            hitCollider.GetComponent<Character>().TakeDamage(meleeAttackDamage);
        }

        isAttackCooldown = true;
        yield return new WaitForSeconds(AttackCooldownDuration);
        isAttackCooldown = false;
    }

    private void FacePlayer()
    {
        // Determine the direction to the player
        float x = player.position.x - transform.position.x;

        // Flip the sprite based on the player's position
        sr.flipX = x > 0; // Flip if the player is to the right
    }

    private void FixXRotation()
    {
        // Fix the X rotation while allowing Y and Z to rotate freely
        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
    }

    public void MeleeAttackAnimEvent()
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, attackDistance, playerLayer);

        foreach (Collider2D hitCollider in hitColliders)
        {
            hitCollider.GetComponent<Character>().TakeDamage(meleeAttackDamage);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackDistance); // Attack distance visualization
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, chaseDistance); // Chase distance visualization
    }
}
