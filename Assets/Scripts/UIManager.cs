using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Transform dialogBox;
    private TypeWriterEffect typeWriterEffect;
    
    public static UIManager Instance { get; private set; }
    private void Start()
    {
        typeWriterEffect = dialogBox.GetComponent<TypeWriterEffect>();
        ToggleDialogBox(false);
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    public void ToggleDialogBox(bool toggle)
    {
        dialogBox.parent.gameObject.SetActive(toggle);
    }
    
    public void ToogleUIElement(Transform uiElement, bool toggle)
    {
        uiElement.gameObject.SetActive(toggle);
    }
    
    public void SetDialogMessage(string message)
    {
        GameManager.Instance.DisableInputs();
        ToggleDialogBox(true);
        typeWriterEffect.SetText(message);
    }
}
