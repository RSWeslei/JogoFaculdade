using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private List<Transform> cameraPositions = new List<Transform>();
    public int CurrentPosition = 0;
    void Start()
    {
        foreach (Transform t in transform)
        {
            cameraPositions.Add(t);
        }

        mainCamera.transform.position = cameraPositions[0].position;
    }

    // Update is called once per frame
    public void SetCamera(int id)
    {
        mainCamera.transform.position = cameraPositions[id].transform.position;
        CurrentPosition = id;
    }
}
