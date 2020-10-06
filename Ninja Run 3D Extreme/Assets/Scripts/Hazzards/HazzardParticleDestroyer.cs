using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazzardParticleDestroyer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestroyParticle());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator DestroyParticle()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }
}
