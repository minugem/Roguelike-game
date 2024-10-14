using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] private float currentSpeed = 0;

    public Vector2 MovementInput { get; set; }

    [Header("Attack")]
    [SerializeField] private bool isAttack = true;
    [SerializeField] private float attackCoolDown = 1;

    [Header("Repelled")]
    [SerializeField] private bool isKnocked = true;
    [SerializeField] private float KnockForce = 10f;
    [SerializeField] private float KnockDuration = 0.1f;

    private Rigidbody2D rb;
    private Collider2D enemyCollider;
    private SpriteRenderer sr;
    private Animator anim;

    private bool isHurt;
    private bool isDead;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        enemyCollider = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();

    }

    private void FixedUpdate()
    {
        if (!isHurt && !isDead) 
        Move();

        SetAnimation();
    }

    void Move()
    {
        if (MovementInput.magnitude > 0.1f && currentSpeed >= 0)
        {
            rb.velocity = MovementInput * currentSpeed;

            if (MovementInput.x < 0)
            {
                sr.flipX = false;
            }
            if (MovementInput.x > 0)
            {
                sr.flipX = true;
            }
        }
        else {
            rb.velocity = Vector2.zero;
        }
    }

    public void Attack()
    {
        Debug.Log("Attack started");
        if (isAttack) 
        {
            isAttack = false;
            StartCoroutine(nameof(AttackCoroutine));
        }
    }

    IEnumerator AttackCoroutine()
    {
        anim.SetTrigger("isAttack");
        yield return new WaitForSeconds(attackCoolDown);
        isAttack = true;

    }

    public void EnemyHurt()
    {
        isHurt = true;
        anim.SetTrigger("isHurt");
    }

    public void Knockback(Vector3 pos)
    {
        if (!isKnocked || isDead)
        {
            return;
        }
        StartCoroutine (KnockbackCoroutine(pos));
    }

    IEnumerator KnockbackCoroutine(Vector3 pos)
    {
        var direction = (transform.position - pos).normalized;
        rb.AddForce(direction* KnockForce, ForceMode2D.Impulse);
        yield return new WaitForSeconds(KnockDuration);
        isHurt = false;
    }



    public void EnemyDead()
    {
        rb.velocity = Vector2.zero;
        isDead = true;
        enemyCollider.enabled = false;
        FindObjectOfType<EnemySpawner>().currentEnemyCount--;
    }

    void SetAnimation()
    {
        anim.SetBool("isWalk", MovementInput.magnitude > 0);
        anim.SetBool("isDead",isDead);
    }

    public void DestroyEnemy()
    {
        Destroy(this.gameObject);
    }

}
