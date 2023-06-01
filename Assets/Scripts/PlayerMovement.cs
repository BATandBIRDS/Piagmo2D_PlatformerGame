using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float runSpeed = 8f;
    [SerializeField] float jumpSpeed = 15f;
    [SerializeField] ParticleSystem swordTrailFX;
    [SerializeField] GameObject bloodFX;

    Vector2 moveInput;
    Rigidbody2D rb;
    Animator animator;
    CapsuleCollider2D capsuleCollider; // for all other Player interactions
    BoxCollider2D feet; // for ground touching check.
    bool isAlive;

    void Start()
    {
        isAlive = true;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();
        feet = GetComponent<BoxCollider2D>();
    }

    void Update()
    {
        if (!isAlive) { return; }
        Run();
        FlipSprite();
        Die();
    }

    #region Input Functions
    void OnMove(InputValue value)
    {
        if (!isAlive) { return; }
        moveInput = value.Get<Vector2>();
        //Debug.Log(moveInput);
    }
    
    void OnJump(InputValue value)
    {
        if (!isAlive) { return; }
        if (!feet.IsTouchingLayers(LayerMask.GetMask("Ground")) && !capsuleCollider.IsTouchingLayers(LayerMask.GetMask("Climb"))) { return; }
        if (value.isPressed)
        {
            //Debug.Log("jumping");
            rb.velocity += new Vector2(0f, jumpSpeed);
        }
    }

    void OnFire(InputValue value)
    {
        if (!isAlive) { return; }
        animator.SetTrigger("attack");
        swordTrailFX.Play();
    }
    #endregion

    #region Movement Mechanics
   
    void Run()
    {
        Vector2 playerVelocity = new Vector2(moveInput.x * runSpeed, rb.velocity.y);
        rb.velocity = playerVelocity;

        bool playerHasHorizontalSpeed = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;
        animator.SetBool("isMoving", playerHasHorizontalSpeed);
    }

    void FlipSprite()
    {// Turning Right-Left mechanics
     // using *-1 with horizontal scale value
        bool playerHasHorizontalSpeed = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;

        if (playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2(-Mathf.Sign(rb.velocity.x), 1f);
        }
    }

    void Die()
    {
        if (!capsuleCollider.IsTouchingLayers(LayerMask.GetMask("Enemy")))
        {
            return;
        }
        isAlive = false;
        animator.SetTrigger("death");
        FindObjectOfType<GameSession>().ProcessPlayerDeath();
    }
    
    #endregion

    public float GetPlayerVelocity()
    {// Using by BG_Mover.cs
        return moveInput.x * Time.deltaTime;
    }
    
    public void SetIsAliveFalse()
    {// for TimeManager.cs
        isAlive = false;
    }
}
