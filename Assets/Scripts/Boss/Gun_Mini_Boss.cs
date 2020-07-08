using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_Mini_Boss : Gun_Parent_Boss
{
    void Start()
    {
        StartCoroutine(Shoot());
    }
    IEnumerator Shoot()
    {
        float rang = Random.Range(1, 1.7f);
        yield return new WaitForSeconds(rang);
        createBullet();
        StartCoroutine(Shoot());
    }
    private void createBullet()
    {
        if (Blood > 0)
        {
            Transform a = ObjectPutter.Instance.PutObject(SpawnerType.Bullet_Mini_Boss);
            a.position = FirePoint.position;
            a.rotation = FirePoint.rotation;
            a.GetComponent<Bullet>().Activate();
        }

    }

}
