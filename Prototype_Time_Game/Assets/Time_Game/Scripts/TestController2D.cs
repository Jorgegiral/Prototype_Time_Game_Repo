using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class TestController2D : MonoBehaviour
{
    public float speed = 5;
    bool isFacingRight;
    bool isRunning;
    float rx;
    float ry;

    Rigidbody2D playerRb;
    PlayerInputHandle input;
    Animator playerAnim;
    
    private void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>();
        input = GetComponent<PlayerInputHandle>();
        playerAnim = GetComponent<Animator>();
    }
    
    void Update()
    {
        if (input.moveInput.x > 0 && !isFacingRight)
        {
            Flip();
        }
        if (input.moveInput.x < 0 && isFacingRight)
        {
            Flip();
        }
    }
    private void FixedUpdate()
    {
        Move();
    }
    void Move()
    {
        rx = input.moveInput.x * speed;
        ry = input.moveInput.y * speed;

        playerRb.velocity = new Vector2(rx, ry);

        isRunning = playerRb.velocity.magnitude > 0.1f;

        if (isRunning)
        {
            playerAnim.SetFloat("X", rx);
            playerAnim.SetFloat("Y", ry);
        }
        playerAnim.SetBool("isRunning", isRunning);
    }
    void Flip()
    {
        Vector3 currentScale = transform.localScale;
        currentScale.x *= -1;
        transform.localScale = currentScale;
        isFacingRight = !isFacingRight; //nombre de bool = !nombre de bool (cambio al estado contrario)
    }
    public void HandleMove(InputAction.CallbackContext context)
    {
        input.moveInput = context.ReadValue<Vector2>();
    }
}
