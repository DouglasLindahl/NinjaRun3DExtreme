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
        coinText = GameObject.Find("CoinText").GetComponent<Text>();
        coinSound = GameObject.Find("CoinSoundFX").GetComponent<AudioSource>();
        coinsCollected = PlayerPrefs.GetInt("CoinsCollected");
    }
    private void Update()
    {
        PlayerPrefs.SetInt("CoinsCollected", coinsCollected);
        coinText.text = coinsCollected + "";
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
