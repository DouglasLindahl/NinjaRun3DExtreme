using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    GameObject sceneManager;
    public int cost;

    private void Awake()
    {
        sceneManager = GameObject.FindGameObjectWithTag("SceneManager");
    }
}
