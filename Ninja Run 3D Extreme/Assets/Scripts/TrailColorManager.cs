using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailColorManager : MonoBehaviour
{
    static public Color black, purple, red, green, blue, cyan, pink, silver;

    static public Color currentTrailColor;

    private void Start()
    {
        black = Color.black;
        purple = new Color();
        green = Color.green;
        blue = Color.blue;
        cyan = Color.cyan;
        pink = new Color();
        silver = Color.gray; 
    }

    void start()
    {
        currentTrailColor = black;
    }
}
