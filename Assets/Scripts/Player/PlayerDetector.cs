using System;
using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    [SerializeField] private PlayerInputManager playerInput;
    private static Collider2D[] _colliders;

    private void Start()
    {
        _colliders = GetComponents<Collider2D>();
    }

    private void Detect()
    {
        if (Player.Instance.hittingObject != null)
        {
            IInteractable interactable = Player.Instance.hittingObject.GetComponent<IInteractable>();
            interactable?.Interact();
        }
    }
    
    public static void ToggleDetector()
    {
        foreach (Collider2D collider in _colliders)
        {
            collider.enabled = false;
            collider.enabled = true;
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
