using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Safe : InteractableObject
{ 
    [SerializeField] private PuzzlesFirstRoom puzzlesFirstRoom;
    [SerializeField] private PaperPuzzle paperPuzzle;

    public override void Interact()
    {
        if (puzzlesFirstRoom.allPaperCollected)
        {
            UIManager.Instance.SetDialogMessage("Consegui abrir o cofre.");
            UIManager.Instance.SetDialogMessage("Consegui uma chave. Posso usá-la para abrir a porta na lavanderia.");
            puzzlesFirstRoom.keyCollected = true;
            SoundManager.Instance.PlaySound(SoundManager.Sound.Interact);
            Player.Instance.SetHittingObject(null);
            gameObject.layer = 0;
            Destroy(this);
        }
        else
        {
            UIManager.Instance.SetDialogMessage("Ainda não tenho a senha do cofre.");
        }
    }
}
