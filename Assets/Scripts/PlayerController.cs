using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    private static readonly int MovementX = Animator.StringToHash("MovementX");
    private static readonly int MovementY = Animator.StringToHash("MovementY");
    
    [SerializeField] private PlayerInputManager playerInput;
    [SerializeField] private float movementSpeed = 5f;
    [SerializeField] private Animator animator;

    private void Movement()
    {
        Vector3 movement = playerInput.PlayerInput.Player.Movement.ReadValue<Vector2>().normalized;
        transform.position += movement * (movementSpeed * Time.deltaTime);
    }

    private void Update()
    {
        Movement();
    }

    private void Animate(Vector2 movement)
    {
        animator.SetFloat(MovementX, movement.x);
        animator.SetFloat(MovementY, movement.y);
    }

    private void OnEnable()
    {
        playerInput.OnMovement += Animate;
    }
    
    private void OnDisable()
    {
        playerInput.OnMovement -= Animate;
    }
}
