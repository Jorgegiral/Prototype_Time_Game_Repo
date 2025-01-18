using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; //Librería que maneja el new input system

public class PlayerInputHandle : MonoBehaviour
{
    public Vector2 moveInput;

    PlayerInput pInput;

    private void Awake()
    {
        pInput = GetComponent<PlayerInput>();
    }

    #region Input Methods
    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }
    #endregion

}
