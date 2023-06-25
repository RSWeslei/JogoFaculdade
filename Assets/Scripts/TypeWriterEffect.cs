using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TypeWriterEffect : MonoBehaviour
{
    [SerializeField] private float delay = 0.05f;
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
        for (int i = 0; i < fullText.Length; i++)
        {
            currentText = fullText.Substring(0, i);
            textMeshPro.text = currentText;
            yield return new WaitForSeconds(delay);
        }
        isWriting = false;
        
        yield return new WaitForSeconds(1f);
        if (fifo.Count > 0)
        {
            UIManager.Instance.SetDialogMessage(fifo[0]);
            fifo.RemoveAt(0);
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
