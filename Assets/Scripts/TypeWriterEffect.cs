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
    private void Awake()
    {
        textMeshPro = GetComponent<TextMeshProUGUI>();
    }

    IEnumerator ShowText()
    {
        for (int i = 0; i < fullText.Length; i++)
        {
            currentText = fullText.Substring(0, i);
            textMeshPro.text = currentText;
            yield return new WaitForSeconds(delay);
        }
        ResetText();
    }

    private void OnDisable()
    {
        ResetText();
    }

    private void OnEnable()
    {
        fullText = textMeshPro.text;
        StartCoroutine(ShowText());
    }

    private void ResetText()
    {
        fullText = "";
        currentText = "";
    }
}
