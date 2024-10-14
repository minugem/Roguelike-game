using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

public class Enemy : Character
{
    public UnityEvent OnAttack;

    [SerializeField] private Transform player;
    [SerializeField] private float chaseDistance = 3f;       // Distance within which the enemy chases the player
    [SerializeField] private float attackDistance = 0.8f;    // Distance within which the enemy attacks the player
    [SerializeField] private float patrolRadius = 1f;        // Radius for patrolling around the player
    [SerializeField] private float patrolSpeed = 2f;         // Speed for patrolling around the player
    [Header("Attack")]
    public float meleeAttackDamage;
    public LayerMask playerLayer;
    public float AttackCooldownDuration = 2f;

    private bool isAttackCooldown = false;
    private NavMeshAgent agent;
    private SpriteRenderer sr;
    private EnemyController enemyController;
    private bool isPatrolling = false;
    private float patrolAngle = 0f;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        sr = GetComponent<SpriteRenderer>();
        enemyController = GetComponent<EnemyController>();

        // Disable automatic rotation
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        player = FindObjectOfType<Player>().transform;
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
                if (distance <= patrolRadius)
                {
                    // Patrol around the player
                    PatrolAroundPlayer();
                    isPatrolling = true;
                }
                else
                {
                    // Move towards player
                    agent.SetDestination(player.position);
                    isPatrolling = false;
                }
            }
        }
        else
        {
            agent.SetDestination(transform.position); // Stop moving
            isPatrolling = false;
        }

        FacePlayer();
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

    public void MeleeAttackAnimEvent()
    {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, attackDistance, playerLayer);

        foreach (Collider2D hitCollider in hitColliders)
        {
            hitCollider.GetComponent<Character>().TakeDamage(meleeAttackDamage);
        }
    }

    private void PatrolAroundPlayer()
    {
        // Calculate a position in a circular pattern around the player
        patrolAngle += patrolSpeed * Time.deltaTime;
        Vector3 offset = new Vector3(Mathf.Cos(patrolAngle), Mathf.Sin(patrolAngle), 0) * patrolRadius;
        Vector3 patrolPosition = player.position + offset;

        agent.SetDestination(patrolPosition);
    }

    private void FacePlayer()
    {
        float x = player.position.x - transform.position.x;
        sr.flipX = x > 0;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackDistance); // Attack distance visualization
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, chaseDistance); // Chase distance visualization
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, patrolRadius); // Patrol radius visualization
    }
}
