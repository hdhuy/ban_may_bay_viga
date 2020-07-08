using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class RotateToPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Look());
    }
    IEnumerator Look()
    {
        if (GameObject.FindGameObjectsWithTag("Player").Length > 0)
        {
            Vector3 player = GameObject.Find("Player").transform.position;
            float z = 20;
            if (player.x == transform.position.x)
            {
                z = 0;
            }
            else
            {
                if (player.x < transform.position.x)
                {
                    z = -20;
                }
            }
            transform.DORotate(new Vector3(0, 0, z), 1);
            yield return new WaitForSeconds(1);
            StartCoroutine(Look());
        }
        
    }
}
