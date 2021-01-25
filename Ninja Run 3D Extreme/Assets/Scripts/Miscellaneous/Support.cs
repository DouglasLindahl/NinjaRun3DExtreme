using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Support : MonoBehaviour
{
    public Text helpText;
    public Image backGround;
    public string jump;
    GameObject scenemanager;

    private void Awake()
    {
        scenemanager = GameObject.FindGameObjectWithTag("SceneManager");
        helpText = GameObject.Find("HelpText").GetComponent<Text>();
        backGround = GameObject.Find("HelpTextBackground").GetComponent<Image>();
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
    private void LateUpdate()
    {
        if (scenemanager.GetComponent<PauseMenu>().menuOpen == true)
        {
            helpText.enabled = false;
            backGround.enabled = false;
        }
        else
        {
            helpText.enabled = true;
            backGround.enabled = true;
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
