using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.UI; //Librería para que funcione el New Input System

public class PlayerController2D : MonoBehaviour
{

    
    //Referencias generales
    Rigidbody2D playerRb; //Ref al rigidbody del player 
    PlayerInput playerInput; //Ref al gestor del input del jugador
    Animator playerAnim; //Ref al animator para gestionar las transiciones de animación

    private Vector2 moveInput;
    public int life;
    public float hitForce;
    public bool isdead;
    private bool damaged;
    private float damageCooldown = 1f;
    private float damageTimer;

    [Header ("Movement Parameters")]
    public float speed;

    [SerializeField] bool isFacingRight;

    [Header ("Jump Parameters")]
    public float jumpForce;

    [SerializeField] bool isGrounded;
    [SerializeField] Transform groundCheck;
    [SerializeField] float groundCheckRadius = 0.1f;
    [SerializeField] LayerMask groundLayer;


    void Start()
    {
        //Autoreferenciarcomponentes: nombre de variable = GetComponent
        playerRb = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();
        playerAnim = GetComponent<Animator>();
        isFacingRight = true;
    }

    // Update is called once per frame
    void Update()
    {
        HandleAnimations();
        GroundCheck();

      //Flip
      if (moveInput.x > 0)
        {
            if (!isFacingRight)
            {
                Flip();
            }
        }
      if (moveInput.x < 0)
        {
            if (isFacingRight)
            {
                Flip();
            }
        }

        if (damaged)
        {
            damageTimer -= Time.deltaTime;
            if (damageTimer <= 0)
            {
                damaged = false;
            }
        }
    }

    private void FixedUpdate()
    {
        Movement();
    }
    void Movement()
    {
       playerRb.velocity = new Vector2(moveInput.x * speed, playerRb.velocity.y);
    }

   
    void Flip()
    {
        Vector3 currentScale = transform.localScale;
        currentScale.x *= -1;
        transform.localScale = currentScale;
        isFacingRight = !isFacingRight; //nombre de bool = !nombre de bool (cambio al estado contrario)
    }

    void GroundCheck()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }

    void HandleAnimations()
    {
        playerAnim.SetBool("isJumping", !isGrounded);
        playerAnim.SetFloat("VelocityY", playerRb.velocity.y);
        playerAnim.SetBool("isRunning", Mathf.Abs(moveInput.x) > 0.1f);

    }

    public void damage(Vector2 direction, int cantDamage)
    {
        if (!damaged)
        {
            damaged = true;
            damageTimer = damageCooldown;
            life -= cantDamage;
            if (life <= 0)
            {
                isdead = true;
            }
            if (!isdead)
            {
                Vector2 hit = direction.normalized * hitForce;
                playerRb.AddForce(hit * hitForce, ForceMode2D.Impulse);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            damage(other.transform.position - transform.position, 10); 
        }
    }

    #region Input Events

    public void HandleMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }
    public void HandleJump(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            if (isGrounded)
            {
                playerRb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }
        }
    }

    #endregion



}
