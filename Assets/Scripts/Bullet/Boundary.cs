using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boundary : MonoBehaviour
{

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("EnermyBullet"))
        {
            other.gameObject.SetActive(false);
        }
        if (other.CompareTag("PlayerBullet"))
        {
            other.gameObject.SetActive(false);
        }
        if (other.CompareTag("Coin"))
        {
            other.gameObject.SetActive(false);
        }
    }

}
