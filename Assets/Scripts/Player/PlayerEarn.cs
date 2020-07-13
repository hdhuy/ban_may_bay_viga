using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerEarn : MonoBehaviour
{
    public Text coinText;
    private void Start()
    {
        int coin = PlayerPrefs.GetInt("coin");
        coinText.text = coin.ToString();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin"))
        {
            int value = collision.GetComponent<Coin>().value;
            int currentCoin = PlayerPrefs.GetInt("coin");
            int newcoin = value + currentCoin;
            PlayerPrefs.SetInt("coin", newcoin);
            coinText.text = newcoin.ToString();
            collision.gameObject.SetActive(false);
        }
    }
}
