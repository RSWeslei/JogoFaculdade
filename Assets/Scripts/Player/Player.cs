using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance { get; private set; }
    public Transform hittingObject { get; set; }
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    
    public int Lives { get; private set; } = 3;
}
