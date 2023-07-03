using System;
using System.Collections;
using UnityEngine;

public class InteractableObject : MonoBehaviour, IInteractable
{
    [HideInInspector] public Shading shading;
    [TextArea(3, 10)]
    [SerializeField] private string message;
    private void Awake()
    {
        shading = GetComponent<Shading>();
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Player.Instance.SetHittingObject(transform);
            if (shading != null)
            {
                shading.enabled = true;
            }
        }
    }
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Transform hittingObject = Player.Instance.hittingObject;
            if (hittingObject && hittingObject.CompareTag("Interactable") && hittingObject != transform)
            {
                return;
            }
            Player.Instance.SetHittingObject(null);
            if (shading != null)
            {
                shading.enabled = false;
            }
            PlayerDetector.ToggleDetector();
        }
    }

    public virtual void Interact()
    {
        UIManager.Instance.SetDialogMessage(message);
        SoundManager.Instance.PlaySound(SoundManager.Sound.Interact);
        Player.Instance.SetHittingObject(null);
        gameObject.layer = 0;
        Destroy(shading);
        Destroy(this);
    }
}