using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletWingBoss : Bullet
{
    public float MaxSpeed;
    public float MinSpeed;
    public float ChangeSpeed;
    public override void Activate()
    {
        gameObject.SetActive(true);
        speed = MaxSpeed;
    }
    void Update()
    {
        try
        {
            speed -= ChangeSpeed;
            _rigidbody2D.velocity = transform.up * speed;
            if (speed <= MinSpeed)
            {
                Explosion();
                gameObject.SetActive(false);
            }
        }
        catch(Exception e)
        {
            Debug.Log("Lỗi: " + e);
        }
    }
    private void Explosion()
    {
        try
        {
            createBulletMiniWingBoss(-10);
            createBulletMiniWingBoss(80);
            createBulletMiniWingBoss(170);
            createBulletMiniWingBoss(-100);
        }
        catch(Exception e)
        {
            Debug.Log("Lỗi : " + e);
        }
    }
    private void createBulletMiniWingBoss(float z)
    {
        try
        {
            Transform a = ObjectPutter.Instance.PutObject(SpawnerType.Bullet_Mini_Wing_Boss,ObjectType.Bullet);
            a.Rotate(new Vector3(0, 0, z));
            a.position = transform.position;
            a.GetComponent<Bullet>().Activate();
        }
        catch(Exception e)
        {
            Debug.Log("Lỗi bullet wing boss - explosion - " + e);
        }
    }
}
