using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazzardDisappearingBlock : MonoBehaviour
{
    public float time;
    public float ChargesUntilDestroy;
    private bool canReduceCharge;
    bool startDestruction;

    void Awake()
    {
        canReduceCharge = true;
        startDestruction = false;
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

   
}
