using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperPiece : MonoBehaviour, IInteractable
{
    [Header("Paper Piece")]
    [SerializeField] public int number;
    [SerializeField] public int position;
    [SerializeField] public Sprite pieceSprite;
    [SerializeField] private bool collected = false;
    
    public Action<PaperPiece> OnInteract;
    public void Interact()
    {
        if (collected) return;
        collected = true;
        OnInteract?.Invoke(this);
    }
}
