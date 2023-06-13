using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDetector : MonoBehaviour
{
    [SerializeField] private int cameraPositionID;

    [SerializeField] private CameraManager cameraManager;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (cameraManager.currentPosition == cameraPositionID) {
                return;
            }
            Debug.Log(cameraPositionID);
            cameraManager.SetCamera(cameraPositionID);
        }
    }
}
