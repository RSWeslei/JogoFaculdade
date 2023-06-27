using System;
using System.Collections;
using UnityEngine;

public class InteractableObject : MonoBehaviour, IInteractable
{
    [SerializeField] private float proximityDistance = 4f;
    private Shading shading;
    private Player playerInstance;
    private void Start()
    {
        shading = GetComponent<Shading>();
        playerInstance = Player.Instance;
    }

    private void Update()
    {
        if (Player.Instance == null) return;
        if (Player.Instance.hittingObject == null) return;
        float distance = Vector3.Distance(Player.Instance.hittingObject.transform.position, playerInstance.transform.position);   
        
        // shading.enabled = distance <= proximityDistance;
        if (distance <= proximityDistance)
        {
            if (Player.Instance.hittingObject != null)
            {
                Player.Instance.hittingObject.GetComponent<Shading>().enabled = false;
            }
            shading.enabled = true;
            Player.Instance.hittingObject = transform;
        }
        else if (distance > proximityDistance)
        {
            shading.enabled = false;
            Player.Instance.hittingObject = null;
        }
    }

    public virtual void Interact()
    {
        UIManager.Instance.SetDialogMessage("Não há nada aqui.");
    }
}