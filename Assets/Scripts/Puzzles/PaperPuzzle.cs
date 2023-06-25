using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PaperPuzzle : Puzzle
{
    [Header("Puzzle")]
    [SerializeField] private int numberOfPieces = 3;
    [SerializeField] private Transform objects;
    [SerializeField] private int[] code;
    [SerializeField] private Sprite puzzleSprite;
    [SerializeField] private Sprite[] piecesSprites;
    [SerializeField] private PlayerInputManager playerInputManager;
    private int collectedPieces = 0;
    
    [Header("UI")]
    [SerializeField] private Transform paperPieceUI;
    [SerializeField] private Transform[] pieces;
    
    private void Start()
    {
        GeneratePuzzle();
    }

    private void Awake()
    {
        playerInputManager.OnAnyKey += () =>
        {
            UIManager.Instance.ToogleUIElement(paperPieceUI, false);
        };
    }

    private void GeneratePuzzle ()
    {
        int objectsCount = objects.childCount;
        if (objectsCount < numberOfPieces)
        {
            Debug.LogError("Não há objetos suficientes para gerar o puzzle");
            return;
        }
        int[] randomPositions = new int[numberOfPieces];

        List<int> availablePositions = new List<int>();
        for (int i = 0; i < objectsCount; i++)
        {
            availablePositions.Add(i);
        }

        for (int i = 0; i < numberOfPieces; i++)
        {
            int randomIndex = Random.Range(0, availablePositions.Count);
            randomPositions[i] = availablePositions[randomIndex];
            availablePositions.RemoveAt(randomIndex);
        }

        for (int i = 0; i < numberOfPieces; i++)
        {
            GameObject obj = objects.GetChild(randomPositions[i]).gameObject;
            PaperPiece paperPiece = obj.gameObject.AddComponent(typeof(PaperPiece)) as PaperPiece;
            Destroy(obj.GetComponent<InteractableObject>());
            if (paperPiece == null) continue;
            paperPiece.number = code[i];
            paperPiece.position = i;
            paperPiece.pieceSprite = piecesSprites[i];

            paperPiece.OnInteract += CollectPaper;
        }
    }

    private void CollectPaper(PaperPiece paperPiece)
    {
        UIManager.Instance.SetDialogMessage("Peguei um pedaço de papel.");
        paperPieceUI.gameObject.SetActive(true);
        pieces[paperPiece.position].gameObject.SetActive(true);
        collectedPieces++;
        
        if (collectedPieces == numberOfPieces)
        {
            ResolvePuzzle();
        }
    }
    
    private void ResolvePuzzle()
    {
        UIManager.Instance.SetDialogMessage("Com essa senha eu consigo abrir a porta.");
    }
}
