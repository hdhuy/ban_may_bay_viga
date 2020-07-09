using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HighEnermyAttack : MediumEnermyAttack
{
    [SerializeField]
    private List<Transform> l;

    private void Start()
    {
        StartCoroutine(Shoot());
    }

    IEnumerator Shoot()
    {
        Shoot1(l[0]);
        Shoot1(l[1]);
        yield return new WaitForSeconds(0.2f);
        Shoot1(l[0]);
        Shoot1(l[1]);
        yield return new WaitForSeconds(1);
        ShootRocket();
        yield return new WaitForSeconds(1);
        StartCoroutine(Shoot());
    }
    private void Shoot1(Transform t)
    {
        Transform bullet1 = ObjectPutter.getInstance.PutObject(SpawnerType.Bullet_Medium,ObjectType.Bullet);
        bullet1.rotation = transform.localRotation;
        bullet1.position = t.position;//1
        bullet1.GetComponent<Bullet>().Activate();
    }
    private void ShootRocket()
    {
        Transform bullet1 = ObjectPutter.getInstance.PutObject(SpawnerType.Bullet_Rocket_High, ObjectType.Bullet);
        bullet1.rotation = transform.localRotation;
        bullet1.position = l[2].position;//1
        bullet1.GetComponent<Bullet>().Activate();
    }
}

