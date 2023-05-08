using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    private static readonly int MovementX = Animator.StringToHash("MovementX");
    private static readonly int MovementY = Animator.StringToHash("MovementY");
    private Animator _animator;
    private Rigidbody2D _rigidbody2D;
    
    [SerializeField] private PlayerInputManager playerInput;
    [SerializeField] private float movementSpeed = 5f;

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Movement()
    {
        Vector3 movement = playerInput.PlayerInput.Player.Movement.ReadValue<Vector2>().normalized;
        _rigidbody2D.velocity = movement * movementSpeed;
    }

    private void Update()
    {
        Movement();
    }

    private void Animate(Vector2 movement)
    {
        _animator.SetFloat(MovementX, movement.x);
        _animator.SetFloat(MovementY, movement.y);
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
