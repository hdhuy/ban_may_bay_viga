﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_Wing_Boss : BossGun
{
    private void Start()
    {
        StartCoroutine(firstWait());
    }
    IEnumerator firstWait()
    {
        yield return new WaitForSeconds(3);
        StartCoroutine(ShootWing());
    }
    IEnumerator ShootWing()
    {
        if (Blood > 0)
        {
            Transform bullet1 = ObjectPutter.Instance.PutObject(SpawnerType.Bullet_Wing_Boss, ObjectType.Bullet);
            bullet1.rotation = FirePoint.rotation;
            bullet1.position = FirePoint.position;
            bullet1.GetComponent<Bullet>().Activate();
            yield return new WaitForSeconds(4);
            StartCoroutine(ShootWing());
        }
        
    }
    
}
