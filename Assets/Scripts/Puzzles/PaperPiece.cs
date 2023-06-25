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
            UIManager.Instance.SetDialogMessage("Não há mais nada aqui.");
            return;
        }
        collected = true;
        OnInteract?.Invoke(this);
    }
}
