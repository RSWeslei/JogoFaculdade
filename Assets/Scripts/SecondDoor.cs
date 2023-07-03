using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SecondDoor :InteractableObject
{
    [SerializeField] public bool isOpen = false;
    public override void Interact()
    {
        if (isOpen)
        {
            SoundManager.Instance.PlaySound(SoundManager.Sound.OpenDoor);
            Player.Instance.SetHittingObject(null);
            gameObject.layer = 0;
            Destroy(this);
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            UIManager.Instance.SetDialogMessage("A porta está trancada.");
        }
    }
    
    public void OpenDoor()
    {
        isOpen = true;
        SoundManager.Instance.PlaySound(SoundManager.Sound.OpenDoor);
    }
}
