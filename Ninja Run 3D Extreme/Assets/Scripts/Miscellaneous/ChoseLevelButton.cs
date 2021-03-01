using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoseLevelButton : MonoBehaviour
{
    Image image;
    [SerializeField]
    Image levelImage;

    private void Awake()
    {
        image = GameObject.Find("MainImage").GetComponent<Image>();
    }
    public void HoverOverButton()
    {
        image.enabled = true;
        image = levelImage;
    }
    public void LeaveButton()
    {
        image.enabled = false;
    }
}
