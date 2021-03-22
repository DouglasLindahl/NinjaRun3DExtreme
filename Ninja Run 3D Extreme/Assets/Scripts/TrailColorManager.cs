using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailColorManager : MonoBehaviour
{
    public Color[] colors;
    TrailRenderer playerTrail;

    public Color currentTrailColor;

    private void Start()
    {
        colors[0] = Color.black;
        colors[1] = new Color();
        colors[2] = Color.green;
        colors[3] = Color.blue;
        colors[4] = Color.cyan;
        colors[5] = new Color();
        colors[6] = Color.gray; 
    }

    public void ChangeColor(Color selectedColor)
    {

        playerTrail.material.color = colors[0];
    }
}
