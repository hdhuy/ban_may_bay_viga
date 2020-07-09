using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerEarn : Player
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Coin"))
        {
            int value = collision.GetComponent<Coin>().value;
            int currentCoin = PlayerPrefs.GetInt("coin");
            int newcoin = value + currentCoin;
            PlayerPrefs.SetInt("coin", newcoin);
            collision.gameObject.SetActive(false);
        }
    }
}
