using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    [SerializeField] private float raycastRadius = 1.5f;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private PlayerInputManager playerInput;

    public void Detect()
    {
        RaycastHit2D hit = Physics2D.CircleCast(transform.position, raycastRadius, Vector2.zero, 0f, layerMask);
        if (hit)
        {
            Debug.Log(hit.collider.name);
            IInteractable interactable = hit.collider.GetComponent<IInteractable>();
            if (interactable != null)
            {
                interactable.Interact();
            }
        }
    }

    private void OnEnable()
    {
        playerInput.OnInteract += Detect;
    }
    
    private void OnDisable()
    {
        playerInput.OnInteract -= Detect;
    }
}