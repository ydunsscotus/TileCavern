using System.Collections;
using System.Collections.Generic;
// using System.Numerics;
// using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMovement : MonoBehaviour
{

    [SerializeField] float runSpeed = 10f;
    [SerializeField] float jumpSpeed = 5f;
    [SerializeField] float climbSpeed = 8f;
    [SerializeField] Vector2 deathKick = new Vector2 (10f, 10f);
    [SerializeField] GameObject bullet;
    [SerializeField] Transform spawnPoint;
    Rigidbody2D rb;
    Vector2 moveInput;
    Animator animator;
    BoxCollider2D FeetCollider;
    CapsuleCollider2D BodyCollider;
    float gravityScaleAtStart;
    bool isAlive = true;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        BodyCollider= GetComponent<CapsuleCollider2D>();
        FeetCollider = GetComponent<BoxCollider2D>();
        gravityScaleAtStart = rb.gravityScale;
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!isAlive){
            return;
        }
        Run();
        FlipSprite();
        ClimbLadder();
        Die();

        
    }

    void OnFire(InputValue value)
    {
        if(!isAlive){
            return;
        }
        Instantiate(bullet, spawnPoint.position, transform.rotation);

    }

    void OnMove(InputValue value)
    {
        if(!isAlive){
            return;
        }
        moveInput = value.Get<Vector2>();
        Debug.Log(moveInput);

    }

    void OnJump(InputValue value)
    {
        if(!isAlive){
            return;
        }
        if (!FeetCollider.IsTouchingLayers(LayerMask.GetMask("Ground")))
        {
            return;
        }
        if(value.isPressed)
        {
            rb.velocity += new Vector2 (0f, jumpSpeed);
        }
    }

    void Run()
    {
        Vector2 playerVelocity = new Vector2 (moveInput.x * runSpeed, rb.velocity.y);
        rb.velocity = playerVelocity;

        bool playerHasHorizontalSpeed = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;
        animator.SetBool("isRunning", playerHasHorizontalSpeed);
    }
    void FlipSprite()
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(rb.velocity.x) > Mathf.Epsilon;

        if(playerHasHorizontalSpeed)
        {
            transform.localScale = new Vector2(Mathf.Sign(rb.velocity.x), 1f);
        }
        
    }

    void ClimbLadder()
    {
        if (!FeetCollider.IsTouchingLayers(LayerMask.GetMask("Climbing")))
        {
            rb.gravityScale = gravityScaleAtStart;
            animator.SetBool("isClimbing", false);
            return;
        }

        Vector2 ClimbVelocity = new Vector2 (rb.velocity.x, moveInput.y * climbSpeed);
        rb.velocity = ClimbVelocity;
        rb.gravityScale = 0f;

        bool playerHasVerticalSpeed = Mathf.Abs(rb.velocity.y) > Mathf.Epsilon;

        animator.SetBool("isClimbing", playerHasVerticalSpeed);
    }
    void Die()
    {
        if(BodyCollider.IsTouchingLayers(LayerMask.GetMask("Enemies", "Dangerous")))
        {
            isAlive = false;
            animator.SetTrigger("Dying");
            rb.velocity = deathKick;
        }

    }

}
