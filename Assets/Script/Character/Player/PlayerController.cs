using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    public InputActions inputActions;

    public Vector2 inputDirection;

    public float moveSpeed;
    private Rigidbody2D rb;
    private SpriteRenderer sr;

    private Animator anim;

    [Header("MeleeAttack")]
    public bool isMeleeAttack;
    [Header("Dodge")]
    public bool isDodging = false;

    public float dodgeForce;
    public float dodgeTimer = 0;
    public float dodgeDuration = 0f;

    public bool isDead;
    public void Awake()
    {
        inputActions = new InputActions();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();

        //melee attack
        inputActions.Gameplay.MeleeAttack.started += MeleeAttack;

        //doge
        inputActions.Gameplay.Dodge.started += isDodge;
    }



    private void OnEnable()
    {
        inputActions.Enable();
    }

    private void OnDisable()
    {
        inputActions.Disable();
    }

    private void Update()
    {
        inputDirection = inputActions.Gameplay.Move.ReadValue<Vector2>();
        //Debug.Log(inputDirection);
        SetAnimation();
    }

    private void FixedUpdate()
    {
        Move();

        Dodge();
    }

    private void Move()
    {
        rb.velocity = inputDirection * moveSpeed;

        if (inputDirection.x < 0) // turn left
        {
            sr.flipX = true;
        }
        if (inputDirection.x > 0) // turn right
        {
            sr.flipX = false;
        }
    }

    void Dodge()
    {
        if (isDodging) 
        {
            if (dodgeTimer <= dodgeDuration)
            {
                //apply dodge force
                rb.AddForce(inputDirection * dodgeForce, ForceMode2D.Impulse);

                dodgeTimer += Time.fixedDeltaTime;
            }
            else {
                //dodge finished
                isDodging = false;
                dodgeTimer = 0f;
            }
        }
    }
    private void MeleeAttack(InputAction.CallbackContext context)
    {
        anim.SetTrigger("meleeAttack");
        isMeleeAttack = true;
    }

    public void PlayerHurt()
    {
        anim.SetTrigger("hurt");
    }

    public void PlayerDead()
    {
        isDead = true;
        // Disable gameplay input
        inputActions.Gameplay.Disable();

    }

    private void isDodge(InputAction.CallbackContext context)
    {
        isDodging = true;
    }
    void SetAnimation()
    {
        anim.SetBool("isDodge", isDodging);
        anim.SetFloat("speed", rb.velocity.magnitude);
        anim.SetBool("isMeleeAttack", isMeleeAttack);
        anim.SetBool("isDead", isDead);
        
    }
}

