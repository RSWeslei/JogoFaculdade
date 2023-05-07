using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tile : MonoBehaviour
{
    public int originalIndex;
    public int currentIndex;
    public RectTransform rectTransform;

    public void SetValues(int originalIndex, int currentIndex)
    {
        this.originalIndex = originalIndex;
        this.currentIndex = currentIndex;
        rectTransform = GetComponent<RectTransform>();
    }
}
