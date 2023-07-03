using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderPuzzlePC : InteractableObject
{
    [SerializeField] private Transform sliderPuzzle;
    public override void Interact()
    {
        sliderPuzzle.gameObject.SetActive(true);
        GameManager.Instance.DisableInputs();
    }
}
