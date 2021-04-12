using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Credits : MonoBehaviour
{
    public GameObject credits;
    public void ShowCredits()
    {
        credits.SetActive(true);
    }
    public void HideCredits()
    {
        credits.SetActive(false);
    }
}
