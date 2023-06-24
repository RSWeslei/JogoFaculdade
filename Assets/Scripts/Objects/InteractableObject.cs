using System;
using System.Collections;
using UnityEngine;

public class InteractableObject : MonoBehaviour
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
        float distance = Vector3.Distance(transform.position, playerInstance.transform.position);   
        
        shading.enabled = distance <= proximityDistance;      
    }
}
