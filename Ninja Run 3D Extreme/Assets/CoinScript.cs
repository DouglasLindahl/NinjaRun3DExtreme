using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public float coinsCollected;
    private void OnTriggerEnter(Collider other)
    {
        DestroyCoin();
    }
    void DestroyCoin()
    {
        Destroy(gameObject);
        coinsCollected++;
    }
}
