using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailColorManager : MonoBehaviour
{
    public Color[] colors;
    public TrailRenderer playerTrail;

    public Color currentTrailColor;

    public void ChangeColor(Color selectedColor)
    {
        Debug.Log(selectedColor);
        playerTrail.material.color = new Color(selectedColor.r, selectedColor.g, selectedColor.b);
    }
}
