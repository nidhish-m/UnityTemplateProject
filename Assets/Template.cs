using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Template
{
    public string objectName;
    public string objectType;
    public int sortingOrder;
    public Vector2 position;
    public Vector2 size;
    public Color objectColor; // New property for color
    // Add more properties as needed
}