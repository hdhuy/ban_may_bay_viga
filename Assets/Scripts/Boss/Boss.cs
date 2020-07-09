using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    private void Start()
    {
        setLevel_1();
    }
    public void setLevel_1()
    {
        GetComponent<BossHealth>().enabled = false;
        GetComponent<Collider2D>().enabled = false;
        GetComponent<Animator>().enabled = false;
        GetComponent<CircleCollider2D>().enabled = false;
    }
    public void setLevel_2()
    {
        StartCoroutine(Changing());
    }
    public void setLevel_3()
    {
        GetComponent<BossHealth>().enabled = true;
        GetComponent<BossHealth>().isProtected = false;
        GetComponent<Collider2D>().enabled = true;
        GetComponent<CircleCollider2D>().enabled = false;
        GetComponent<Animator>().SetBool("level3", true);
    }
    IEnumerator Changing()
    {
        GetComponent<Animator>().enabled = true;
        yield return new WaitForSeconds(3);
        GetComponent<Animator>().SetBool("level2", true);
    }
}
