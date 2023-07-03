using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TypeWriterEffect : MonoBehaviour
{
    [SerializeField] private float delay = 0.05f;
    [SerializeField] private PlayerInputManager playerInputManager;
    private string currentText;
    private string fullText;
    private TextMeshProUGUI textMeshPro;
    private bool isWriting = false;
    [SerializeField] private List<string> fifo = new List<string>();
    private void Awake()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();
    }

    IEnumerator ShowText()
    {
        isWriting = true;
        SoundManager.Instance.PlaySound(SoundManager.Sound.Typing);
        for (int i = 0; i < fullText.Length; i++)
        {
            currentText = fullText.Substring(0, i);
            textMeshPro.text = currentText;
            yield return new WaitForSeconds(delay);
        }
        yield return new WaitForSeconds(0.5f);
        SoundManager.Instance.StopSound();
        isWriting = false;
        
        if (fifo.Count > 0)
        {
            UIManager.Instance.SetDialogMessage(fifo[0]);
            fifo.RemoveAt(0);
            yield break;
        }
        if (fifo.Count == 0)
        {
            playerInputManager.ToggleWaitInput(true);
        }
    }

    private void OnDisable()
    {
        ResetText();
    }

    public void SetText(string text)
    {
        if (isWriting)
        {
            fifo.Add(text);
        }
        else
        {
            fullText = text;
            StartCoroutine(ShowText());
        }
    }

    private void ResetText()
    {
        fullText = "";
        currentText = "";
    }
}
