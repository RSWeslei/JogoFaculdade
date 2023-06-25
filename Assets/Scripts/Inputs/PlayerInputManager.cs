using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInputManager : MonoBehaviour
{
    public PlayerInputs PlayerInput { get; private set; }
    public Action OnInteract;
    public Action<Vector2> OnMovement;
    public Action OnAnyKey;
    
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
    
    private void HandleInteract()
    {
        PlayerInput.Player.Interact.performed += ctx =>
        {   
            OnInteract?.Invoke();
        };
    }
    
    private void HandleWaitInput()
    {
        PlayerInput.UI.WaitInput.performed += ctx =>
        {
            OnAnyKey?.Invoke();
        };
    }
    
    public void ToggleInputs(bool toggle)
    {
        if (toggle)
        {
            PlayerInput.Player.Enable();
            HandleMovement();
            HandleInteract();
            return;
        }
        PlayerInput.Player.Disable();
    }
    
    public void ToggleWaitInput(bool toggle)
    {
        if (toggle)
        {
            PlayerInput.UI.WaitInput.Enable();
            HandleWaitInput();
            return;
        }
        PlayerInput.UI.WaitInput.Disable();
    }

    private void OnEnable()
    {
        PlayerInput.Player.Enable();
        HandleMovement();
        HandleInteract();
    }
    
    private void OnDisable()
    {
        PlayerInput.Player.Disable();
    }
}
