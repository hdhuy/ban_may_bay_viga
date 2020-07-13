using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_Mini_Boss : BossGun
{
    public float firstSpeed;
    public float waitSpeed=3;
    void Start()
    {
        StartCoroutine(firstWait());
    }
    IEnumerator firstWait()
    {
        yield return new WaitForSeconds(firstSpeed);
        StartCoroutine(Shoot());
    }
    IEnumerator Shoot()
    {
        yield return new WaitForSeconds(waitSpeed);
        float rang = Random.Range(1, 1.7f);
        yield return new WaitForSeconds(rang);
        createBullet();
        yield return new WaitForSeconds(rang);
        createBullet();
        StartCoroutine(Shoot());
    }
    private void createBullet()
    {
        if (Blood > 0)
        {
            Transform a = ObjectPutter.Instance.PutObject(SpawnerType.Bullet_Mini_Boss, ObjectType.Bullet);
            a.position = FirePoint.position;
            a.rotation = FirePoint.rotation;
            a.GetComponent<Bullet>().Activate();
        }

    }

}
