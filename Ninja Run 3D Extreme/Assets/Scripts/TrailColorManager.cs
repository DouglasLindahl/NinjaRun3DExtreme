using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailColorManager : MonoBehaviour
{
    public Color[] colors;
    TrailRenderer playerTrail;

    public Color currentTrailColor;

    public void ChangeColor(Color selectedColor)
    {

        playerTrail.material.color = colors[0];
    }
}
