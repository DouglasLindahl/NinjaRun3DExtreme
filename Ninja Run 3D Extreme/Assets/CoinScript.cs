using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinScript : MonoBehaviour
{
    public Text coinText;
    public static int coinsCollected;
    AudioSource coinSound;
    private void Awake()
    {
        coinSound = GameObject.Find("CoinSoundFX").GetComponent<AudioSource>();
        coinsCollected = PlayerPrefs.GetInt("CoinsCollected");
    }
    private void Update()
    {
        coinText.text = coinsCollected + "";
        PlayerPrefs.SetInt("CoinsCollected", coinsCollected);
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
