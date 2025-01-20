using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering.UI; //Librería para que funcione el New Input System

public class PlayerController2D : MonoBehaviour
{

    
    //Referencias generales
    [SerializeField] Rigidbody2D playerRb; //Ref al rigidbody del player 
    [SerializeField] PlayerInput playerInput; //Ref al gestor del input del jugador
    [SerializeField] Animator playerAnim; //Ref al animator para gestionar las transiciones de animación

    [Header("Movement Parameters")]

    private Vector2 moveInput; //Almacén del input del player
    public float speed;
    [SerializeField] bool isFacingRight;

    [Header ("Jump Parameters")]
    public float jumpForce;

    [SerializeField] bool isGrounded;

    //Variables para el Groundcheck

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
        //Conector de parámetros de cambios de animación
        playerAnim.SetBool("IsJumping", !isGrounded);
        if (moveInput.x > 0 || moveInput.x < 0) playerAnim.SetBool("IsRunning", true);
        else playerAnim.SetBool("IsRunning", false);
    }

    #region Input Events
    //Para crea un evento:
    //Se define PUBLIC sin tipo de dato (VOID) y con una referencia al input (Callback.Context)

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
