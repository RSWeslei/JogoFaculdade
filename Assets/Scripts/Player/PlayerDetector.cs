using System;
using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    [SerializeField] private float raycastRadius = 1.5f;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private PlayerInputManager playerInput;
    private Transform hittingObject;
    

    private void Detect()
    {
        RaycastHit2D hit = Physics2D.CircleCast(transform.position, raycastRadius, Vector2.zero, 0f, layerMask);
        if (hit)
        {
            Debug.Log(hit.collider.name);
            IInteractable interactable = hit.collider.GetComponent<IInteractable>();
            interactable?.Interact();
        }
    }

    // private void Update()
    // {
    //     RaycastHit2D hit = Physics2D.CircleCast(transform.position, raycastRadius, Vector2.zero, 0f, layerMask);
    //     if (hit)
    //     {
    //         if (Player.Instance == null) return;
    //         hittingObject = hit.transform;
    //         Shading shading = hit.transform.GetComponent<Shading>();
    //         shading.enabled = true;
    //     }
    // }

    private void OnEnable()
    {
        playerInput.OnInteract += Detect;
    }

    private void OnDisable()
    {
        playerInput.OnInteract -= Detect;
    }
}
