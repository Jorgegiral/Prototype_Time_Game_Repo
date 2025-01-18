using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class PlayerController2D : MonoBehaviour
{
    public float speed = 5;
    bool isFacingRight;

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
        if (input.moveInput.x > 0)
        {
            if (!isFacingRight)
            {
                Flip();
            }
        }
        if (input.moveInput.x < 0)
        {
            if (isFacingRight)
            {
                Flip();
            }
        }
    }
    private void FixedUpdate()
    {
        Move();
    }
    void Move()
    {
        playerRb.velocity = new Vector2(input.moveInput.x * speed, playerRb.velocity.y);
        playerRb.velocity = new Vector2(playerRb.velocity.x, input.moveInput.y * speed);

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
