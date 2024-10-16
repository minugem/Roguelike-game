using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Character
{
    [Header("Melee Attack")]
    public float meleeAttackDamage;
    public Vector2 attackSize = new Vector2(1f, 1f);
    public float offsetX = 1f;
    public float offsetY = 1f;

    public LayerMask enemyLayer;
    public LayerMask destructibleLayer;
    private Vector2 AttackAreaPos;
    private SpriteRenderer spriteRenderer;
    internal int Experience;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    public void MeleeAttackAnimEvent(float isAttack)
    {
        AttackAreaPos = (Vector2)transform.position;

        offsetX = spriteRenderer.flipX ? -Mathf.Abs(offsetX) : Mathf.Abs(offsetX);

        AttackAreaPos.x += offsetX;
        AttackAreaPos.y += offsetY;

        Collider2D[] enemyHitColliders = Physics2D.OverlapBoxAll(AttackAreaPos,attackSize, 0f,enemyLayer);
        Collider2D[] destructiveHitColliders = Physics2D.OverlapBoxAll(AttackAreaPos, attackSize, 0f, destructibleLayer);

        //Determine whether it is an enemy
        foreach (Collider2D hitCollider in enemyHitColliders) 
        {
            hitCollider.GetComponent<Character>().TakeDamage(meleeAttackDamage * isAttack);
            hitCollider.GetComponent<EnemyController>().Knockback(transform.position);
        }
        //Determine whether it is an Object
        foreach (Collider2D hitCollider in destructiveHitColliders)
        {
            hitCollider.GetComponent<Destruct>().DestoryObject(); //desturct object
        }
    }

    //for testing
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(AttackAreaPos, attackSize);
    }
}
