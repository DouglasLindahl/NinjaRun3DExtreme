using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public static float coinsCollected;
    AudioSource coinSound;
    private void Awake()
    {
        coinSound = GameObject.Find("CoinSoundFX").GetComponent<AudioSource>();
    }
    private void Update()
    {
        print(coinsCollected);
    }
    private void OnTriggerEnter(Collider other)
    {
        DestroyCoin();
    }
    void DestroyCoin()
    {
        Destroy(gameObject);
        coinsCollected++;
        coinSound.Play();
    }
}
