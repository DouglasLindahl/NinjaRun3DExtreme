using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateMusic : MonoBehaviour
{
    GameObject[] smngr;
    public GameObject smngrPrefab;
    private void Awake()
    {
        smngr = GameObject.FindGameObjectsWithTag("SoundManager");
        int numberOfSoundManagers = smngr.Length;
        if (numberOfSoundManagers == 0)
        {
            Instantiate(smngrPrefab);
        }
    }
}
