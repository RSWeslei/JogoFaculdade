using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputManager : MonoBehaviour
{
    private PlayerInputs _playerInput;
    public Vector2 MovementInput { get; private set; }
    void Awake()
    {
        _playerInput = new PlayerInputs();
    }
    
    private void HandleMovement()
    {
        _playerInput.Player.Movement.performed += ctx =>
        {
            MovementInput = ctx.ReadValue<Vector2>();
        };
    }

    private void OnEnable()
    {
        _playerInput.Player.Enable();
        HandleMovement();
    }
    
    private void OnDisable()
    {
        _playerInput.Player.Disable();
    }
}
