using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : InteractableObject
{
    [SerializeField] private PuzzlesFirstRoom puzzlesFirstRoom;
    public override void Interact()
    {
        if (puzzlesFirstRoom.keyCollected)
        {
            SoundManager.Instance.PlaySound(SoundManager.Sound.OpenDoor);
            puzzlesFirstRoom.keyCollected = false;
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
}
