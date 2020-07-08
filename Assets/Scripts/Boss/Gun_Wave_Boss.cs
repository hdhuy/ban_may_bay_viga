using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun_Wave_Boss : Gun_Parent_Boss
{
    private bool rotToPlayer;
    public float WaitShoot;
    public float RotSpeed;
    public Vector2 Limit;
    //
    private Transform Player;
    private void Start()
    {
        StartCoroutine(Shoot());
        Player = GameObject.Find("Player").transform;
    }
    private void Update()
    {
        
        if (destroyed < 10)
        {
            if (rotToPlayer&&Blood>0)
            {
                if (transform.rotation.z > -60 || transform.rotation.z < -10)
                {
                    if (Player != null)
                    {
                        RotateToPlayer();
                    }
                }

            }
        }
        else
        {
            Player = null;
        }
    }
    private void RotateToPlayer()
    {
        Vector2 dir = Player.position - transform.position;
        float angle = Mathf.Atan2(dir.x, -dir.y) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, 2 * Vector3.forward);
        transform.rotation = rotation;
        //
        
    }
    IEnumerator Shoot()
    {
        rotToPlayer = false;
        createBullet();
        yield return new WaitForSeconds(WaitShoot);
        createBullet();
        yield return new WaitForSeconds(WaitShoot);
        createBullet();
        yield return new WaitForSeconds(WaitShoot);
        createBullet();
        rotToPlayer = true;
        yield return new WaitForSeconds(5f);
        if (destroyed < 10)
        {
            StartCoroutine(Shoot());
        }
        else
        {
            yield return new WaitForSeconds(1f);
            StartCoroutine(Shoot2());
        }
    }
    IEnumerator Shoot2()
    {
        ShootRocket();
        yield return new WaitForSeconds(1f);
        StartCoroutine(Shoot2());
    }
    private void ShootRocket()
    {
        Transform bullet1 = ObjectPutter.getInstance.PutObject(SpawnerType.Bullet2_Wave_Boss,ObjectType.Bullet);
        bullet1.rotation = transform.localRotation;
        bullet1.position = FirePoint.position;//1
        bullet1.GetComponent<Rigidbody2D>().velocity = transform.up * 5;
        bullet1.GetComponent<Bullet>().Activate();
    }
    private void createBullet()
    {
        if (Blood > 0)
        {
            try
            {
                Transform a = ObjectPutter.getInstance.PutObject(SpawnerType.Bullet_Wave_Boss, ObjectType.Bullet);
                a.position = FirePoint.position;
                a.rotation = FirePoint.rotation;
                a.GetComponent<Bullet>().Activate();
            }
            catch (Exception e)
            {
                Debug.Log("Lỗi: " + e);
            }
        }
        
        
    }
}
