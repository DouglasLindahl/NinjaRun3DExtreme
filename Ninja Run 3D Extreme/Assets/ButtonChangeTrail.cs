using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonChangeTrail : MonoBehaviour
{
    public int colorIndex;
    TrailColorManager trailManager;
   
    void Start()
    {
        trailManager = GameObject.Find("SceneManager").GetComponent<TrailColorManager>();
    }

    public void changeTrailOnClick()
    {
        trailManager.ChangeColor(trailManager.colors[colorIndex]);
    }



}
