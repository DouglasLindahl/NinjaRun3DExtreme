using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazzardParticleDestroyer : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(destroyParticles());
    }

    IEnumerator destroyParticles()
    {
        yield return new WaitForSeconds(5);
        Destroy(gameObject);
    }
}
