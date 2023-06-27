using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shading : MonoBehaviour
{
    [SerializeField] private float minAlpha = 0f;
    [SerializeField] private float maxAlpha = 1f;
    [SerializeField] private float duration = 2f;
    private SpriteRenderer spriteRenderer;
    
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        float t = Mathf.PingPong(Time.time / duration, 1f);
        float alpha = Mathf.Lerp(minAlpha, maxAlpha, t);
        Color newColor = spriteRenderer.color;
        newColor = Color.red;
        newColor.a = alpha;
        spriteRenderer.color = newColor;
    }
    
    private void OnDisable()
    {
        Color newColor = spriteRenderer.color;
        newColor = Color.white;
        newColor.a = maxAlpha;
        spriteRenderer.color = newColor;
    }
}
