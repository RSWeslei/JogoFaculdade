using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperPiece : InteractableObject
{
    [Header("Paper Piece")]
    [SerializeField] public int number;
    [SerializeField] public int position;
    [SerializeField] public Sprite pieceSprite;
    [SerializeField] private bool collected = false;
    
    public Action<PaperPiece> OnInteract;
    
    public override void Interact()
    {
        if (collected)
        {
            UIManager.Instance.SetDialogMessage("Já peguei esse pedaço de papel.");
            return;
        }
        collected = true;
        UIManager.Instance.SetDialogMessage("Peguei um pedaço de papel.");
        OnInteract?.Invoke(this);
        SoundManager.Instance.PlaySound(SoundManager.Sound.Interact);
        Player.Instance.SetHittingObject(null);
        gameObject.layer = 0;
        Destroy(this);
    }
}
