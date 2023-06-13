using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private List<Transform> blackBackgrounds = new List<Transform>();
    [SerializeField] private List<Transform> cameraPositions = new List<Transform>();
    [SerializeField] private Camera mainCamera;
    [SerializeField] private GameObject backgroundObject;
    public int currentPosition = 0;

    [Header("Debug")] 
    [SerializeField] private bool enableBlackground = false; 
    void Start()
    {
        foreach (Transform t in transform)
        {
            cameraPositions.Add(t);
        }
        
        if (!enableBlackground)
        {
            return;
        }
        
        foreach (Transform t in backgroundObject.transform)
        {
            blackBackgrounds.Add(t);
            t.gameObject.SetActive(true);
        }

        mainCamera.transform.position = cameraPositions[currentPosition].position;
        blackBackgrounds[currentPosition].gameObject.SetActive(false);
    }

    public void SetCamera(int id)
    {
        mainCamera.transform.position = cameraPositions[id].transform.position;

        if (!enableBlackground)
        {
            blackBackgrounds[id].gameObject.SetActive(false);
            blackBackgrounds[currentPosition].gameObject.SetActive(true);
        }

        currentPosition = id;
    }
}
