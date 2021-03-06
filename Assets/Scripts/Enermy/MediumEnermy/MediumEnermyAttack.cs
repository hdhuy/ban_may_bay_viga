﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MediumEnermyAttack : MonoBehaviour
{
    public Transform Mid;

    public Transform Left_1;

    public Transform Left_2;

    public Transform Left_3;

    public Transform Right_1;

    public Transform Right_2;

    public Transform Right_3;
    //[SerializeField]
    //private List<float> rotZ;
    public int rot;
    private void OnEnable()
    {
        StartCoroutine(firstWait());
    }
    IEnumerator firstWait()
    {
        yield return new WaitForSeconds(4f);
        StartCoroutine(Fire());
    }
    IEnumerator Fire()
    {
        Shoot1();
        yield return new WaitForSeconds(0.1f);
        Shoot1();
        yield return new WaitForSeconds(1f);
        Shoot2();
        yield return new WaitForSeconds(0.1f);
        Shoot2();
        yield return new WaitForSeconds(1f);
        StartCoroutine(Fire());
    }
    private void Shoot1()
    {
        Transform bullet1 = ObjectPutter.Instance.PutObject(SpawnerType.Bullet_Medium,ObjectType.Bullet);
        bullet1.rotation = transform.localRotation;
        bullet1.position = Left_2.position;//1

        Transform bullet2 = ObjectPutter.Instance.PutObject(SpawnerType.Bullet_Medium, ObjectType.Bullet);
        bullet2.rotation = transform.localRotation;
        bullet2.position = Left_3.position;//2

        Transform bullet3 = ObjectPutter.Instance.PutObject(SpawnerType.Bullet_Medium, ObjectType.Bullet);
        bullet3.rotation = transform.localRotation;
        bullet3.position = Right_2.position;//3

        Transform bullet4 = ObjectPutter.Instance.PutObject(SpawnerType.Bullet_Medium, ObjectType.Bullet);
        bullet4.rotation = transform.localRotation;
        bullet4.position = Right_3.position;//4

        bullet1.GetComponent<Bullet>().Activate();
        bullet2.GetComponent<Bullet>().Activate();
        bullet3.GetComponent<Bullet>().Activate();
        bullet4.GetComponent<Bullet>().Activate();
    }
    private void Shoot2()
    {
        List<float> z = new List<float> { 25, 20, 15, 30, 35 };
        //if (GameObject.FindGameObjectsWithTag("Player").Length > 0)
        //{
        //    Vector3 player = GameObject.FindGameObjectWithTag("Player").transform.position;

        //}
        if (rot==0)
        {
            z = new List<float> { 0, -5, -10, 5, 10 };
        }
        else
        {
            if (rot<0)
            {
                z = new List<float> { -25, -30, -35, -20, -15 };
            }
        }
        Transform bullet1 = ObjectPutter.Instance.PutObject(SpawnerType.Bullet_Medium,ObjectType.Bullet);
        bullet1.position = Mid.position;//1 
        bullet1.rotation = Quaternion.Euler(0f, 0f, z[0]);

        Transform bullet2 = ObjectPutter.Instance.PutObject(SpawnerType.Bullet_Medium, ObjectType.Bullet);
        bullet2.position = Left_1.position;//2
        bullet2.rotation = Quaternion.Euler(0f, 0f, z[1]);

        Transform bullet3 = ObjectPutter.Instance.PutObject(SpawnerType.Bullet_Medium, ObjectType.Bullet);
        bullet3.position = Left_3.position;//3
        bullet3.rotation = Quaternion.Euler(0f, 0f, z[2]);

        Transform bullet4 = ObjectPutter.Instance.PutObject(SpawnerType.Bullet_Medium, ObjectType.Bullet);
        bullet4.position = Right_1.position;//4
        bullet4.rotation = Quaternion.Euler(0f, 0f, z[3]);

        Transform bullet5 = ObjectPutter.Instance.PutObject(SpawnerType.Bullet_Medium, ObjectType.Bullet);
        bullet5.position = Right_3.position;//5
        bullet5.rotation = Quaternion.Euler(0f, 0f, z[4]);

        bullet1.GetComponent<Bullet>().Activate();
        bullet2.GetComponent<Bullet>().Activate();
        bullet3.GetComponent<Bullet>().Activate();
        bullet4.GetComponent<Bullet>().Activate();
        bullet5.GetComponent<Bullet>().Activate();
    }
}
