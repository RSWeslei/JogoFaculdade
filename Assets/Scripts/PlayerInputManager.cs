using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputManager : MonoBehaviour
{
    public PlayerInputs PlayerInput { get; private set; }
    public Action<Vector2> OnMovement;
    void Awake()
    {
        PlayerInput = new PlayerInputs();
    }
    
    private void HandleMovement()
    {
        PlayerInput.Player.Movement.performed += ctx =>
        {
            OnMovement?.Invoke(ctx.ReadValue<Vector2>());
        };
        PlayerInput.Player.Movement.canceled += ctx =>
        {
            OnMovement?.Invoke(ctx.ReadValue<Vector2>());
        };
    }

    private void OnEnable()
    {
        PlayerInput.Player.Enable();
        HandleMovement();
    }
    
    private void OnDisable()
    {
        PlayerInput.Player.Disable();
    }
}
