using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_HandV2_Boss : Gun_Parent_Boss
{
    public ParticleSystem Fire;
    public float firstwait;
    private void Start()
    {
        StartCoroutine(FirstWait());
    }
    IEnumerator FirstWait()
    {
        yield return new WaitForSeconds(firstwait);
        StartCoroutine(FirePlay());
    }
    IEnumerator FirePlay()
    {
        Fire.Stop();
        yield return new WaitForSeconds(3);
        if (Blood>0)
        {
            StartCoroutine(FirePlay());
        }
        else
        {
            Fire.Stop();
        }
    }
}
