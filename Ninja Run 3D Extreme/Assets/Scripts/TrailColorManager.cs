using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailColorManager : MonoBehaviour
{
    public Color[] colors;
    TrailRenderer playerTrail;

    static public Color currentTrailColor;

    private void Start()
    {
        colors[0] = Color.black;
        colors[0] = new Color();
        colors[0] = Color.green;
        colors[0] = Color.blue;
        colors[0] = Color.cyan;
        colors[0] = new Color();
        colors[0] = Color.gray; 
    }

    void ChangeColor(Color selectedColor)
    {
        playerTrail.material.color = colors[0];
    }
}
