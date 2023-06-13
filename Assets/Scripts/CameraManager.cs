using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

public class CameraManager : MonoBehaviour
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private List<Transform> cameraPositions = new List<Transform>();
    [FormerlySerializedAs("backgrounds")] [SerializeField] private List<Transform> blackBackgrounds = new List<Transform>();
    [SerializeField] private GameObject backgroundObject;
    public int CurrentPosition = 0;

    [Header("Debug")] 
    [SerializeField] private bool enableBlackground = false; 
    void Start()
    {
        foreach (Transform t in transform)
        {
            cameraPositions.Add(t);
        }

       
        
        foreach (Transform t in backgroundObject.transform)
        {
            blackBackgrounds.Add(t);
            t.gameObject.SetActive(true);
        }

        mainCamera.transform.position = cameraPositions[CurrentPosition].position;
        blackBackgrounds[CurrentPosition].gameObject.SetActive(false);
    }

    // Update is called once per frame
    public void SetCamera(int id)
    {
        mainCamera.transform.position = cameraPositions[id].transform.position;
        
            blackBackgrounds[id].gameObject.SetActive(false);
            blackBackgrounds[CurrentPosition].gameObject.SetActive(true);
        
        CurrentPosition = id;
    }
}
