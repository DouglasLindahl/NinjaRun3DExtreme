using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrailColorManager : MonoBehaviour
{
    public Color[] colors;
    public TrailRenderer playerTrail;

    void Awake()
    {
        playerTrail = GameObject.Find("Trail").GetComponent<TrailRenderer>();
    }

    public void ChangeColor(Color selectedColor)
    {
        Material newMaterial = new Material(Shader.Find("Specular"));
        newMaterial.color = selectedColor;
        playerTrail.material = newMaterial;
    }
}
