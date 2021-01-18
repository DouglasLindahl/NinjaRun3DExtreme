using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Support : MonoBehaviour
{
    public Text helpText;
    public Image backGround;
    public string jump;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(helpText.text == "")
        {
            backGround.gameObject.SetActive(false);
        }
        else
        {
            backGround.gameObject.SetActive(true);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            helpText.text = jump;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            helpText.text = "";
        }
    }
}
