using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }
    [SerializeField] public Transform hittingObject;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    
    public int Lives { get; private set; } = 3;
    
    public void SetHittingObject(Transform newHittingObject)
    {
        if (hittingObject != null && hittingObject != newHittingObject)
        {
            Shading shading = hittingObject.GetComponent<Shading>();
            if (shading != null)
            {
                shading.enabled = false;
            }
        }
        hittingObject = newHittingObject;
    }
}
