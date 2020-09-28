using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazzardDisappearingBlock : MonoBehaviour
{
    public float time;
    public float ChargesUntilDestroy;
    private bool canReduceCharge;
    bool startDestruction;

    public float speed;
    public Color startColor;
    public Color endColor;
    float ColorTransisitionTime;
    float starTime;
    
    void Awake()
    {
        canReduceCharge = true;
        startDestruction = false;
        GetComponent<Renderer>().material.color = startColor;
    }

    void Update()
    {
        if(startDestruction = true && canReduceCharge == true)
        {
            destroyBlock();
        } 
    }
    void OnCollisionEnter(Collision other)
    {
        startDestruction = true;
        if (other.gameObject.tag == "Player")
        {
            startDestruction = true;
        }
    }

    void destroyBlock()
    {
            StartCoroutine(startToDestroy());
            StartCoroutine(ChangeColor());
            
    }

    IEnumerator startToDestroy()
    {
        if (ChargesUntilDestroy <= 0)
        {
            Destroy(gameObject);
        }
        canReduceCharge = false;

        yield return new WaitForSeconds(time);

        if(ChargesUntilDestroy > 0)
        {
            
            ChargesUntilDestroy--;
            canReduceCharge = true;
            Debug.Log(ChargesUntilDestroy);
        }
    }
    IEnumerator ChangeColor()
    {
        ColorTransisitionTime += Time.time / (ChargesUntilDestroy * time);
        GetComponent<Renderer>().material.color = Color.Lerp(startColor, endColor, ColorTransisitionTime);
        yield return null;
    }
}

 

   

